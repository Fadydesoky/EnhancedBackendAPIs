'use client'

import { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { getUsers, createUser, updateUser, deleteUser, User } from '@/services/soapApi'
import { toast } from 'react-hot-toast'
import { LoadingSpinner } from '@/components/loading-spinner'

export default function SoapApiPage() {
  const [newUser, setNewUser] = useState({ name: '', email: '' })
  const [editingUser, setEditingUser] = useState<User | null>(null)

  const queryClient = useQueryClient()

  const { data: users, isLoading, isError } = useQuery<User[]>(['users'], getUsers)

  const createMutation = useMutation(createUser, {
    onSuccess: () => {
      queryClient.invalidateQueries(['users'])
      toast.success('User created successfully')
      setNewUser({ name: '', email: '' })
    },
    onError: () => toast.error('Failed to create user')
  })

  const updateMutation = useMutation(updateUser, {
    onSuccess: () => {
      queryClient.invalidateQueries(['users'])
      toast.success('User updated successfully')
      setEditingUser(null)
    },
    onError: () => toast.error('Failed to update user')
  })

  const deleteMutation = useMutation(deleteUser, {
    onSuccess: () => {
      queryClient.invalidateQueries(['users'])
      toast.success('User deleted successfully')
    },
    onError: () => toast.error('Failed to delete user')
  })

  if (isLoading) return <LoadingSpinner />
  if (isError) return <div className="text-center text-red-500">Error fetching users. Please try again later.</div>

  return (
    <div className="space-y-8">
      <h1 className="text-3xl font-bold">SOAP API Users</h1>
      
      <div className="space-y-4">
        <h2 className="text-xl font-semibold">Add New User</h2>
        <form onSubmit={async (e) => {
          e.preventDefault()
          try {
            await createMutation.mutateAsync(newUser)
          } catch (error) {
            console.error('Error creating user:', error)
          }
        }} className="space-y-2">
          <input
            type="text"
            value={newUser.name}
            onChange={(e) => setNewUser({ ...newUser, name: e.target.value })}
            placeholder="Name"
            className="w-full p-2 border rounded"
            required
          />
          <input
            type="email"
            value={newUser.email}
            onChange={(e) => setNewUser({ ...newUser, email: e.target.value })}
            placeholder="Email"
            className="w-full p-2 border rounded"
            required
          />
          <button type="submit" className="px-4 py-2 bg-primary text-primary-foreground rounded">
            Add User
          </button>
        </form>
      </div>

      <div className="space-y-4">
        <h2 className="text-xl font-semibold">User List</h2>
        <ul className="space-y-4">
          {users?.map(user => (
            <li key={user.id} className="p-4 bg-card text-card-foreground rounded shadow">
              {editingUser?.id === user.id ? (
                <form onSubmit={(e) => {
                  e.preventDefault()
                  updateMutation.mutate(editingUser)
                }} className="space-y-2">
                  <input
                    type="text"
                    value={editingUser.name}
                    onChange={(e) => setEditingUser({ ...editingUser, name: e.target.value })}
                    className="w-full p-2 border rounded"
                    required
                  />
                  <input
                    type="email"
                    value={editingUser.email}
                    onChange={(e) => setEditingUser({ ...editingUser, email: e.target.value })}
                    className="w-full p-2 border rounded"
                    required
                  />
                  <div className="space-x-2">
                    <button type="submit" className="px-4 py-2 bg-primary text-primary-foreground rounded">
                      Save
                    </button>
                    <button onClick={() => setEditingUser(null)} className="px-4 py-2 bg-secondary text-secondary-foreground rounded">
                      Cancel
                    </button>
                  </div>
                </form>
              ) : (
                <>
                  <p><strong>Name:</strong> {user.name}</p>
                  <p><strong>Email:</strong> {user.email}</p>
                  <div className="mt-2 space-x-2">
                    <button onClick={() => setEditingUser(user)} className="px-4 py-2 bg-primary text-primary-foreground rounded">
                      Edit
                    </button>
                    <button onClick={() => deleteMutation.mutate(user.id)} className="px-4 py-2 bg-destructive text-destructive-foreground rounded">
                      Delete
                    </button>
                  </div>
                </>
              )}
            </li>
          ))}
        </ul>
      </div>
    </div>
  )
}

