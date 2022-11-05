<template>
  <section class="publications">
    <LayoutIsland shadowed>
      <h2 class="publications__title">
        Проверка статей
      </h2>

      <p class="publications__subtitle">
        Проверяйте статьи перед публикацией:

        <span>1) Принимайте статьи, и они тот час же публикуются</span>
        <span>2) Откажите в публикации, пояснив причину отказа</span>
      </p>
    </LayoutIsland>

    <div class="publications__list">
      <FeedItem
        v-for="item in articles"
        :key="item.id"
        class="publications__item"
        :header="item.title"
        :content="item.text"
        :link="item.link"
      />
    </div>
  </section>
</template>

<script>
import LayoutIsland from '@/components/layouts/LayoutIsland'
import FeedItem from '@/components/feed/FeedItem'

export default {
  name: 'PublicationsPage',

  components: {
    LayoutIsland,
    FeedItem
  },

  middleware: ['authenticated', 'isEditor'],

  async asyncData ({ $axios }) {
    const { data: { news } } = await $axios.get('/news')

    console.log(news)

    return {
      articles: news.map((item) => {
        return { ...item, link: `/article/${item.id}` }
      })
    }
  },

  data () {
    return {
      articles: []
    }
  }
}
</script>

<style lang="sass" scoped>
  .publications
    &__title
      margin-bottom: 24px

    &__subtitle
      line-height: 24px

      span
        display: block
        margin-bottom: 5px
        margin-left: 10px

        &:first-child
          margin-top: 8px

    &__list
      margin-top: 32px

    &__item
      & + &
        margin-top: 28px
</style>
