import { createServer, Model } from 'miragejs'

export function makeServer ({ environment = 'development' } = {}) {
  return createServer({
    environment,

    models: {
      user: Model,
      news: Model,
      article: Model
    },

    seeds (server) {
      server.create('user', {
        role: 'user'
      })

      server.create('news', {
        title: 'Сотрудникам Twitter поручили распечатать копии кода, создали «военную комнату»: NYT — о первом дне Маска в офисе',
        text: 'Предприниматель уже успел уволить несколько топ-менеджеров, писали СМИ.'
      })

      server.create('news', {
        title: 'Мой мелкий, но железный бизнес',
        text: 'Июнь 2012 года. Звонок в дверь. На пороге немолодая пара: «Мы по объявлению». Мужчина огромных размеров еле вместился в прихожую хрущёвки, то и дело цепляясь за дверные косяки. Не мой клиент, подумал я. Но случилось чудо – позвонили на следующий день и приехали с риелтором. Москва, чемодан, вокзал. Депозитный счет в банке с процентами в $1300 в…'
      })

      server.create('news', {
        title: 'Подан коллективный иск к организатору спортивного мероприятия Challenge Moscow',
        text: 'Спортсмены подали коллективный иск к организатору соревнований по триатлону ООО “Спортлайв”. Соревнования должны были состояться в июне 2022, но были отменены. Участие в мероприятии было платным.'
      })

      // @ts-ignore
      server.create('article', {
        blocks: [
          {
            id: 'N0s41Akt8q',
            type: 'header',
            data: {
              text: 'Заголовок',
              level: 1
            }
          },
          {
            id: 'bgr-YfzTCk',
            type: 'paragraph',
            data: {
              text: 'Тут <a href="http://google.com">будет</a> <b>текст</b>'
            }
          }
        ],
        time: 1667588844968,
        commentsCount: 5
      })
    },

    routes () {
      this.namespace = 'api'

      this.post('/auth', (schema) => {
        return schema.users.find(1)
      })

      this.get('/news', (schema) => {
        return schema.news.all()
      })

      this.get('/article/1', (schema) => {
        return schema.articles.find(1)
      })
    }
  })
}
