<template>
  <div class="comment-item">
    <div class="comment-item__top">
      <div class="comment-item__avatar">
        <img :src="avatar" alt="">
      </div>

      <h4 class="comment-item__author">
        {{ author }}
      </h4>
    </div>

    <div class="comment-item__bottom">
      {{ text }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'CommentItem',

  props: {
    author: {
      type: String,
      required: true
    },

    avatar: {
      type: String,
      default: ''
    },

    text: {
      type: String,
      required: true
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/variables"

  .comment-item
    &__top
      display: flex
      align-items: center

    &__avatar
      width: 32px
      height: 32px
      margin-right: 10px
      border: 1px solid $gainsboro
      border-radius: 50%
      overflow: hidden

      img
        width: 100%
        height: 100%
        object-fit: cover

    &__bottom
      margin-top: 8px
</style>
