export const lockBody = () => {
  if (document.body.classList.contains('_lock')) { return }

  document.body.classList.add('_lock')
}

export const unlockBody = () => {
  if (!document.body.classList.contains('_lock')) { return }

  document.body.classList.remove('_lock')
}
