<template>
  <article class="article">
    <LayoutIsland class="article__content" shadowed>
      <div
        v-for="block in blocks"
        :key="block.id"
        class="article__content-block"
      >
        <ArticleHeaderBlock
          v-if="block.type === 'header'"
          :level="block.data.level"
          :text="block.data.text"
        />

        <ArticleParagraphBlock
          v-else-if="block.type === 'paragraph'"
          :text="block.data.text"
        />
      </div>
    </LayoutIsland>

    <div v-if="draft && isEditor" class="article__draft-section">
      <v-btn class="accept" @click="resolveDraft('accept')">
        Опубликовать
      </v-btn>

      <v-btn class="decline" @click="resolveDraft('decline')">
        Отклонить
      </v-btn>
    </div>

    <LayoutIsland v-else shadowed>
      <h3 class="article__comments-count">
        {{ commentsTitle }}
      </h3>

      <UITextarea
        v-if="isAuth"
        v-model="commentText"
        placeholder="Напишите комментарий"
      >
        <v-btn
          color="#6665DD"
          class="article__comments-publish-btn"
          :disabled="!commentText"
          :loading="commentIsSending"
          @click="sendComment"
        >
          Отправить
        </v-btn>
      </UITextarea>

      <div class="article__comments-list">
        <CommentItem
          v-for="(item, index) in comments"
          :key="index"
          class="article__comments-item"
          :author="item.author"
          :avatar="item.avatar"
          :text="item.text"
        />
      </div>
    </LayoutIsland>

    <Modal
      name="article-decline"
      adaptive
      height="auto"
    >
      <ModalArticleDecline @success="closeDeclineModal" />
    </Modal>
  </article>
</template>

<script>
import { pluralize } from '@/utils/string'
import LayoutIsland from '@/components/layouts/LayoutIsland'
import UITextarea from '@/components/ui/UITextarea'
import ModalArticleDecline from '@/components/modals/modal-article-decline'
import CommentItem from '@/components/comments/CommentItem'
import ArticleHeaderBlock from '@/components/article/blocks/ArticleHeaderBlock'
import ArticleParagraphBlock from '@/components/article/blocks/ArticleParagraphBlock'

export default {
  name: 'ArticlePage',

  components: {
    LayoutIsland,
    UITextarea,
    ModalArticleDecline,
    CommentItem,
    ArticleHeaderBlock,
    ArticleParagraphBlock
  },

  async asyncData ({ $axios, redirect, params }) {
    if (!params.id) {
      redirect('/')
    }

    const { data: { article } } = await $axios.get(`/article/${params.id}`)

    return {
      blocks: article.blocks,
      publicationTimestamp: article.time,
      commentsCount: article.commentsCount,
      comments: article.comments,
      draft: article.draft
    }
  },

  data () {
    return {
      blocks: [],
      publicationTimestamp: 0,
      commentsCount: 0,

      commentText: '',
      comments: [],
      commentIsSending: false,

      draft: false
    }
  },

  computed: {
    commentsTitle () {
      return pluralize(this.commentsCount, ['комментарий', 'комментария', 'комментариев'])
    },

    isAuth () {
      return this.$store.state.user.isAuth
    },

    isEditor () {
      return this.$store.state.user.role === 'editor'
    }
  },

  methods: {
    sendComment () {
      this.commentIsSending = true

      setTimeout(() => {
        this.commentIsSending = false
        this.commentText = ''
      }, 2000)
    },

    resolveDraft (resolve) {
      if (resolve === 'accept') {
        this.$notify({
          type: 'success',
          title: 'Статья опубликована'
        })

        this.$router.push('/publications')
      } else {
        this.$modal.show('article-decline')
      }
    },

    closeDeclineModal () {
      this.$modal.hide('article-decline')
      this.$notify({
        type: 'success',
        title: 'Статья отклонена'
      })
      this.$router.push('/publications')
    }
  }
}
</script>

<style lang="sass" scoped>
  @import "assets/sass/variables"

  .article
    &__content
      margin-bottom: 24px

    &__content-block
      & + &
        margin-top: 16px

    &__comments-count
      margin-bottom: 18px

    &__comments-list
      margin-top: 24px

    &__comments-item
      & + &
        margin-top: 24px

    &__comments-publish-btn
      color: $white

    &__draft-section
      display: flex

      .accept,
      .decline
        color: $white

      .accept
        margin-left: auto
        background-color: $may-green

      .decline
        margin-left: 5px
        background-color: $upsdellRed
</style>
