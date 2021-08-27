import Vue from 'vue';
import App from './App.vue';
import router from './router';
import VueSignalR from 'vue-signalr'

Vue.use(VueSignalR, 'https:///localhost:44360/chat');
Vue.config.productionTip = false; 

new Vue({
    router,
    render: h => h(App)
}).$mount('#app')
