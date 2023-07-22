import { type UserModule } from '~/types/module'

export const install: UserModule = ({ router }) => {
  router.beforeEach(async (to) => {
    if (to.meta.auth === false)
      return
    const store = useAppStore()
    const redirect = to.query.redirect
    if (!store.user)
      await store.fetchUser()
    switch (to.meta.auth) {
      case 'guest':
        if (store.user !== null)
          return { path: redirect || '/user' }
        return
      default:
        if (store.user === null) {
          return {
            path: '/',
            query: { redirect: to.fullPath },
          }
        }
        break
    }
  })
}
