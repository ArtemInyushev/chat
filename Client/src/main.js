import Vue from 'vue';
//import Vuex from 'vuex'
import App from './App.vue';
import router from './router';
import VueSignalR from 'vue-signalr'

//Vue.use(Vuex);
Vue.use(VueSignalR, 'SOCKET_URL');
Vue.config.productionTip = false; 

new Vue({
    router,
    render: h => h(App)
}).$mount('#app')
