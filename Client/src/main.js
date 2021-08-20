import Vue from 'vue';
import App from './App.vue';
import router from './router';
import LoadScript from 'vue-plugin-load-script';

import './assets/css/styles.css';

Vue.config.productionTip = false;
Vue.use(LoadScript);

Vue.loadScript("/toasts.js");

new Vue({
    router,
    render: h => h(App)
}).$mount('.content')
