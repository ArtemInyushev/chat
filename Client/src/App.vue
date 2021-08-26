<template>
	<div id="app" class="fullsize">
		<header>
			<section class="left_header">
				<router-view name="left" />
			</section>
			<Logo />
			<section class="right_header">
				<router-view name="right" />
			</section>
		</header>
		<Toasts />
		<router-view />
	</div>
</template>

<script>
import Toasts from '@/components/Toasts.vue';
import Logo from '@/components/Logo.vue';

export default {
	name: "App",
	components: {
		Toasts,
		Logo,
	},
}
</script>