import axios from 'axios'

const API_URL = import.meta.env.VITE_API_URL || '/api'
function axiosInstance() {
  const api = axios.create({
    baseURL: API_URL,
    withCredentials: true,
    headers: {
      'X-Requested-With': 'XMLHttpRequest',
    },
  })
  return api
}
export const api = axiosInstance()
