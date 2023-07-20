import dayjsInstance from 'dayjs'
import customParseFormat from 'dayjs/plugin/customParseFormat'

dayjsInstance.extend(customParseFormat)
export const dayjs = dayjsInstance
