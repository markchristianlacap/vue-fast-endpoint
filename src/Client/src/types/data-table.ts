import type { QTableProps } from 'quasar'
import type { PagedResponse } from './pagination'

export interface RemoteDataTableProps<T> extends QTableProps {
  response: PagedResponse<T> | null | undefined
  request: any
}
