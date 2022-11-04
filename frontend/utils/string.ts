import { RUS_PHONE_REGEX } from '~/data/constats'

export const isPhone = (value: string) => RUS_PHONE_REGEX.test(value)

export const pluralize = (count: number, words: string[]) => {
  const cases = [2, 0, 1, 1, 1, 2]
  return count + ' ' + words[(count % 100 > 4 && count % 100 < 20) ? 2 : cases[Math.min(count % 10, 5)]]
}
