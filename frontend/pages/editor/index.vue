<template>
  <section class="editor">
    <div id="editorjs" class="editor__wrapper" />
  </section>
</template>

<script>
import EditorJS from '@editorjs/editorjs'
import Header from '@editorjs/header'
import ImageTool from '@editorjs/image'

export default {
  name: 'EditorPage',

  middleware: 'authenticated',

  data () {
    return {
      editorInstance: null
    }
  },

  mounted () {
    this.editorInstance = new EditorJS({
      tools: {
        header: {
          class: Header,
          inlineToolbar: ['link']
        },
        image: {
          class: ImageTool,
          config: {
            endpoints: {
              byFile: 'http://localhost:8008/uploadFile',
              byUrl: 'http://localhost:8008/fetchUrl'
            }
          }
        }
      }
    })
  }
}
</script>

<style lang="sass" scoped>
.editor
  padding-top: 16px

  &__wrapper
    padding: 24px
    border-radius: 12px
    background-color: #fff
</style>
