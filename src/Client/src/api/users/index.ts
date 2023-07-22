import type { PagedRequest, PagedResponse } from '~/types/pagination'

export interface UserPagedRequest extends PagedRequest {
  search: string | null
}

export interface UserPagedModel {
  id: string
  name: string
  email: string
  createdAt: string
}

export const usersApi = {
  async getPaged(
    req?: UserPagedRequest,
  ): Promise<PagedResponse<UserPagedModel>> {
    const { data } = await api.get('/users', { params: req })
    return data
  },
}
