import {
  defineConfig,
  presetUno,
  transformerDirectives,
  transformerVariantGroup,
} from 'unocss'
import { themeColors } from './src/constants/theme-colors'

export default defineConfig({
  theme: {
    colors: themeColors,
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
