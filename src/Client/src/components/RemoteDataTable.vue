<script setup lang="ts" generic="T">
import type { QTableSlots } from 'quasar'
import type { RemoteDataTableProps } from '~/types/data-table'

const props = withDefaults(defineProps<RemoteDataTableProps<T>>(), {
  rowsPerPageOptions: () => [15, 50, 200, 0],
})
const emits = defineEmits<{
  (e: 'update:response', value: typeof props.response): void
  (e: 'update:pagination', value: typeof props.pagination): void
  (e: 'view', row: T): void
  (e: 'edit', row: T): void
  (e: 'cancel', row: T): void
  (e: 'delete', row: T): void
}>()

const { response, pagination } = useVModels(props, emits)
function getSlots(slots: any) {
  const tableSlots = slots as QTableSlots
  return tableSlots
}
function onRequest(params: any) {
  pagination!.value = params.pagination
}
function checkable(
  row: T,
  col: 'cancelable' | 'deletable' | 'editable' | 'viewable',
) {
  if (typeof props[col] === 'function') {
    const fn = props[col] as (row: T) => boolean
    return fn(row)
  }
  return props[col]
}
const tablePagination = computed(() => {
  return {
    ...pagination!.value,
    rowsNumber: response!.value?.total,
  }
})
</script>

<template>
  <q-table
    v-bind="props"
    :rows="response?.rows"
    :pagination="tablePagination"
    :dark="$q.dark.isActive"
    @request="onRequest"
  >
    <template #body-cell-action="prop">
      <q-td :props="prop" class="children:un-mx1px">
        <q-btn
          v-if="viewable"
          dense
          color="accent"
          icon="file_open"
          :disable="!checkable(prop.row, 'viewable')"
          flat
          @click="emits('view', { ...prop.row })"
        >
          <q-tooltip v-if="viewMessage || checkable(prop.row, 'viewable')">
            {{ viewMessage }}
          </q-tooltip>
        </q-btn>
        <q-btn
          v-if="editable"
          color="accent"
          icon="edit"
          :disable="!checkable(prop.row, 'editable')"
          dense
          flat
          round
          @click="emits('edit', { ...prop.row })"
        >
          <q-tooltip v-if="checkable(prop.row, 'editable')">
            {{ editMessage }}
          </q-tooltip>
        </q-btn>
        <q-btn
          v-if="cancelable"
          dense
          color="negative"
          flat
          icon="block"
          :disable="!checkable(prop.row, 'cancelable')"
          @click="emits('cancel', { ...prop.row })"
        >
          <q-tooltip v-if="cancelMessage && checkable(prop.row, 'cancelable')">
            {{ cancelMessage }}
          </q-tooltip>
        </q-btn>
        <q-btn
          v-if="deletable"
          dense
          color="negative"
          icon="delete"
          flat
          :disable="!checkable(prop.row, 'deletable')"
          @click="emits('delete', { ...prop.row })"
        >
          <q-tooltip v-if="deleteMessage && checkable(prop.row, 'deletable')">
            {{ deleteMessage }}
          </q-tooltip>
        </q-btn>
      </q-td>
    </template>
    <template v-for="(_, slot) in getSlots($slots)" #[slot]="scope">
      <slot :name="slot" v-bind="scope" />
    </template>
  </q-table>
</template>
