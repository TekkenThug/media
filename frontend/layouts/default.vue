<template>
  <div class="site-layout" data-app>
    <Header />

    <main class="site-layout__content">
      <Nuxt />
    </main>

    <Sidebar />

    <notifications position="bottom right" />
  </div>
</template>

<script>
import Header from '@/components/common/Header'
import Sidebar from '@/components/common/Sidebar'

export default {
  name: 'Default',

  components: {
    Header,
    Sidebar
  }
}
</script>

<style lang="sass">
  @import "assets/sass/_variables.sass"

  .site-layout
    display: flex
    flex-direction: column
    min-height: 100vh
    align-items: center
    padding-top: $headerHeight

    &__content
      flex-grow: 1
      max-width: 670px
      width: 100%
      padding: 0 15px

    &__notification
      position: fixed
      bottom: 15px
      right: 15px
</style>
