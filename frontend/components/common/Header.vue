<template>
  <header class="header" data-app>
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
            <EditIcon />
          </v-btn>
        </template>

        Создать статью
      </v-tooltip>
    </div>
  </header>
</template>

<script>
import { EditIcon } from '@iconicicons/vue'
import UIInput from '@/components/ui/UIInput'

export default {
  name: 'Header',

  components: {
    EditIcon,
    UIInput
  },

  data () {
    return {
      searchValue: ''
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

.header
  display: flex
  align-items: center
  justify-content: center
  width: 100%
  padding: 10px 24px
  background-color: $slate-blue

  &__center
    display: flex
    align-items: stretch
    max-width: 640px
    width: 100%

  &__search
    flex-grow: 1
    color: #fff

  &__create-btn
    margin-left: 10px

  &__right
    margin-left: auto
</style>
