import axios from 'axios'
import { parseString } from 'xml2js'

const API_URL = 'http://localhost:5269/UserService.asmx'

export interface User {
  id: number
  name: string
  email: string
}

const parseXml = (xml: string): Promise<any> => {
  return new Promise((resolve, reject) => {
    parseString(xml, (err, result) => {
      if (err) reject(err)
      else resolve(result)
    })
  })
}

export const getUsers = async (): Promise<User[]> => {
  const soapEnvelope = `
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <GetAllUsers xmlns="http://tempuri.org/" />
      </soap:Body>
    </soap:Envelope>
  `

  const response = await axios.post(API_URL, soapEnvelope, {
    headers: { 'Content-Type': 'text/xml' },
  })

  const result = await parseXml(response.data)
  return result['soap:Envelope']['soap:Body'][0]['GetAllUsersResponse'][0]['GetAllUsersResult'][0]['User']
}

export const createUser = async (user: Omit<User, 'id'>): Promise<User> => {
  const soapEnvelope = `
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <CreateUser xmlns="http://tempuri.org/">
          <name>${user.name}</name>
          <email>${user.email}</email>
        </CreateUser>
      </soap:Body>
    </soap:Envelope>
  `

  const response = await axios.post(API_URL, soapEnvelope, {
    headers: { 'Content-Type': 'text/xml' },
  })

  const result = await parseXml(response.data)
  return result['soap:Envelope']['soap:Body'][0]['CreateUserResponse'][0]['CreateUserResult'][0]
}

export const updateUser = async (user: User): Promise<User> => {
  const soapEnvelope = `
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <UpdateUser xmlns="http://tempuri.org/">
          <id>${user.id}</id>
          <name>${user.name}</name>
          <email>${user.email}</email>
        </UpdateUser>
      </soap:Body>
    </soap:Envelope>
  `

  const response = await axios.post(API_URL, soapEnvelope, {
    headers: { 'Content-Type': 'text/xml' },
  })

  const result = await parseXml(response.data)
  return result['soap:Envelope']['soap:Body'][0]['UpdateUserResponse'][0]['UpdateUserResult'][0]
}

export const deleteUser = async (id: number): Promise<void> => {
  const soapEnvelope = `
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <DeleteUser xmlns="http://tempuri.org/">
          <id>${id}</id>
        </DeleteUser>
      </soap:Body>
    </soap:Envelope>
  `

  await axios.post(API_URL, soapEnvelope, {
    headers: { 'Content-Type': 'text/xml' },
  })
}

