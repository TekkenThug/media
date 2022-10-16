<template>
  <a-layout class="site-layout">
    <a-layout-header>
      Header
    </a-layout-header>

    <a-layout-content class="site-layout__content">
      <Nuxt />
    </a-layout-content>

    <a-layout-footer>
      Footer
    </a-layout-footer>
  </a-layout>
</template>

<script>
export default {
  name: 'Default'
}
</script>

<style>
  .site-layout {
    display: flex;
    min-height: 100vh;
  }

  .site-layout__content {
    flex-grow: 1;
  }
</style>
