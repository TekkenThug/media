interface State {
  isAuth: Boolean,
  role: 'user' | 'editor' | 'admin' | 'copywriter' | ''
}

export const state = (): State => ({
  isAuth: false,
  role: ''
})
