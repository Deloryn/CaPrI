<template>

                    <div id="promoterBar">
                        <v-list-item v-for="(link, i) in links"
                                     :key="i"
                                     :to="link.to"
                                     active-class="primary white--text" style="margin: 0; padding: 0; border-radius: 0; height: 80px;">
                            <v-list-item-action style="margin: 0; padding: 0;" class="px-3">
                                <v-icon>{{ link.icon }}</v-icon>
                            </v-list-item-action>

                            <v-list-item-title v-text="link.text" />
                        </v-list-item>
                    </div>

</template>
<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator';

    @Component
    export default class NavPromoterItems extends Vue {
        public data() {
            return {
                links: [
                    {
                        to: '/myProporsals',
                        icon: 'mdi-book-open',
                        text: 'My proporsal',
                    },
                    {
                        to: '/cards',
                        icon: 'mdi-school-outline',
                        text: 'List of thesis',
                    },
                ],
            };
        }
    }
</script>
<style lang="scss" scoped>
div .v-list-item__title{
    font-size: 24px;
    font-weight: bold;
}
</style>

