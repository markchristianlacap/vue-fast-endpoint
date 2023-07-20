import '@quasar/extras/material-icons/material-icons.css'
import 'quasar/dist/quasar.prod.css'
import { Dialog, Loading, Notify, Quasar } from 'quasar'
import { type UserModule } from '~/types/module'
import { themeColors } from '~/constants/theme-colors'

const isDark = localStorage.getItem('darkMode') === 'true'
export const install: UserModule = ({ app }) => {
  const opt = {
    config: {
      brand: themeColors,
      notify: {
        position: 'top-right',
      },
      dark: isDark,
    },
    plugins: {
      Notify,
      Dialog,
      Loading,
    },
  }
  app.use(Quasar, opt as any)
}
