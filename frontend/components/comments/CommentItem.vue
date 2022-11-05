<template>
  <div class="comment-item">
    <div v-if="isHidden" class="comment-item__overlay">
      <v-icon>
        mdi-eye-off-outline
      </v-icon>

      <span>Комментарий скрыт</span>
    </div>

    <template v-else>
      <div class="comment-item__top">
        <div class="comment-item__avatar">
          <img :src="avatar" alt="">
        </div>

        <h4 class="comment-item__author">
          {{ author }}
        </h4>
      </div>

      <div class="comment-item__middle">
        {{ text }}
      </div>

      <ul v-if="isModerator" class="comment-item__bottom">
        <li
          v-for="item in actions"
          :key="item.title"
          class="comment-item__action-item"
          @click="item.callback"
        >
          <v-icon class="icon" small>
            {{ item.icon }}
          </v-icon>

          <span>{{ item.title }}</span>
        </li>
      </ul>
    </template>
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
    },

    isHidden: {
      type: Boolean,
      default: false
    }
  },

  data () {
    return {
      actions: [
        {
          title: 'Скрыть',
          icon: 'mdi-eye-off-outline',
          callback: ''
        },
        {
          title: 'Заблокировать',
          icon: 'mdi-cancel',
          callback: ''
        }
      ]
    }
  },

  computed: {
    isModerator () {
      return this.$store.state.user.role === 'moderator'
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/variables"

  .comment-item
    &__overlay
      display: flex
      flex-direction: column
      justify-content: center
      align-items: center
      width: 100%
      height: 80px
      border-radius: 8px
      background-color: $cultured

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

    &__middle
      margin-top: 8px

    &__bottom
      display: flex
      align-items: center
      margin-top: 8px

    &__action-item
      display: flex
      align-items: center
      font-size: 12px
      transition: all .2s linear
      cursor: pointer

      &:hover
        color: $slate-blue

        .icon
          color: $slate-blue

      span
        margin-left: 4px

      &:not(:first-child)
        position: relative
        margin-left: 15px

        &:before
          content: ""
          position: absolute
          top: 50%
          left: -9px
          transform: translateY(-50%)
          width: 3px
          height: 3px
          border-radius: 50%
          background-color: darken($gainsboro, 10)
</style>
