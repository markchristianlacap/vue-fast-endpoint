import path from 'node:path'
import Vue from '@vitejs/plugin-vue'
import Pages from 'vite-plugin-pages'
import Layouts from 'vite-plugin-vue-layouts'
import Components from 'unplugin-vue-components/vite'
import AutoImport from 'unplugin-auto-import/vite'
import Unocss from 'unocss/vite'
import { defineConfig } from 'vite'
import { QuasarResolver } from 'unplugin-vue-components/resolvers'
import webfontDownload from 'vite-plugin-webfont-dl'
import VueMacros from 'unplugin-vue-macros/vite'

export default defineConfig({
  resolve: {
    alias: {
      '~/': `${path.resolve(__dirname, 'src')}/`,
    },
  },
  plugins: [
    VueMacros({
      plugins: {
        vue: Vue(),
      },
    }),
    Pages({ exclude: ['**/components/*.vue', '**/*.ts'] }),
    Layouts(),
    AutoImport({
      imports: [
        'vue',
        'vue-router',
        'vue/macros',
        '@vueuse/core',
        '@vueuse/head',
        'quasar',
        'pinia',
      ],
      dirs: ['src/composables/*', 'src/stores/*', 'src/plugins/*', 'src/utils/*', 'src/api/*'],
      vueTemplate: true,
      dts: 'src/auto-imports.d.ts',
    }),
    Components({
      directoryAsNamespace: true,
      resolvers: [QuasarResolver()],
      dts: 'src/components.d.ts',
    }),
    Unocss(),
    webfontDownload(),
  ],
})
