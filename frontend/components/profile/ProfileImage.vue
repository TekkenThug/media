<template>
  <div class="profile-image">
    <img :src="src" alt="">

    <div class="profile-image__overlay" @click="uploadImage">
      <v-icon color="#fff">
        mdi-image
      </v-icon>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ProfileImage',

  props: {
    src: {
      type: String,
      default: ''
    }
  },

  methods: {
    uploadImage () {
      this.$emit('updateImage')
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/_variables.sass"

  .profile-image
    position: relative
    width: 128px
    height: 128px
    border-radius: 50%
    overflow: hidden

    &:hover
      .profile-image__overlay
        opacity: 1

    img
      width: 100%
      object-fit: cover

    &__overlay
      display: flex
      justify-content: center
      align-items: center
      position: absolute
      top: 0
      left: 0
      width: 100%
      height: 100%
      background-color: rgba($black, .6)
      opacity: 0
      transition: opacity .2s ease
      cursor: pointer
</style>
