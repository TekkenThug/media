<template>
  <header class="header">
    <div class="header__left">
      <button class="header__burger" @click="toggleSidebar">
        <v-icon color="#fff">
          mdi-menu
        </v-icon>
      </button>
    </div>

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
            @click="handleUserBtnClick"
          >
            <v-icon>
              {{ profileIcon }}
            </v-icon>
          </v-btn>
        </template>

        {{ profileTooltipCaption }}
      </v-tooltip>
    </div>

    <Modal
      name="auth"
      adaptive
      height="auto"
    >
      <ModalAuth />
    </Modal>
  </header>
</template>

<script>
import { MEDIA_VARIABLES } from '@/data/constats'
import UIInput from '@/components/ui/UIInput'
import ModalAuth from '@/components/modals/modal-auth/'

export default {
  name: 'Header',

  components: {
    UIInput,
    ModalAuth
  },

  data () {
    return {
      searchValue: ''
    }
  },

  computed: {
    isAuth () {
      return this.$store.state.user.isAuth
    },

    profileTooltipCaption () {
      return this.isAuth ? 'Профиль' : 'Войти'
    },

    profileIcon () {
      return this.isAuth ? 'mdi-account-outline' : 'mdi-account-arrow-left-outline'
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
    },

    handleUserBtnClick () {
      if (this.isAuth) {
        this.$router.push('/profile')
      } else {
        this.$modal.show('auth')
      }
    },

    toggleSidebar () {
      if (window.innerWidth <= MEDIA_VARIABLES.sidebar) {
        this.$store.commit('app/toggleMobileSidebar')
      } else {
        this.$store.commit('app/toggleSidebar')
      }
    }
  }
}
</script>

<style lang="sass" scoped>
@import "assets/sass/_variables"
@import "assets/sass/mixins"

.header
  position: fixed
  top: 0
  left: 0
  z-index: $headerIndex
  display: flex
  align-items: center
  justify-content: center
  width: 100%
  min-height: $headerHeight
  padding: 10px 15px
  background-color: $slate-blue

  @include mobile
    justify-content: flex-start

  &__left
    position: absolute
    left: 15px
    top: 50%
    transform: translateY(-50%)
    color: #fff

  &__center
    display: flex
    align-items: stretch
    max-width: 640px
    width: 100%

    @include mobile
      max-width: none
      padding-right: 58px
      padding-left: 42px

  &__search
    flex-grow: 1
    color: #fff

    ::v-deep .ui-input__field
      border-color: #fff
      border-width: 2px

  &__create-btn
    margin-left: 10px

  &__right
    position: absolute
    right: 15px
</style>
