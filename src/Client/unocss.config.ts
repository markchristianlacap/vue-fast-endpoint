import {
  defineConfig,
  presetUno,
  transformerDirectives,
  transformerVariantGroup,
} from 'unocss'
import { themeColors } from './src/constants/theme-colors'

interface Colors {
  [key: string]:
  | (Colors & {
    DEFAULT?: string
  })
  | string
}
export default defineConfig({
  theme: {
    colors: themeColors as Colors,
  },
  presets: [
    presetUno({
      prefix: 'un-',
      dark: {
        light: '.body--light',
        dark: '.body--dark',
      },
    }),
  ],
  transformers: [transformerDirectives(), transformerVariantGroup()],
})
