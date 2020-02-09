<template>
    <v-dialog v-model="dialog" :max-width="options.width" :style="{ zIndex: options.zIndex }">
        <v-card>
            <v-toolbar dark :color="options.color" dense flat>
                <v-toolbar-title class="white--text">{{ title }}</v-toolbar-title>
            </v-toolbar>
            <v-card-text v-show="!!message" class="pa-5">{{ message }}</v-card-text>
            <v-card-actions class="pt-0">
                <v-spacer></v-spacer>
                <v-btn color="error" text @click.native="agree">{{ $i18n.t('commons.delete') }}</v-btn>
                <v-btn color="primary" text @click.native="cancel">{{ $i18n.t('commons.cancel') }}</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
export default {
    name: 'confirmationPopUp',
    data: () => ({
        dialog: false,
        resolve: null,
        reject: null,
        message: null,
        title: null,
        options: {
            color: 'primary',
            width: 400,
            zIndex: 200
        }
    }),
    methods: {
        open(title, message, options) {
            this.dialog = true
            this.title = title
            this.message = message
            this.options = Object.assign(this.options, options)
            return new Promise((resolve, reject) => {
                this.resolve = resolve
                this.reject = reject
            })
        },
        agree() {
            this.resolve(true)
            this.dialog = false
        },
        cancel() {
            this.resolve(false)
            this.dialog = false
        }
    }
}
</script>