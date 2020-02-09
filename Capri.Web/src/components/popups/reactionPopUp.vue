<template>
    <v-snackbar v-model="dialog" top vertical :color="color" :timeout="timeout">
        <span class="title">{{ this.message }}</span>
        <v-btn color="black" text @click="cancel">
            {{ $i18n.t('commons.close') }}
        </v-btn>
    </v-snackbar>
</template>

<script>
export default {
    name: 'reactionPopUp',
    data: () => ({
        dialog: false,
        resolve: null,
        reject: null,
        statusCode: null,
        color: 'primary',
        message: '',
        timeout: 4000
    }),
    methods: {
        open(statusCode) {
            this.dialog = true;
            this.statusCode = statusCode;
            this.setColorMessage(statusCode);
        },
        cancel() {
            this.dialog = false
        },
        setColorMessage: function(statusCode) {
            if(statusCode >= 200 && statusCode < 300) {
                this.color = 'success'
                this.message = this.$i18n.t('reaction.success')
            } else if (statusCode >= 300 && statusCode < 400) {
                this.color = 'warning'
                this.message = this.$i18n.t('reaction.otherError')
            } else if (statusCode == 400) {
                this.color = 'error'
                this.message = this.$i18n.t('reaction.badRequest')
            } else if (statusCode == 401) {
                this.color = 'error'
                this.message = this.$i18n.t('reaction.unauthorized')
            } else if (statusCode == 403) {
                this.color = 'error'
                this.message = this.$i18n.t('reaction.forbidden')
            } else if (statusCode == 404) {
                this.color = 'error'
                this.message = this.$i18n.t('reaction.notFound')
            } else if (statusCode >= 400 && statusCode < 500) {
                this.color = 'error'
                this.message = this.$i18n.t('reaction.otherError')
            } else {
                this.color = 'error'
                this.message = this.$i18n.t('reaction.serverError')
            }
        }
    }
}
</script>