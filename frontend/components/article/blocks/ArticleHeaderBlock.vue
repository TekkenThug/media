<template>
  <component :is="headLevel" class="article-block-header">
    {{ text }}
  </component>
</template>

<script>
export default {
  name: 'ArticleHeaderBlock',

  props: {
    text: {
      type: String,
      default: ''
    },

    level: {
      type: [String, Number],
      default: 2
    }
  },

  computed: {
    headLevel () {
      return `h${this.level}`
    }
  }
}
</script>
