<template>
  <article class="island">
    <h3 class="island__header">
      {{ header }}
    </h3>

    <p v-if="content" class="island__content" v-html="content" />

    <NuxtLink :to="link" class="island__link" />
  </article>
</template>

<script>
export default {
  name: 'Island',

  props: {
    header: {
      type: String,
      required: true
    },

    content: {
      type: String,
      default: ''
    },

    link: {
      type: String,
      required: true
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

  &__header
    margin-bottom: 8px

  &__content
    line-height: 24px

  &__link
    position: absolute
    top: 0
    left: 0
    width: 100%
    height: 100%
</style>
