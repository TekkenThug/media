interface State {
  isAuth: Boolean,
  role: 'user' | 'editor' | 'admin' | ''
}

export const state = (): State => ({
  isAuth: false,
  role: ''
})
