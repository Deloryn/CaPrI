<template>
	<v-container fluid grid-list-xl class="mainView">
		<v-row justify="center">
			<v-col cols="6" class="px-12">
				<v-text-field
					v-model="search"
					append-icon="search"
					label="Type text to filter"
					single-line
					hide-details
				></v-text-field>
			</v-col>
			<v-col cols="4" class="px-12"></v-col>
			<v-col cols="2">
				<v-btn color="primary">ADD PROMOTER</v-btn>
			</v-col>

			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="items"
					:search="search"
					style="background-color: #FFFFFF;"
				>
					<template v-slot:item.action="{ item }">
						<v-icon>mdi-pen</v-icon>
						<v-icon>mdi-delete</v-icon>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';

@Component
export default class DeaneryView extends Vue {
    public data() {
        return {
            search: '',
            headers: [
                {
                    sortable: false,
                    text: 'Name',
                    value: 'name',
                },
                {
                    sortable: false,
                    text: 'Institute',
                    value: 'institute',
                },
                {
                    sortable: false,
                    text: "Can be promoter of bachelor's thesis?",
                    value: 'can',
                },
                {
                    sortable: false,
                    text: 'Actions',
                    value: 'action',
                },
            ],
            items: [
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'no',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Jan Szczuka',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Dakota Rice',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Minerva Hooper',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Sage Rodriguez',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Philip Chanley',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
                {
                    name: 'Doris Greene',
                    institute: 'Insitute of computer science',
                    can: 'no',
                },
                {
                    name: 'Mason Porter',
                    institute: 'Insitute of computer science',
                    can: 'yes',
                },
            ],
        };
    }
    private setColor(available, taken): string {
        let color = 'green';
        if (taken > 0) {
            color = 'yellow';
        }
        if (taken === available) {
            color = 'red';
        }
        return color;
    }
    private setState(available, taken): string {
        let state = 'Free';
        if (taken === available) {
            state = 'Taken';
        } else if (taken > 0) {
            state = 'Partially taken';
        }

        return state;
    }
}
</script>
<style scoped>
.mainView {
	width: calc(100% - 340px);
	margin-left: 270px;
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
