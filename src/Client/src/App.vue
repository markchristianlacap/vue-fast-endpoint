<script setup lang="ts">
const route = useRoute()
const head = computed(
  () => route.meta?.head as { title: string; description: string },
)
const title = computed(() => head.value?.title)
const description = computed(() => head.value?.description)
useHead({
  title,
  meta: [{ name: 'description', content: description }],
})
</script>

<template>
  <RouterView />
</template>
