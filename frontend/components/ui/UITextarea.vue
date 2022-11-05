<template>
  <textarea
    class="ui-textarea"
    :value="value"
    :placeholder="placeholder"
    @input="handleInput"
  />
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
      target.style.height = '64px'
      target.style.height = (target.scrollHeight) + 'px'
    }
  }
}
</script>

<style lang="sass">
  @import "assets/sass/variables"

  .ui-textarea
    width: 100%
    padding: 12px
    resize: none
    border-radius: 9px
    outline: 1px solid $gainsboro
    background-color: $cultured
    // transition: height .2s linear
    // outline: none
    -webkit-box-shadow: none
    -moz-box-shadow: none
    box-shadow: none
    transition: outline .2s ease

    &:focus
      outline: 3px solid $slate-blue
</style>
