<template>
  <section class="main">
    <div class="main__feed" data-app>
      <v-select
        v-model="dateFilter"
        :items="dateFilterSet"
        label="Фильтр по дате"
        solo
      ></v-select>

      <Island
        v-for="(item, index) in news"
        :key="index"
        class="main__feed-item"
        :header="item.title"
        :content="item.text"
        :link="item.link"
      />
    </div>
  </section>
</template>

<script>
import Island from '~/components/island/Island'

export default {
  name: 'IndexPage',
  components: { Island },
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
      news: [
        {
          title: 'Сотрудникам Twitter поручили распечатать копии кода, создали «военную комнату»: NYT — о первом дне Маска в офисе',
          text: 'Предприниматель уже успел уволить несколько топ-менеджеров, писали СМИ.',
          link: '/article/1'
        },
        {
          title: 'Мой мелкий, но железный бизнес',
          text: 'Июнь 2012 года. Звонок в дверь. На пороге немолодая пара: «Мы по объявлению». Мужчина огромных размеров еле вместился в прихожую хрущёвки, то и дело цепляясь за дверные косяки. Не мой клиент, подумал я. Но случилось чудо – позвонили на следующий день и приехали с риелтором. Москва, чемодан, вокзал. Депозитный счет в банке с процентами в $1300 в…',
          link: '/article/2'
        },
        {
          title: 'Подан коллективный иск к организатору спортивного мероприятия Challenge Moscow',
          text: 'Спортсмены подали коллективный иск к организатору соревнований по триатлону ООО “Спортлайв”. Соревнования должны были состояться в июне 2022, но были отменены. Участие в мероприятии было платным.',
          link: '/article/3'
        }
      ]
    }
  }
}
</script>

<style lang="sass">
.main
  padding-top: 28px

  &__search
    margin-bottom: 28px

  &__feed-item
    & + &
      margin-top: 28px
</style>
