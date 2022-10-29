<template>
  <div class="site-layout">
    <Header />

    <main class="site-layout__content">
      <Nuxt />
    </main>
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

<style>
  .site-layout {
    display: flex;
    flex-direction: column;
    min-height: 100vh;
  }

  .site-layout__content {
    flex-grow: 1;
    padding-top: 16px;
  }
</style>
