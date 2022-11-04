import { createServer, Model } from 'miragejs'

export function makeServer ({ environment = 'development' } = {}) {
  return createServer({
    environment,

    models: {
      user: Model
    },

    seeds (server) {
      server.create('user', {
        role: 'user'
      })
    },

    routes () {
      this.namespace = 'api'

      this.post('/auth', (schema) => {
        return schema.users.find(1)
      })
    }
  })
}
