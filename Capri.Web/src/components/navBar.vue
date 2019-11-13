<template>
    <v-navigation-drawer id="app-drawer"
                         src="https://demos.creative-tim.com/vue-material-dashboard/img/sidebar-2.32103624.jpg"
                         app
                         color="grey darken-2"
                         dark
                         floating
                         mobile-break-point="991"
                         persistent
                         width="260">
        <template v-slot:img="attrs">
            <v-img v-bind="attrs"
                   gradient="to top, rgba(0, 0, 0, .7), rgba(0, 0, 0, .7)" />
        </template>

        <v-list-item two-line>
            <v-list-item-avatar color="white">
                <v-img src="https://upload.wikimedia.org/wikipedia/en/b/b3/Pozna%C5%84_University_of_Technology.png"
                       height="34"
                       contain />
            </v-list-item-avatar>

            <v-list-item-title class="title">
                CAPRI
            </v-list-item-title>
        </v-list-item>

        <v-divider class="mx-3 mb-3" />

        <v-list nav>
            <!-- Bug in Vuetify for first child of v-list not receiving proper border-radius -->
            <div />

            <v-list-item v-for="(link, i) in filteredLinks()"
                         :key="i"
                         :to="link.to"
                         active-class="primary white--text">
                <v-list-item-action>
                    <v-icon>{{ link.icon }}</v-icon>
                </v-list-item-action>

                <v-list-item-title v-text="link.text" />
            </v-list-item>
        </v-list>
    </v-navigation-drawer>
</template>
<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator';

    @Component
    export default class NavBar extends Vue {
        public data() {
            return {
                who: 'promoter', // promoter, student or deanery
                // tslint:disable-next-line:object-literal-sort-keys
                links: [
                    {
                        to: '/list/bachelors',
                        // tslint:disable-next-line:object-literal-sort-keys
                        icon: 'mdi-school',
                        text: 'List of bachelor thesis',
                    },
                    {
                        to: '/list/masters',
                        // tslint:disable-next-line:object-literal-sort-keys
                        icon: 'mdi-school-outline',
                        text: 'List of master thesis',
                    },
                    {
                        to: '/myList',
                        // tslint:disable-next-line:object-literal-sort-keys
                        icon: 'mdi-book-open',
                        text: 'My topics',
                    },
                    {
                        to: '/deaneryList',
                        // tslint:disable-next-line:object-literal-sort-keys
                        icon: 'mdi-teach',
                        text: 'List of promoters',
                    },
                ],
                filteredLinks() {
                    const newLinks = [] as any;
                    if (this.who === 'student') {
                        newLinks.push(this.links[0], this.links[1]);
                    } else if (this.who === 'promoter') {
                        newLinks.push(this.links[0], this.links[1], this.links[2]);
                    } else {
                        newLinks.push(this.links[0], this.links[1], this.links[3]);
                    }
                    return newLinks;
                },
            };
        }
    }
</script>
<style lang="scss" scoped>
</style>

