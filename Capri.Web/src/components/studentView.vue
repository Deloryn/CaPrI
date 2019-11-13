<template>
    <v-container fluid
                 grid-list-xl
                 class="mainView">
        <v-row justify="center">

            <v-col cols="12" class="px-12">
                <v-text-field v-model="search"
                              append-icon="search"
                              label="Type text to filter"
                              single-line
                              hide-details></v-text-field>
            </v-col>

            <v-col cols="12">
                <v-data-table :headers="headers"
                              :items="items"
                              :search="search"
                              style="background-color: #FFFFFF;">

                    <template v-slot:item.status="{ item }">
                        <v-chip :color="setColor(item.available,item.taken)" class="paintData">{{ setState(item.available,item.taken) }}</v-chip>
                    </template>
                    <template v-slot:item.available="{ item }">
                        {{ item.taken }}/{{ item.available }}
                    </template>

                </v-data-table>
            </v-col>

        </v-row>
    </v-container>
</template>
<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator';

    @Component
    export default class StudentView extends Vue {
        public data() {
            return {
                search: '',
                // tslint:disable-next-line:object-literal-sort-keys
                headers: [
                    {
                        sortable: false,
                        text: 'Title',
                        value: 'title',
                        width: '40%',
                    },
                    {
                        sortable: false,
                        text: 'Promoter',
                        value: 'thesis',
                    },
                    {
                        sortable: false,
                        text: 'State',
                        value: 'status',
                    },
                    {
                        sortable: false,
                        text: 'Number of students',
                        value: 'available',
                    },
                    {
                        sortable: false,
                        text: 'Study type',
                        value: 'type',
                    },
                ],
                items: [
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 1,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Jan Szczuka',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Minerva Hooper',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 3,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Sage Rodriguez',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Philip Chanley',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 2,
                        available: 3,
                        type: 'part-time',
                    },
                    {
                        title: 'Doris Greene',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'part-time',
                    },
                    {
                        title: 'Mason Porter',
                        // tslint:disable-next-line:object-literal-sort-keys
                        thesis: 'Bachelor',
                        taken: 2,
                        available: 3,
                        type: 'full-time',
                    },
                ],
            };
        }
        public setColor(available, taken): string {
            let color = 'green';
            if (taken > 0) { color = 'yellow'; }
            if (taken === available) { color = 'red'; }
            return color;
        }
        public setState(available, taken): string {
            let state = 'Free';
            if (taken > 0) { state = 'Partially taken'; }
            if (taken === available) { state = 'Taken'; }
            return state;
        }
    }
</script>
<style scoped>
    .mainView {
        width: calc(100% - 280px);
        margin-left: 270px;
        margin-right: 10px;
        margin-top: 0px;
        margin-bottom: 0px;
        background-color: #FFFFFF;
    }

    .paintData {
        width: 100%;
        height: 100%;
        border-radius: 0;
    }
</style>