export interface PagedRequest {
  sortBy?: string | null
  descending?: boolean
  page?: number
  rowsPerPage?: number
}

export interface PagedResponse<T> {
  currentPage: number
  pageCount: number
  rowsPerPage: number
  total: number
  rows: T[]
}
