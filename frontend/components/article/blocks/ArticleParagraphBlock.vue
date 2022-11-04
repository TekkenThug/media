<template>
  <p class="article-paragraph-block" v-html="text" />
</template>

<script>
export default {
  name: 'ArticleParagraphBlock',

  props: {
    text: {
      type: String,
      default: ''
    }
  }
}
</script>

<style lang="sass">
  @import 'assets/sass/mixins'

  .article-paragraph-block
    a
      @include link

</style>
