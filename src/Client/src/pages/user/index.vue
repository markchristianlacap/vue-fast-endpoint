<script setup lang="ts">
const appStore = useAppStore()
const router = useRouter()
const user = computed(() => appStore.user)
async function logout() {
  await appStore.logout()
  router.push('/')
}
</script>

<template>
  Hi, {{ user?.name }}
  <q-btn dense color="negative" label="Logout" @click="logout" />
</template>
