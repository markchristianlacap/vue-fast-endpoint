import type { PagedResponse } from '~/types/pagination'

export function usePagedRequest<T>(
  fetchFn: (req?: any) => Promise<PagedResponse<T>>,
  params: any,
) {
  const loading = ref(false)
  const response = ref<PagedResponse<T>>()
  const request = ref(params)
  const fetch = async () => {
    loading.value = true
    response.value = await fetchFn(request.value)
    loading.value = false
  }
  return {
    loading,
    response,
    fetch,
    request,
  }
}
