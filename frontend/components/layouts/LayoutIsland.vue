<template>
  <component :is="tag" :class="['island', { '_shadowed': shadowed }]">
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
    },

    shadowed: {
      type: Boolean,
      default: false
    }
  }
}
</script>

<style lang="sass" scoped>
  .island
    $boxShadow: 0 2px 4px rgb(0 0 0 / 6%)

    position: relative
    padding: 16px 20px
    border-radius: 8px
    background-color: #fff
    transition: box-shadow 170ms ease

    &._shadowed
      box-shadow: $boxShadow

    &:hover
      box-shadow: $boxShadow
</style>
