<template>
  <div class="ui-textarea">
    <textarea
      :class="['ui-textarea__field', { '_pb': $slots.default }]"
      :value="value"
      :placeholder="placeholder"
      :style="{
        height: $slots.default ? '104px' : '64px'
      }"
      @input="handleInput"
    />

    <div v-if="$slots.default" class="ui-textarea__bottom">
      <slot />
    </div>
  </div>
</template>

<script>
export default {
  name: 'UITextarea',

  props: {
    placeholder: {
      type: String,
      default: ''
    },

    value: {
      type: String,
      default: ''
    }
  },

  methods: {
    handleInput (event) {
      this.$emit('input', event.target.value)

      this.changeHeight(event)
    },

    changeHeight ({ target }) {
      target.style.height = this.$slots.default ? '104px' : '64px'
      target.style.height = (target.scrollHeight) + 'px'
    }
  }
}
</script>

<style lang="sass">
  @import "assets/sass/variables"

  .ui-textarea
    position: relative

    &__field
      width: 100%
      padding: 12px
      resize: none
      border-radius: 9px
      outline: 1px solid $gainsboro
      background-color: $cultured
      -webkit-box-shadow: none
      -moz-box-shadow: none
      box-shadow: none
      transition: outline .2s ease

      &._pb
        padding-bottom: 60px

      &:focus
        outline: 3px solid $slate-blue

    &__bottom
      display: flex
      flex-direction: row-reverse
      position: absolute
      bottom: 12px
      left: 12px
      right: 12px
      height: 40px
</style>
