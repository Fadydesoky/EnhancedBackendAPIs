import axios from 'axios'

const API_URL = 'http://localhost:5147/api/users'

export interface User {
  id: number
  name: string
  email: string
}

export const getUsers = async (): Promise<User[]> => {
  const response = await axios.get(API_URL)
  return response.data
}

export const createUser = async (user: Omit<User, 'id'>): Promise<User> => {
  const response = await axios.post(API_URL, user)
  return response.data
}

export const updateUser = async (user: User): Promise<User> => {
  const response = await axios.put(`${API_URL}/${user.id}`, user)
  return response.data
}

export const deleteUser = async (id: number): Promise<void> => {
  await axios.delete(`${API_URL}/${id}`)
}

