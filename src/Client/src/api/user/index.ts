export interface LoginRequest {
  email: string
  password: string
}
export interface UserResponse {
  id: string
  name: string
  email: string
}
export const userApi = {
  login: async (data: LoginRequest) => {
    await api.post('/user/login', data)
  },
  logout: async () => {
    await api.post('/user/logout')
  },
  getUser: async (): Promise<UserResponse> => {
    const { data } = await api.get<UserResponse>('/user')
    return data
  },
}
