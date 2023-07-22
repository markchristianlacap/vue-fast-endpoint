<script setup lang="ts" generic="T">
import type { QTableSlots } from 'quasar'
import type { RemoteDataTableProps } from '~/types/data-table'

const props = defineProps<RemoteDataTableProps<T>>()
const emits = defineEmits<{
  (e: 'update:response', value: any): void
  (e: 'update:pagination', value: any): void
}>()
const { response, pagination } = useVModels(props, emits)

function getSlots(slots: any) {
  const tableSlots = slots as QTableSlots
  return tableSlots
}
</script>

<template>
  <q-table v-model:pagination="pagination" :rows="response?.rows">
    <template v-for="(_, slot) in getSlots($slots)" #[slot]="scope">
      <slot :name="slot" v-bind="scope" />
    </template>
  </q-table>
</template>
