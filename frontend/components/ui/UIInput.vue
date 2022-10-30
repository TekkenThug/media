<template>
  <div :class="['ui-input', { '_error': isError }]">
    <input
      :value="value"
      :type="type"
      class="ui-input__field"
      :placeholder="placeholder"
      @input="$emit('input', $event.target.value)"
    >

    <transition name="fade">
      <div v-if="isError" class="ui-input__error">
        {{ errorText }}
      </div>
    </transition>
  </div>
</template>

<script>
export default {
  name: 'UIInput',

  props: {
    value: {
      type: String,
      default: ''
    },

    placeholder: {
      type: String,
      default: ''
    },

    type: {
      type: String,
      default: 'text'
    },

    isError: {
      type: Boolean,
      default: false
    },

    errorText: {
      type: String,
      default: ''
    }
  }
}
</script>

<style lang="sass">
@import "assets/sass/variables"

.ui-input
  &._error
    .ui-input__field
      border-color: #FF331F

  &__field
    width: 100%
    padding: 12px
    outline: none
    border-radius: 9px
    border: 2px solid $black
    color: inherit
    transition: all .3s ease

    &::placeholder
      opacity: .4
      color: inherit

  &__error
    color: #FF331F
    padding-left: 12px
    font-size: 12px
</style>
