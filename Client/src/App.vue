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

<style>
article.content {
    width: 100%;
    height: 85%;
}


article.content_flex {
    width: 100%;
    display: inline-flex;
    height: 100%;
}

section.left_header {
    height: 100%;
    width: 15%;
    display: flex;
    align-items: center;
    justify-content: center;
}

section.name {
    height: 100%;
    width: 70%;
    display: flex;
    align-items: center;
    justify-content: center;
}

section.right_header {
    height: 100%;
    width: 15%;
    display: flex;
    align-items: center;
    justify-content: center;
}

section.half_size {
    width: 50%;
    height: 100%;
}

section.login_form {
    height: 55%;
    width: 25%;
    margin-left: auto;
    margin-right: auto;
    margin-top: 50px;
}

section.create_form {
    height: 85%;
    width: 70%;
    margin-left: auto;
    margin-right: auto;
    margin-top: 50px;
}

div.fullsize {
    height: 100%;
    width: 100%;
}

.float_right {
    float: right
}

.blackground {
    background-color: black;
}

.darkground, ul.dropdown-menu, .form-check input:checked {
    background-color: rgba(20, 20, 20, 1);
}

.turquoise {
    color: rgba(44, 210, 240, 0.596);
}

.lightgrey {
    color: lightgrey;
}

.white, button.white_text {
    color: white;
}

.centered_text {
    text-align: center;
}

.create_header {
    margin-left: auto;
    margin-right: auto;
    margin-top: 20%;
}

.margin_bottom {
    margin-bottom: 10px;
}

.margin_top {
    margin-top: 30px;
}

.flex {
    display: flex;
}

label.inline {
    margin-top: 15px;
    margin-bottom: 15px;
    display: flex;
    flex-direction: row;
}

label.inline:before, label.inline:after {
    content: "";
    flex: 1 1;
    border-bottom: 0.5px solid rgba(44, 210, 240, 0.596);
    margin: auto;
}

img.login {
    height: 30%;
    display: block;
    margin-left: auto;
    margin-right: auto;
    margin-top: 20px;
}

img.rounded_img {
    height: 100%;
    border-radius: 30px;
}

input.input_form {
    width: 100%;
    height: 50px;
    border: none;
    border-bottom: 1px solid white;
}

input.input_form:focus {
    outline: none;
    border-bottom: 1px solid rgba(44, 210, 240, 0.596);
}

input:-webkit-autofill,
input:-webkit-autofill:hover,
input:-webkit-autofill:focus,
textarea:-webkit-autofill,
textarea:-webkit-autofill:hover,
textarea:-webkit-autofill:focus,
select:-webkit-autofill,
select:-webkit-autofill:hover,
select:-webkit-autofill:focus {
    -webkit-text-fill-color: white !important;
    transition: background-color 50000s;
}

a:hover {
    cursor: pointer;
}
</style>

<style scoped>
html {
    height: 100%;
}

body {
    height: 100%;
    margin: 0;
    overflow: hidden;
}

header {
    height: 15%;
    width: 100%;
    display: inline-flex;
    border-bottom: 2px solid rgba(44, 210, 240, 0.596);
}
</style>