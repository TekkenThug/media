<template>
  <section class="profile">
    <LayoutIsland class="profile__wrapper" shadowed>
      <div class="profile__left">
        <UIInput
          v-model="login"
          placeholder="Логин"
          label="Логин"
          :is-error="$v.login.$error"
          :error-text="loginError"
        />

        <UIInput
          v-model="email"
          label="E-mail"
          placeholder="Email"
          :is-error="$v.email.$error"
          :error-text="emailError"
        />

        <UIInput
          v-model="phone"
          v-mask="'+7##########'"
          label="Телефон"
          placeholder="Телефон"
          :is-error="$v.phone.$error"
          :error-text="phoneError"
        />

        <UIInput
          v-model="secondName"
          label="Фамилия"
          placeholder="Фамилия"
          :is-error="$v.secondName.$error"
          :error-text="secondNameError"
        />

        <UIInput
          v-model="firstName"
          label="Имя"
          placeholder="Имя"
          :is-error="$v.firstName.$error"
          :error-text="firstNameError"
        />

        <UIInput
          v-model="thirdName"
          label="Отчество"
          placeholder="Отчество"
        />

        <UIInput
          v-if="changePassword"
          v-model="password"
          placeholder="Новый пароль"
          label="Новый пароль"
          type="password"
          :is-error="$v.password.$error"
          :error-text="passwordError"
        />

        <div class="profile__btn-list">
          <v-btn v-if="!changePassword" @click="changePassword = true">
            Сменить пароль
          </v-btn>

          <v-btn @click="handleSubmit">
            Обновить профиль
          </v-btn>
        </div>
      </div>

      <div class="profile__right">
        <ProfileImage :src="image" @updateImage="handleUpdateImage" />
      </div>
    </LayoutIsland>
  </section>
</template>

<script>
import { email, required } from 'vuelidate/lib/validators'
import { isPhone } from '@/utils/string'

import LayoutIsland from '@/components/layouts/LayoutIsland'
import UIInput from '@/components/ui/UIInput'
import ProfileImage from '@/components/profile/ProfileImage'

export default {
  name: 'ProfilePage',

  components: {
    LayoutIsland,
    UIInput,
    ProfileImage
  },

  middleware: ['authenticated'],

  data () {
    return {
      image: 'https://64.media.tumblr.com/49a172ac8d8a444ec541bf6f96406e6f/09e3b25b9304d0e6-14/s250x400/0a259c112c38b81b3925653f70f769faaf9dca42.png',
      login: 'TekkenThug',

      email: 'v.ignatov@gmail.com',
      phone: '+79997008181',
      password: '',
      firstName: 'Вадим',
      secondName: 'Игнатов',
      thirdName: '',

      changePassword: false
    }
  },

  validations () {
    if (this.changePassword) {
      return {
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
        }
      }
    }

    return {
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
      }
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
    }
  },

  methods: {
    handleUpdateImage (image) {
      this.image = image
    },

    handleSubmit () {
      this.$v.$touch()

      if (!this.$v.$invalid) {
        console.log('success')
      }
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/mixins"

  .profile
    &__wrapper
      display: flex
      justify-content: space-between

      @include mobile
        flex-direction: column-reverse
        align-items: center

    &__login-edit-btn
      font-size: 12px

    &__left
      flex-basis: 60%

      @include mobile
        flex-basis: auto
        width: 100%
        margin-top: 24px

      > *:not(:first-child)
        margin-top: 18px

    &__btn-list
      display: flex
      flex-direction: column

      > *:not(:first-child)
        margin-top: 18px
</style>
