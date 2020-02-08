<template>
    <v-dialog @click:outside="closePopUp" v-model="params.show" max-width="800">
        <v-card max-width="800">
            <v-card-title class="headline">{{ $i18n.t('import.importTitle') }}</v-card-title>
            <v-container>
                <v-file-input v-model="file"
                              outlined
                              accept="application/json"
                              chips
                              :label="$i18n.t('import.importLabel')">
                </v-file-input>
            </v-container>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="error" @click="closePopUp">{{ $i18n.t('commons.cancel') }}</v-btn>
                <v-btn color="success" @click="importPromoters">{{ $i18n.t('commons.import') }}</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
import { Vue, Component } from 'vue-property-decorator';
import { promoterService } from '@src/services/promoterService'

export default {
    name: 'importPromotersPopUp',
	props: {
        params: Object,
    },
    data: () => ({
        file: null,
	}),
	methods: {
		closePopUp: function() {
            this.file = null;
            this.params.show = false;
        },
        importPromoters: function() {
            if(this.file != null) {
                var formData = new FormData();
                formData.append("promotersImport", this.file);
                promoterService.importPromoters(formData)
                    .then(response => {

                    });
                this.file = null;
                this.params.show = false;
            }
        }
	},
}
</script>

<style lang="scss" scoped>

</style>
