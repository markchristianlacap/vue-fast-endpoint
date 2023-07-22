<script setup lang="ts">
import type { UserPagedModel } from '~/api/users'

const appStore = useAppStore()
const router = useRouter()
const user = computed(() => appStore.user)
const { fetch, loading, request, response } = usePagedRequest<UserPagedModel>(
  usersApi.getPaged,
  { search: '' },
)
async function logout() {
  await appStore.logout()
  router.push('/')
}
onMounted(() => {
  fetch()
})
watchDeep(request, () => {
  fetch()
})
</script>

<template>
  Hi, {{ user?.name }}
  <q-btn dense color="negative" label="Logout" @click="logout" />
  {{ request }}
  <div class="q-mt-lg">
    <RemoteDataTable
      v-model:pagination="request"
      :response="response"
      :loading="loading"
    />
  </div>
</template>
