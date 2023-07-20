export function formatNumber(value: number | null | undefined): string {
  if (value || value === 0) {
    return value.toLocaleString('en-US', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2,
    })
  }
  else {
    return '-'
  }
}
export function formatDate(
  date: Date | string | null | undefined,
  format = 'MMM DD, YYYY',
): string {
  if (date)
    return dayjs(date).format(format)
  else return '-'
}
