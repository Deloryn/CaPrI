<template>
	<v-select
		:items="params.items"
		:model="params.chosen"
		:label="params.label"
		:disabled="params.disabled"
		return-object
		color="rgb(18,98,141)"
	>
		<template slot="selection" slot-scope="data">
			{{ data.item.name }}
		</template>
		<template slot="item" slot-scope="data">
			{{ data.item.name }}
		</template>
	</v-select>
</template>
<script>
import { bus } from '@src/services/eventBus'

export default {
	name: 'selectableField',
	props: {
		params: Object
	}
}
</script>
<style lang="scss" scoped>
</style>

