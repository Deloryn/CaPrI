<template>
    <v-container fluid
                 grid-list-xl
                 class="mainView">
        <v-file-input label="File input" v-model="file" style="width: 60%;"></v-file-input>
        <v-row justify="center">
            <v-col cols="12">
                <v-data-table :headers="headers"
                              :items="items"
                              :search="search"
                              style="background-color: #FFFFFF;">

                    <template v-slot:header.name="{ header }">
                        <span style="font-size: 30px; color: rgb(18,98,141)">{{ header.text }}</span>
                    </template>

                    <template v-slot:header.laboratory="{ header }">
                        <span style="font-size: 30px; color: rgb(18,98,141)">{{ header.text }}</span>
                    </template>

                    <template v-slot:header.bachelorTopics="{ header }">
                        <span style="font-size: 30px; color: rgb(18,98,141)">{{ header.text }}</span>
                    </template>

                    <template v-slot:header.masterTopics="{ header }">
                        <span style="font-size: 30px; color: rgb(18,98,141)">{{ header.text }}</span>
                    </template>

                    <template v-slot:item.name="{ item }">
                        <span style="float: left; font-size: 24px; font-weight: bold;">{{ item.title }}</span>
                    </template>
                    <template v-slot:item.promoter="{ item }">
                        <span style="float: left; font-size: 24px; font-weight: bold;">{{ item.thesis }}</span>
                    </template>
                    <template v-slot:item.freeSlots="{ item }">
                        <span style="float: left; font-size: 24px; font-weight: bold;">{{ item.taken }}</span>
                    </template>

                </v-data-table>
            </v-col>

        </v-row>
    </v-container>
</template>
<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator';

    @Component
    export default class CardsView extends Vue {
        public data() {
            return {
                search: '',
                headers: [
                    {
                        sortable: false,
                        text: 'Name',
                        value: 'name',
                        width: '30%',
                        align: 'center',
                    },
                    {
                        sortable: false,
                        text: 'Laboratory',
                        value: 'laboratory',
                        width: '20%',
                        align: 'center',
                    },
                    {
                        sortable: false,
                        text: 'Bachelor topics',
                        value: 'bachelorTopics',
                        width: '20%',
                        align: 'center',
                    },
                    {
                        sortable: false,
                        text: 'Master Topics',
                        value: 'masterTopics',
                        width: '20%',
                        align: 'center',
                    },
                    {}
                ],
                items: [
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Bachelor',
                        taken: 1,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Bachelor',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Jan Szczuka',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Dakota Rice',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Minerva Hooper',
                        thesis: 'Bachelor',
                        taken: 3,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Sage Rodriguez',
                        thesis: 'Master',
                        taken: 0,
                        available: 3,
                        type: 'full-time',
                    },
                    {
                        title: 'Philip Chanley',
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
    }
</script>
<style scoped>
    .mainView {
        width: calc(100% - 370px);
        margin-left: 350px;
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