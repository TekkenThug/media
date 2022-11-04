<template>
  <section class="main">
    <div class="main__feed">
      <v-select
        v-model="dateFilter"
        :items="dateFilterSet"
        label="Фильтр по дате"
        solo
      />

      <transition-group name="fade">
        <FeedItem
          v-for="item in news"
          :key="item.id"
          class="main__feed-item"
          :header="item.title"
          :content="item.text"
          :link="item.link"
        />
      </transition-group>
    </div>
  </section>
</template>

<script>
import FeedItem from '~/components/feed/FeedItem'

export default {
  name: 'IndexPage',

  components: { FeedItem },

  async asyncData ({ $axios }) {
    const { data: { news } } = await $axios.get('/news')

    return {
      news: news.map((item) => {
        return { ...item, link: `/article/${item.id}` }
      })
    }
  },

  data () {
    return {
      dateFilter: 'today',
      dateFilterSet: [
        {
          text: 'Сегодня',
          value: 'today'
        },
        {
          text: '24 часа',
          value: 'twenty'
        },
        {
          text: 'Неделя',
          value: 'week'
        },
        {
          text: 'Месяц',
          value: 'month'
        },
        {
          text: 'Год',
          value: 'year'
        }
      ],
      news: []
    }
  }
}
</script>

<style lang="sass">
.main
  &__search
    margin-bottom: 28px

  &__feed-item
    & + &
      margin-top: 28px
</style>
