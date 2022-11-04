<template>
  <div class="modal-auth">
    <h2 class="modal-auth__title">
      {{ title }}
    </h2>

    <ModalAuthLogin v-if="mode === 'auth'" @onSubmit="auth" />

    <ModalAuthRegister v-else @onSubmit="register" />

    <div class="modal-auth__btn-wrapper">
      <a
        href="#"
        class="modal-auth__link"
        @click.prevent="changeMode"
      >
        {{ linkText }}
      </a>
    </div>
  </div>
</template>

<script>
import ModalAuthLogin from './ModalAuthLogin'
import ModalAuthRegister from './ModalAuthRegister'

export default {
  name: 'ModalAuth',

  components: { ModalAuthRegister, ModalAuthLogin },

  data () {
    return {
      mode: 'auth'
    }
  },

  computed: {
    title () {
      return this.mode === 'auth' ? 'Войти' : 'Регистрация'
    },

    linkText () {
      return this.mode === 'auth' ? 'Нет аккаунта? Зарегистрируйтесь' : 'Есть аккаунт? Войдите'
    }
  },

  methods: {
    changeMode () {
      this.mode = this.mode === 'auth' ? 'register' : 'auth'
    },

    async auth (authData) {
      try {
        const { data } = await this.$axios.post('/auth', authData)

        this.$store.commit('user/setAuthState', data.user.role)
        this.$emit('success')
      } catch (e) {
        this.$notify({
          title: 'Ошибка при входе',
          type: 'error',
          text: 'Пожалуйста, повторите позже'
        })
      }
    },

    register (data) {
      console.log(data)
    }
  }
}
</script>

<style lang="sass" scoped>
@import "assets/sass/mixins"

.modal-auth
  display: flex
  flex-direction: column
  height: 100%

  &__title
    margin-bottom: 24px
    text-align: center

  &__field-wrapper
    margin-bottom: 12px
    color: #000

    > *:not(:last-child)
      margin-bottom: 12px

  &__btn-wrapper
    display: flex
    flex-direction: column
    align-items: center

    > *:first-child
      margin-bottom: 12px

  &__link
    @include link
    margin-top: 20px
    font-size: 14px
</style>
