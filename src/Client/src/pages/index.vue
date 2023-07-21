<script setup lang="ts">
import { LoginRequest, userApi } from '~/api/user';

const router = useRouter()
const request = ref<LoginRequest>({
  email: '',
  password: '',
})
const errors = ref<Record<string, string[]>>({})
const showPassword = ref(false)
const loading = ref(false)
const login = async () => {
  loading.value = true
  try {
    await userApi.login(request.value)
    await router.push('/')
  } catch (e:any) {
    errors.value = e?.response?.data?.errors ?? {}
  } finally {
    loading.value = false
  }
}
</script>

<template>
  <div>
    <q-card class="un-(w-full max-w-500px mx-auto mt-lg)">
      <q-card-section>
        <q-input
          v-model="request.email"
          label="Email"
          :error="!!errors.email"
          :error-message="errors.email?.[0]"
          icon="email"
          type="email"
        />
        <q-input
          v-model="request.password"
          label="Password"
          :error="!!errors.password"
          :error-message="errors.password?.[0]"
          icon="lock"
          :type="showPassword ? 'text' : 'password'"
        />
        <q-btn
          v-ripple
          :loading="loading"
          :disable="loading"
          :label="loading ? 'Loading...' : 'Login'"
          color="primary"
          class="full-width"
          @click="login"
        />
      </q-card-section>
    </q-card>
  </div>
</template>

<route lang="yaml">
meta:
  layout: empty
</route>
