<template>
	<v-container fluid grid-list-xl class="mainView">
		<popup :thesisData="popup">
			<template v-slot:after>
				<v-col cols="12" class="text-center">
					<v-btn
						id="saveButton"
						style="background-color: green;"
						class="formDiv mx-12"
						text
						@click="popup.show = false"
					>
						Save
					</v-btn>
					<v-btn
						id="cancelButton"
						class="formDiv mx-12"
						text
						@click="popup.show = false"
					>
						Cancel
					</v-btn>
				</v-col>
			</template>
		</popup>

		<v-btn @click="popup.show = true" id="addPromoterButton"
			>ADD PROMOTER</v-btn
		>
		<v-row justify="center" class="rowMargin">
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="items"
					:search="search"
					class="whiteBackground"
				>
					<template v-slot:header.title="{ header }">
						<span>{{ header.text }}</span>
					</template>

					<template v-slot:header.bachelorsTopics="{ header }">
						<span>{{ header.text }}</span>
					</template>

					<template v-slot:header.masterTopics="{ header }">
						<span>{{ header.text }}</span>
					</template>

					<template v-slot:item.title="{ item }">
						<span>
							{{ item.promoter }}
						</span>
					</template>
					<template v-slot:item.bachelorsTopics="{ item }">
						<span>
							{{ item.bachelorThesis }}
						</span>
					</template>
					<template v-slot:item.masterTopics="{ item }">
						<span>
							{{ item.masterThesis }}
						</span>
					</template>
				</v-data-table>
			</v-col>
		</v-row>

		<v-btn id="exportDataButton">EXPORT TO EXCEL</v-btn>
	</v-container>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'vue-property-decorator';
import popup from './popup.vue';

@Component({
    components: {
        popup,
    },
})
export default class MyProporsals extends Vue {
    public popup = {
        show: false,
        maxWidth: 600,
        data: {
            title: {
                text: '',
                label: 'Promoter name',
                type: 'editableTextField',
                columns: 12,
            },
            promoter: {
                text: '',
                label: 'Institute name',
                items: ['Bioinformatics', 'Robotics'],
                chosen: '',
                type: 'selectableField',
                columns: 12,
            },
            thesisType: {
                text: '',
                label: 'Degree',
                items: ['Bachelor', 'Master'],
                chosen: '',
                type: 'selectableField',
                columns: 12,
            },
        },
    };
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
	background-color: rgb(255, 255, 255);
}
.whiteBackground {
	background-color: rgb(255, 255, 255);
}
.formDiv {
	color: rgb(255, 255, 255);
	width: 150px;
	height: 50px;
	font-size: 24px;
}
#addPromoterButton {
	float: right;
	margin-right: 10px;
	width: 200px;
	height: 60px;
	color: rgb(255, 255, 255);
	background-color: rgb(0, 0, 139);
}
#exportDataButton {
	margin-left: 10px;
	margin-bottom: 10px;
	width: 200px;
	height: 60px;
	color: rgb(255, 255, 255);
	background-color: rgb(0, 0, 139);
}
#saveButton {
	background-color: rgb(0, 255, 0);
}
#cancelButton {
	background-color: rgb(255, 0, 0);
}
th span {
	font-size: 30px;
	color: rgb(18, 98, 141);
}

td span {
	font-size: 24px;
	font-weight: bold;
}
.rowMargin {
	margin-top: 60px;
}
</style>
