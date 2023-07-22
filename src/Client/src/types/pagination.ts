export interface PagedRequest {
  page?: number | null
  rowsPerPage?: number | null
}

export interface PagedResponse<T> {
  currentPage: number
  pageCount: number
  rowsPerPage: number
  total: number
  rows: T[]
}
