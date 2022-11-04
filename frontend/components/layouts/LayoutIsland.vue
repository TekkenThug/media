<template>
  <component :is="tag" class="island">
    <slot />
  </component>
</template>

<script>
export default {
  name: 'LayoutIsland',

  props: {
    tag: {
      type: String,
      default: 'div'
    }
  }
}
</script>

<style lang="sass" scoped>
  .island
    position: relative
    padding: 16px 20px
    border-radius: 8px
    background-color: #fff
    transition: box-shadow 170ms ease

    &:hover
      box-shadow: 0 2px 4px rgb(0 0 0 / 6%)
</style>
