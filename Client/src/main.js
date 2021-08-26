import Vue from 'vue';
import Vuex from 'vuex'
import App from './App.vue';
import router from './router';

Vue.use(Vuex);
Vue.config.productionTip = false;

const store = new Vuex.Store({
	state: {
		username: localStorage.getItem("username"),
		email: localStorage.getItem("email"),
		logoUrl: localStorage.getItem("logoUrl"),
	},
	mutations: {
		setUsername(state, username) {
			state.username = username;
		},
		setEmail(state, email) {
			state.email = email;
		},
		setLogoUrl(state, logoUrl) {
			state.logoUrl = logoUrl;
		},
	},
});
 

new Vue({
    router,
    store: store,
    render: h => h(App)
}).$mount('#app')
