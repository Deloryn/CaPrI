<template>
    <v-card-actions class="mainCard">
        <div class="sentence">{{ listType }}</div>
        <v-spacer></v-spacer>
        <router-link to="/" style="text-decoration: none;"><v-icon class="icon">person</v-icon></router-link>
    </v-card-actions>
</template>

<script lang="ts">
    import { Vue, Component, Prop } from 'vue-property-decorator';

    @Component
    export default class TopBar extends Vue {
        public data() {
            return {
                listType: 'List of ' + this.$route.params.type,
            };
        }
    }
</script>
<style lang="scss" scoped>
.mainCard{
	margin-left: 260px;
	width: calc(100% - 260px);
	padding-left: 10px;
	padding-right: 10px;
	padding-top: 25px;
}
.sentence{
	font-size: 30px;
	color: gray;
}
.icon{
	font-size: 30px;
	margin-right: 20px;
}
</style>
