// @ts-ignore
export default function ({ store, redirect }) {
  // If the user is not editor
  if (!(store.state.user.role === 'editor')) {
    return redirect('/')
  }
}
