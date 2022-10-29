<template>
  <div class="ui-input">
    <input
      :value="value"
      type="text"
      class="ui-input__field"
      :placeholder="placeholder"
      @change="$emit('change', $event.target.value)"
    >
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
    }
  }
}
</script>

<style lang="sass" scoped>
.ui-input
  border-radius: 9px
  border: 2px solid #fff

  &__field
    width: 100%
    padding: 12px 20px
    outline: none
    color: inherit

    &::placeholder
      color: #fff
</style>
