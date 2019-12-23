<template>
	<v-container
		fluid
		grid-list-xl
		class="mainView"
		style="position: relative;"
	>
		<v-dialog v-model="dialog" max-width="600">
			<v-form>
				<v-container style="background-color: #FFFFFF;">
					<v-row>
						<v-col cols="12">
							<v-text-field
								:model="popup.name"
								label="Promoter name"
							></v-text-field>
						</v-col>
					</v-row>
					<v-row>
						<v-col cols="12">
							<v-select
								:items="institutes"
								label="Insitute name"
								:model="popup.institute"
								color="blue"
								style="padding: 0; margin: 0;"
							>
							</v-select>
						</v-col>
						<v-col cols="12">
							<v-select
								:items="degrees"
								label="Degree"
								:model="popup.degree"
								color="blue"
								style="padding: 0; margin: 0;"
							>
							</v-select>
						</v-col>
					</v-row>

					<v-row>
						<v-col cols="12" class="text-center">
							<v-btn
								style="background-color: green; width: 150px; height: 50px; font-size: 24px;"
								class="mx-12"
								text
								color="#FFFFFF"
								@click="dialog = false"
							>
								Save
							</v-btn>
							<v-btn
								style="background-color: red; width: 150px; height: 50px; font-size: 24px;"
								class="mx-12"
								text
								color="#FFFFFF"
								@click="dialog = false"
							>
								Cancel
							</v-btn>
						</v-col>
					</v-row>
				</v-container>
			</v-form>
		</v-dialog>

		<v-btn
			@click="dialog = true"
			style="position: absolute; margin-right: 10px; right: 0px; width: 200px; height: 60px; color: white; background-color: darkblue;"
			>ADD PROMOTER</v-btn
		>
		<v-btn
			style="position: absolute; margin-left: 10px; margin-bottom: 10px; left: 0px; bottom: 0px; width: 200px; height: 60px; color: white; background-color: darkblue;"
			>EXPORT TO EXCEL</v-btn
		>
		<v-row justify="center" style="margin-top: 60px;">
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="items"
					:search="search"
					style="background-color: #FFFFFF;"
				>
					<template v-slot:header.title="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:header.bachelorsTopics="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:header.masterTopics="{ header }">
						<span style="font-size: 30px; color: rgb(18,98,141)">{{
							header.text
						}}</span>
					</template>

					<template v-slot:item.title="{ item }">
						<span style="font-size: 24px; font-weight: bold;">{{
							item.promoter
						}}</span>
					</template>
					<template v-slot:item.bachelorsTopics="{ item }">
						<span style="font-size: 24px; font-weight: bold;">{{
							item.bachelorThesis
						}}</span>
					</template>
					<template v-slot:item.masterTopics="{ item }">
						<span style="font-size: 24px; font-weight: bold;">{{
							item.masterThesis
						}}</span>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class MyProporsals extends Vue {
    public data() {
        return {
            degrees: ['Bachelor', 'Master'],
            institutes: ['Bioinformatics'],
            dialog: '',
            search: '',
            popup: {
                name: '',
                insitute: '',
                degree: '',
            },
            headers: [
                {
                    sortable: false,
                    text: 'Name',
                    value: 'title',
                    width: '40%',
                    align: 'center',
                },
                {
                    sortable: false,
                    text: 'Bachelor topics',
                    value: 'bachelorsTopics',
                    width: '20%',
                    align: 'center',
                },
                {
                    sortable: false,
                    text: 'Master topics',
                    value: 'masterTopics',
                    width: '20%',
                    align: 'center',
                },
                {
                    sortable: false,
                    value: 'empty',
                },
            ],
            items: [
                {
                    promoter: 'Dakota Rice',
                    bachelorThesis: 3,
                    masterThesis: 2,
                    available: 3,
                    type: 'full-time',
                },
                {
                    promoter: 'Dakota Rice',
                    bachelorThesis: 3,
                    masterThesis: 2,
                    available: 3,
                    type: 'full-time',
                },
                {
                    promoter: 'Dakota Rice',
                    bachelorThesis: 3,
                    masterThesis: 2,
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
	background-color: #ffffff;
}

.paintData {
	width: 100%;
	height: 100%;
	border-radius: 0;
}
</style>
