<template>
	<v-container fluid grid-list-xl class="mainView">
		<popUp :thesisData="popUp">
			<template v-slot:after>
				<v-col cols="12" class="text-center">
					<v-btn
						id="saveButton"
						style="background-color: green;"
						class="formDiv mx-12"
						text
						@click="popUp.show = false"
					>
						Save
					</v-btn>
					<v-btn
						id="cancelButton"
						class="formDiv mx-12"
						text
						@click="popUp.show = false"
					>
						Cancel
					</v-btn>
				</v-col>
			</template>
		</popUp>

		<v-btn @click="popUp.show = true" id="addPromoterButton"
			>ADD PROMOTER</v-btn
		>
		<v-row justify="center" class="rowMargin">
			<v-col cols="12">
				<v-data-table
					:headers="headers"
					:items="promoters"
					:search="search"
					class="whiteBackground"
				>
					<template v-slot:header.title="{ header }">
						<span>{{ header.text }}</span>
					</template>

					<template v-slot:header.expectedNumberOfBachelorProposals="{ header }">
						<span>{{ header.text }}</span>
					</template>

					<template v-slot:header.expectedNumberOfMasterProposals="{ header }">
						<span>{{ header.text }}</span>
					</template>

					<template v-slot:item.title="{ item }">
                        <span>
                            {{ item.titlePrefix }} {{item.firstName}} {{item.lastName}}<span v-if="item.titlePostfix!==''">, </span>
                             {{item.titlePostfix}}
                        </span>
					</template>
					<template v-slot:item.expectedNumberOfBachelorProposals="{ item }">
                        <span>
                            {{ item.expectedNumberOfBachelorProposals }}
                        </span>
					</template>
					<template v-slot:item.expectedNumberOfMasterProposals="{ item }">
                        <span>
                            {{ item.expectedNumberOfMasterProposals }}
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
import popUp from './popUp.vue';
import { promoterService } from '@src/services/promoterService'

@Component({
    components: {
        popUp,
    },
})
export default class MyProporsals extends Vue {
    public promoters = [{"id":"","titlePrefix":"","titlePostfix":"","firstName":"Loading data…","lastName":"","expectedNumberOfBachelorProposals":0,"expectedNumberOfMasterProposals":0,"proposals":[""],"userId":"","instituteId":""}];
    public getData() {
        promoterService.getAll()
        .then((response) => {
            this.promoters = response.data
        })
    };
    public dane = this.getData();
    public popUp = {
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
            popUp: {
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
                    value: 'expectedNumberOfBachelorProposals',
                    width: '20%',
                    align: 'center',
                },
                {
                    sortable: false,
                    text: 'Master topics',
                    value: 'expectedNumberOfMasterProposals',
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
                    expectedNumberOfBachelorProposals: 3,
                    expectedNumberOfMasterProposals: 2,
                    available: 3,
                    type: 'full-time',
                },
                {
                    promoter: 'Dakota Rice',
                    expectedNumberOfBachelorProposals: 3,
                    expectedNumberOfMasterProposals: 2,
                    available: 3,
                    type: 'full-time',
                },
                {
                    promoter: 'Dakota Rice',
                    expectedNumberOfBachelorProposals: 3,
                    expectedNumberOfMasterProposals: 2,
                    available: 3,
                    type: 'full-time',
                },
            ],
        };
    }
}
</script>
<style lang="scss" scoped>
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
