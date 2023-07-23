import type { PagedResponse } from '~/types/pagination'

export function usePagedRequest<T1, T2>(
  fetchFn: (req?: T1) => Promise<PagedResponse<T2>>,
  initialParams?: T1,
) {
  const loading = ref(false)
  const response = ref<PagedResponse<T2>>()
  const params = ref<T1>(initialParams ?? ({} as T1))
  const fetch = async () => {
    loading.value = true
    response.value = await fetchFn(params.value as T1)
    loading.value = false
  }

  return {
    loading,
    response,
    fetch,
    params,
  }
}
