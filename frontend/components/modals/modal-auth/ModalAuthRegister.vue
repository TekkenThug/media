<template>
  <div class="modal-auth-register">
    <div class="modal-auth-register__field-wrapper">
      <UIInput
        v-model="email"
        placeholder="Email"
        :is-error="$v.email.$error"
        :error-text="emailError"
      />

      <UIInput
        v-model="phone"
        v-mask="'+7##########'"
        placeholder="Телефон"
        :is-error="$v.phone.$error"
        :error-text="phoneError"
      />

      <UIInput
        v-model="secondName"
        placeholder="Фамилия"
        :is-error="$v.secondName.$error"
        :error-text="secondNameError"
      />

      <UIInput
        v-model="firstName"
        placeholder="Имя"
        :is-error="$v.firstName.$error"
        :error-text="firstNameError"
      />

      <UIInput
        v-model="thirdName"
        placeholder="Отчество"
      />

      <UIInput
        v-model="login"
        placeholder="Логин"
        :is-error="$v.login.$error"
        :error-text="loginError"
      />

      <UIInput
        v-model="password"
        placeholder="Пароль"
        type="password"
        :is-error="$v.password.$error"
        :error-text="passwordError"
      />

      <UIInput
        v-model="repeatPassword"
        placeholder="Повторите пароль"
        type="password"
        :is-error="$v.repeatPassword.$error"
        :error-text="repeatPasswordError"
      />
    </div>

    <div class="modal-auth-register__btn-wrapper">
      <v-btn block @click="handleSubmit">
        Зарегистрироваться
      </v-btn>
    </div>
  </div>
</template>

<script>
import { required, email, sameAs } from 'vuelidate/lib/validators'
import { isPhone } from '@/utils/string'
import UIInput from '@/components/ui/UIInput'

export default {
  name: 'ModalAuthRegister',

  components: { UIInput },

  data () {
    return {
      email: '',
      phone: '',
      password: '',
      repeatPassword: '',
      login: '',
      firstName: '',
      secondName: '',
      thirdName: ''
    }
  },

  validations: {
    email: {
      required,
      email
    },
    phone: {
      required,
      isPhone
    },
    secondName: {
      required
    },
    firstName: {
      required
    },
    login: {
      required
    },
    password: {
      required
    },
    repeatPassword: {
      required,
      sameAs: sameAs('password')
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

    phoneError () {
      if (!this.$v.phone.required) {
        return 'Поле обязательно к заполнению'
      }

      if (!this.$v.phone.isPhone) {
        return 'Значение телефона неверного формата'
      }

      return ''
    },

    firstNameError () {
      if (!this.$v.firstName.required) {
        return 'Поле обязательно к заполнению'
      }

      return ''
    },

    secondNameError () {
      if (!this.$v.secondName.required) {
        return 'Поле обязательно к заполнению'
      }

      return ''
    },

    loginError () {
      if (!this.$v.login.required) {
        return 'Поле обязательно к заполнению'
      }

      return ''
    },

    passwordError () {
      if (!this.$v.password.required) {
        return 'Поле обязательно к заполнению'
      }

      return ''
    },

    repeatPasswordError () {
      if (!this.$v.repeatPassword.required) {
        return 'Поле обязательно к заполнению'
      }

      if (!this.$v.repeatPassword.sameAs) {
        return 'Поле не совпадает с введеным паролем'
      }

      return ''
    }
  },

  methods: {
    handleSubmit () {
      this.$v.$touch()

      if (!this.$v.$invalid) {
        this.$emit('onSubmit', {
          login: this.login,
          email: this.email,
          password: this.password,
          firstName: this.firstName,
          secondName: this.secondName,
          ...(this.thirdName && { thirdName: this.thirdName }),
          phone: this.phone
        })
      }
    }
  }
}
</script>

<style lang="sass" scoped>
.modal-auth-register
  &__field-wrapper
    margin-bottom: 12px
    color: #000

    > *:not(:last-child)
      margin-bottom: 12px
</style>
