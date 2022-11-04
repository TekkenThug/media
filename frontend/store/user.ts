type Role = 'user' | 'editor' | 'admin' | 'copywriter' | ''

interface State {
  isAuth: Boolean,
  role: Role
}

export const state = (): State => ({
  isAuth: false,
  role: ''
})

export const mutations = {
  setAuthState (state: State, role: Role) {
    state.isAuth = true
    state.role = role
  }
}
