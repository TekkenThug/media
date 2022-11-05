<template>
  <transition-group name="slide-fade">
    <aside v-if="hasSidebar" key="desktop" class="sidebar _desktop">
      <nav class="sidebar__nav">
        <ul class="sidebar__list">
          <li
            v-for="route in allowedRoutes"
            :key="route.title"
            class="sidebar__item"
          >
            <NuxtLink class="sidebar__item-link" :to="route.to">
              <v-icon class="sidebar__item-icon">
                {{ route.icon }}
              </v-icon>

              {{ route.title }}
            </NuxtLink>
          </li>
        </ul>
      </nav>
    </aside>

    <aside
      v-if="hasMobileSidebar"
      key="mobile"
      class="sidebar _mobile"
      @click.self="hide"
    >
      <button class="sidebar__burger" @click="hide">
        <v-icon>
          mdi-menu
        </v-icon>
      </button>

      <nav class="sidebar__nav">
        <ul class="sidebar__list">
          <li
            v-for="route in allowedRoutes"
            :key="route.title"
            class="sidebar__item"
          >
            <NuxtLink
              class="sidebar__item-link"
              :to="route.to"
              @click.native="hide"
            >
              <v-icon class="sidebar__item-icon">
                {{ route.icon }}
              </v-icon>

              {{ route.title }}
            </NuxtLink>
          </li>
        </ul>
      </nav>
    </aside>
  </transition-group>
</template>

<script>
import { MEDIA_VARIABLES } from '@/data/constats'
import { lockBody, unlockBody } from '@/utils/dom'

export default {
  name: 'Sidebar',

  data () {
    return {
      items: [
        {
          title: 'Лента',
          icon: 'mdi-rss',
          to: '/',
          auth: false
        },
        {
          title: 'Администрирование',
          icon: 'mdi-shield-crown-outline',
          to: '/admin',
          auth: true,
          role: ['admin']
        },
        {
          title: 'Профиль',
          icon: 'mdi-account-circle-outline',
          to: '/profile',
          auth: true
        },
        {
          title: 'Статьи',
          icon: 'mdi-post-outline',
          to: '/publications',
          auth: true,
          role: ['editor', 'admin', 'copywriter']
        }
      ]
    }
  },

  computed: {
    hasSidebar () {
      return this.$store.state.app.hasSidebar
    },

    hasMobileSidebar () {
      return this.$store.state.app.hasMobileSidebar
    },

    allowedRoutes () {
      const isAuth = this.$store.state.user.isAuth
      const role = this.$store.state.user.role

      return this.items.filter((item) => {
        if (!item.auth) { return true }

        return Boolean(item.auth && isAuth && (!item.role || item.role.includes(role)))
      })
    }
  },

  watch: {
    hasMobileSidebar (val) {
      val ? lockBody() : unlockBody()
    }
  },

  methods: {
    hide () {
      if (window.innerWidth <= MEDIA_VARIABLES.sidebar) {
        this.$store.commit('app/toggleMobileSidebar')
      }
    }
  }
}
</script>

<style lang="sass" scoped>
@import "assets/sass/_variables"

.sidebar
  $sidebarWidth: 240px

  position: absolute
  top: 96px
  left: 0
  width: $sidebarWidth

  &._desktop
    @media (max-width: $sidebarMaxRange)
      display: none

  &._mobile
    display: none

    @media (max-width: $sidebarMaxRange)
      display: block
      position: fixed
      top: 0
      z-index: $sidebarIndex
      height: 100vh
      width: 100vw
      background-color: rgba($black, .8)

  &__burger
    display: none

    @media (max-width: $sidebarMaxRange)
      display: block
      position: absolute
      top: 22px
      left: 15px

  &__nav
    @media (max-width: $sidebarMaxRange)
      width: $sidebarWidth
      height: 100%
      padding-top: 96px
      background-color: $cultured

  &__list
    padding: 0 10px

  &__item
    border-radius: 8px
    transition: all .3s ease
    user-select: none
    overflow: hidden

    & + &
      margin-top: 5px

    &:hover
      background-color: #E0E0E0

  &__item-link
    display: flex
    align-items: center
    padding: 10px 8px
    transition: all .2s ease

    &.nuxt-link-exact-active
      background-color: $white

      .sidebar__item-icon
        color: $sandy-brown

  &__item-icon
    margin-right: 8px
</style>
