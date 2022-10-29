<template>
  <div class="site-layout" data-app>
    <Header />

    <main class="site-layout__content">
      <Nuxt />
    </main>

    <notifications position="bottom right" />
  </div>
</template>

<script>
import Header from '@/components/common/Header'

export default {
  name: 'Default',

  components: {
    Header
  }
}
</script>

<style lang="sass">
  .site-layout
    display: flex
    flex-direction: column
    min-height: 100vh
    align-items: center

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
