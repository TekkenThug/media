<template>
  <div class="modal-auth-login">
    <div class="modal-auth-login__field-wrapper">
      <UIInput
        v-model="email"
        placeholder="Email"
        :is-error="$v.email.$error"
        :error-text="emailError"
      />

      <UIInput
        v-model="password"
        placeholder="Пароль"
        type="password"
        :is-error="$v.password.$error"
        :error-text="passwordError"
      />
    </div>

    <div class="modal-auth-login__btn-wrapper">
      <v-btn block @click="handleSubmit">
        Войти
      </v-btn>
    </div>
  </div>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators'
import UIInput from '@/components/ui/UIInput'

export default {
  name: 'ModalAuthLogin',

  components: { UIInput },

  data () {
    return {
      email: '',
      password: ''
    }
  },

  validations: {
    email: {
      required,
      email
    },
    password: {
      required
    }
  },

  computed: {
    emailError () {
      if (!this.$v.email.required) {
        return 'Поле обязательно к заполнению'
      } else if (!this.$v.email.email) {
        return 'Поле имеет неверный формат'
      }

      return ''
    },

    passwordError () {
      if (!this.$v.password.required) {
        return 'Поле обязательно к заполнению'
      }

      return ''
    }
  },

  methods: {
    handleSubmit () {
      this.$v.$touch()

      if (!this.$v.$invalid) {
        this.$emit('onSubmit', {
          email: this.email,
          password: this.password
        })
      }
    }
  }
}
</script>

<style lang="sass" scoped>
.modal-auth-login
  &__field-wrapper
    margin-bottom: 12px
    color: #000

    > *:not(:last-child)
      margin-bottom: 12px
</style>
