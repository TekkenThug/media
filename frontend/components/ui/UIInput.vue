<template>
  <div :class="['ui-input', { '_error': isError }]">
    <label v-if="label" class="ui-input__label">
      {{ label }}
    </label>

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

    label: {
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

  &__label
    display: inline-block
    padding-left: 10px
    margin-bottom: 5px
    font-weight: 600

  &__field
    width: 100%
    padding: 12px
    outline: none
    border-radius: 9px
    border: 1px solid $gainsboro
    color: inherit
    transition: all .3s ease

    &:focus
      border-color: $slate-blue

    &::placeholder
      opacity: .4
      color: inherit

  &__error
    color: #FF331F
    padding-left: 12px
    font-size: 12px
</style>
