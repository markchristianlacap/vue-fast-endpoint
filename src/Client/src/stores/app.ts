import type { LoginRequest, UserResponse } from '~/api/user'

export const useAppStore = defineStore('app', () => {
  const $q = useQuasar()
  const dark = useLocalStorage<boolean>('darkMode', $q.dark.isActive)
  const user = ref<UserResponse | null>(null)

  const toggleDark = () => {
    dark.value = !dark.value
    $q.dark.set(dark.value)
  }

  const fetchUser = async () => {
    try {
      user.value = await userApi.getUser()
    }
    catch {
      user.value = null
    }
  }
  const login = async (data: LoginRequest) => {
    await userApi.login(data)
    await fetchUser()
  }
  const logout = async () => {
    await userApi.logout()
    user.value = null
  }

  return {
    user,
    dark,
    toggleDark,
    fetchUser,
    login,
    logout,
  }
})
