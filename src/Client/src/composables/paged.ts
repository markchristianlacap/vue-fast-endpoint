import type { PagedRequest, PagedResponse } from '~/types/pagination'

export function usePagedRequest<T1, T2>(
  fetchFn: (req?: T1) => Promise<PagedResponse<T2>>,
  initFilters?: T1,
) {
  const loading = ref(false)
  const response = ref<PagedResponse<T2>>()
  const pagination = ref<PagedRequest>({})
  const filters = ref<T1>(initFilters ?? ({} as T1))
  const fetch = async () => {
    loading.value = true
    const request = { ...pagination.value, ...filters.value! } as T1
    response.value = await fetchFn(request)
    loading.value = false
  }
  const resetPaged = () => {
    pagination.value = {}
  }
  return {
    loading,
    response,
    fetch,
    filters,
    resetPaged,
    pagination,
  }
}
