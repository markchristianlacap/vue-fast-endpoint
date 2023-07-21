export interface LoginRequest {
  email: string
  password: string
}
export const userApi = {
  login: async (data: LoginRequest) => {
    await api.post('/user/login', data)
  },
}
