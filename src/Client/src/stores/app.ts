export const useAppStore = defineStore('app', () => {
  const $q = useQuasar()
  const dark = useLocalStorage<boolean>('darkMode', $q.dark.isActive)
  const toggleDark = () => {
    dark.value = !dark.value
    $q.dark.set(dark.value)
  }
  return {
    dark,
    toggleDark,
  }
})
