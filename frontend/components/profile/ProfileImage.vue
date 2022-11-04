<template>
  <div class="profile-image">
    <img :src="src" alt="">

    <div class="profile-image__overlay">
      <v-icon color="#fff">
        mdi-image
      </v-icon>

      <input
        type="file"
        accept="image/jpeg, image/png, image/jpg"
        @change="uploadImage"
      >
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
    uploadImage ({ target }) {
      if (target.files && target.files[0]) {
        // send blob

        const reader = new FileReader()

        reader.addEventListener('load', () => {
          this.$emit('updateImage', reader.result)
        }, { once: true })

        reader.readAsDataURL(target.files[0])
      }
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/_variables.sass"

  .profile-image
    $borderRadius: 50%

    position: relative
    width: 128px
    height: 128px
    border-radius: 50%
    border: 1px solid $gainsboro
    overflow: hidden

    &:hover
      .profile-image__overlay
        opacity: 1

    img
      width: 100%
      height: 100%
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
      border-radius: $borderRadius
      background-color: rgba($black, .6)
      opacity: 0
      transition: opacity .2s ease
      cursor: pointer

      input[type="file"]
        position: absolute
        top: 0
        left: 0
        display: block
        width: 100%
        height: 100%
        border-radius: $borderRadius
        opacity: 0
        cursor: pointer
</style>
