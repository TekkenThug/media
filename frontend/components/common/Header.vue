<template>
  <header class="header">
    <div class="header__center">
      <UIInput
        v-model="searchValue"
        class="header__search"
        placeholder="Поиск по заголовку"
      />

      <v-tooltip bottom>
        <template #activator="{ on, attrs }">
          <v-btn
            class="header__create-btn"
            min-width="44"
            height="48"
            width="48"
            v-bind="attrs"
            v-on="on"
            @click="openEditor"
          >
            <v-icon>
              mdi-pencil-outline
            </v-icon>
          </v-btn>
        </template>

        Создать статью
      </v-tooltip>
    </div>

    <div class="header__right">
      <v-tooltip bottom>
        <template #activator="{ on, attrs }">
          <v-btn
            min-width="44"
            height="48"
            width="48"
            v-bind="attrs"
            v-on="on"
          >
            <v-icon>
              {{ profileIcon }}
            </v-icon>
          </v-btn>
        </template>

        {{ profileTooltipCaption }}
      </v-tooltip>
    </div>
  </header>
</template>

<script>
import UIInput from '@/components/ui/UIInput'

export default {
  name: 'Header',

  components: {
    UIInput
  },

  data () {
    return {
      searchValue: ''
    }
  },

  computed: {
    profileTooltipCaption () {
      return this.$store.state.user.isAuth ? 'Выйти' : 'Войти'
    },

    profileIcon () {
      return this.$store.state.user.isAuth ? 'mdi-account-arrow-right-outline' : 'mdi-account-arrow-left-outline'
    }
  },

  methods: {
    openEditor () {
      if (!this.$store.state.user.isAuth) {
        this.$notify({
          title: 'Войдите в систему',
          text: 'Создание статьи доступно только авторизованным пользователям'
        })
      } else {
        this.$router.push('/editor')
      }
    }
  }
}
</script>

<style lang="sass" scoped>
@import "assets/sass/_variables"
@import "assets/sass/mixins"

.header
  position: relative
  display: flex
  align-items: center
  justify-content: center
  width: 100%
  min-height: 68px
  padding: 10px 15px
  background-color: $slate-blue

  @include mobile
    justify-content: flex-start

  &__center
    display: flex
    align-items: stretch
    max-width: 640px
    width: 100%

    @include mobile
      max-width: none
      padding-right: 58px

  &__search
    flex-grow: 1
    color: #fff

  &__create-btn
    margin-left: 10px

  &__right
    position: absolute
    right: 15px
</style>
