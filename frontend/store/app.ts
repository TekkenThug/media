interface State {
  hasSidebar: Boolean,
  hasMobileSidebar: Boolean,
}

export const state = (): State => ({
  hasSidebar: true,
  hasMobileSidebar: false
})

export const mutations = {
  toggleSidebar (state: State) {
    state.hasMobileSidebar = false
    state.hasSidebar = !state.hasSidebar
  },

  toggleMobileSidebar (state: State) {
    state.hasMobileSidebar = !state.hasMobileSidebar
  }
}
