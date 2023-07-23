import type { QTableProps, QTableSlots } from 'quasar'
import type { PagedResponse } from './pagination'

export interface RemoteDataTableProps<T> extends Omit<QTableProps, 'rows' | 'dark'> {
  response: PagedResponse<T> | undefined
  editable?: boolean | ((row: T) => boolean)
  viewable?: boolean | ((row: T) => boolean)
  deletable?: boolean | ((row: T) => boolean)
  cancelable?: boolean | ((row: T) => boolean)
  editMessage?: string | ((row: T) => string)
  viewMessage?: string | ((row: T) => string)
  deleteMessage?: string | ((row: T) => string)
  cancelMessage?: string | ((row: T) => string)
}
export interface RemoteDataTableSlots extends QTableSlots {}
