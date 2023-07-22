<script setup lang="ts">
import type { LoginRequest } from '~/api/user'

const router = useRouter()
const appStore = useAppStore()
const request = ref<LoginRequest>({
  email: '',
  password: '',
})
const errors = ref<Record<string, string[]>>({})
const showPassword = ref(false)
const loading = ref(false)

async function login() {
  loading.value = true
  try {
    await appStore.login(request.value)
    await router.push('/user')
  }
  catch (e: any) {
    errors.value = e?.response?.data?.errors ?? {}
  }
  finally {
    loading.value = false
  }
}
</script>

<template>
  <div class="un-(grid h-screen w-screen items-center justify-center)">
    <form @submit.prevent="login">
      <q-card class="un-(max-w-500px w-full)" bordered flat>
        <q-card-section>
          <p class="text-h6">
            Login Form
          </p>
          <q-banner v-if="errors.generalErrors" class="bg-negative text-white q-my-md">
            <div v-for="error in errors.generalErrors" :key="error">
              {{ error }}
            </div>
          </q-banner>
          <q-input
            v-model="request.email"
            label="Email"
            :error="!!errors.email"
            :error-message="errors.email?.[0]"
            type="email"
          >
            <template #prepend>
              <q-icon name="email" />
            </template>
          </q-input>
          <q-input
            v-model="request.password"
            label="Password"
            :error="!!errors.password"
            :error-message="errors.password?.[0]"
            icon="lock"
            :type="showPassword ? 'text' : 'password'"
          >
            <template #append>
              <q-btn
                :icon="showPassword ? 'visibility_off' : 'visibility'"
                flat
                round
                :class="showPassword ? 'text-primary' : 'text-grey-5'"
                @click="showPassword = !showPassword"
              />
            </template>
            <template #prepend>
              <q-icon name="lock" />
            </template>
          </q-input>
        </q-card-section>
        <q-card-actions>
          <q-btn
            class="full-width"
            :loading="loading"
            :disable="loading"
            :label="loading ? 'Loading...' : 'Login'"
            color="primary"
            type="submit"
          />
        </q-card-actions>"
      </q-card>
    </form>
  </div>
</template>

<route lang="yaml">
meta:
  layout: empty
  auth: guest
</route>
