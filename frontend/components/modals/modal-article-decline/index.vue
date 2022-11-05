<template>
  <div class="modal-article-decline">
    <h3 class="modal-article-decline__title">
      Опишите причину отказа
    </h3>

    <UITextarea
      v-model="reason"
      placeholder="Причина"
      class="modal-article-decline__textarea"
    />

    <v-btn
      class="modal-article-decline__btn"
      :disabled="!reason"
      color="#6665DD"
      @click="$emit('success')"
    >
      Отправить
    </v-btn>
  </div>
</template>

<script>
import UITextarea from '@/components/ui/UITextarea'

export default {
  name: 'ModalArticleDecline',

  components: { UITextarea },

  data () {
    return {
      reason: ''
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/variables"

  .modal-article-decline
    &__title
      margin-bottom: 12px

    &__textarea
      margin-bottom: 12px

    &__btn
      margin-left: auto
      color: $white
</style>
