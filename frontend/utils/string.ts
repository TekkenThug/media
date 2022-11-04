import { RUS_PHONE_REGEX } from '~/data/constats'

export const isPhone = (value: string) => RUS_PHONE_REGEX.test(value)
