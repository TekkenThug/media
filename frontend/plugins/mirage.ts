if (process.env.NODE_ENV === 'development') {
  import('../modules/mirage').then((module) => {
    module.makeServer()
  })
}
