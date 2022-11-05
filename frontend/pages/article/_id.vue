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

    <LayoutIsland shadowed>
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
  </article>
</template>

<script>
import { pluralize } from '@/utils/string'
import LayoutIsland from '@/components/layouts/LayoutIsland'
import UITextarea from '@/components/ui/UITextarea'
import CommentItem from '@/components/comments/CommentItem'
import ArticleHeaderBlock from '@/components/article/blocks/ArticleHeaderBlock'
import ArticleParagraphBlock from '@/components/article/blocks/ArticleParagraphBlock'

export default {
  name: 'ArticlePage',

  components: {
    LayoutIsland,
    UITextarea,
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
      comments: article.comments
    }
  },

  data () {
    return {
      blocks: [],
      publicationTimestamp: 0,
      commentsCount: 0,

      commentText: '',
      comments: [],
      commentIsSending: false
    }
  },

  computed: {
    commentsTitle () {
      return pluralize(this.commentsCount, ['комментарий', 'комментария', 'комментариев'])
    },

    isAuth () {
      return this.$store.state.user.isAuth
    }
  },

  methods: {
    sendComment () {
      this.commentIsSending = true

      setTimeout(() => {
        this.commentIsSending = false
        this.commentText = ''
      }, 2000)
    }
  }
}
</script>

<style lang="sass" scoped>
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
      color: #fff
</style>
