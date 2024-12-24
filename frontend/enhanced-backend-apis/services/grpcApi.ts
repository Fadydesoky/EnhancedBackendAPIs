import axios from 'axios'

const API_URL = 'http://localhost:5115/api/users' // Adjust this URL as needed

export interface UserData {
  id: number
  name: string
  email: string
}

export const getUsers = async (): Promise<UserData[]> => {
  const response = await axios.get(API_URL)
  return response.data
}

export const createUser = async (userData: Omit<UserData, 'id'>): Promise<UserData> => {
  const response = await axios.post(API_URL, userData)
  return response.data
}

export const updateUser = async (userData: UserData): Promise<UserData> => {
  const response = await axios.put(`${API_URL}/${userData.id}`, userData)
  return response.data
}

export const deleteUser = async (id: number): Promise<void> => {
  await axios.delete(`${API_URL}/${id}`)
}

