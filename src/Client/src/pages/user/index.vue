<script setup lang="ts">
import type { QTableColumn } from 'quasar'

const appStore = useAppStore()
const router = useRouter()
const user = computed(() => appStore.user)
const { fetch, loading, params, response } = usePagedRequest(
  usersApi.getPaged,
)
async function logout() {
  await appStore.logout()
  router.push('/')
}
const columns: QTableColumn[] = [
  {
    name: 'name',
    field: 'name',
    label: 'Name',
    style: 'max-width: 200px',
    align: 'left',
    sortable: true,
  },
  {
    name: 'email',
    field: 'email',
    label: 'Email',
    style: 'max-width: 200px',
    align: 'left',
    sortable: true,
  },
  {
    name: 'createdAt',
    field: 'createdAt',
    label: 'Created At',
    style: 'max-width: 200px',
    align: 'left',
    sortable: true,
    format: (val: string) => formatDate(val),
  },
]
watchDeep(params, () => {
  fetch()
})
onMounted(fetch)
</script>

<template>
  Hi, {{ user?.name }}
  <q-btn dense color="negative" label="Logout" @click="logout" />
  <div class="q-mt-lg">
    <p class="text-h6">
      Users
    </p>
    <RemoteDataTable v-model:pagination="params" :response="response" flat :columns="columns" :loading="loading" />
  </div>
</template>
