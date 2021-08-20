import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import Users from '../assets/js/users';

Vue.use(VueRouter);

const routes = [
	{
		path: '/',
		name: 'Home',
		component: Home,
		meta: {
			requiresAuth: true
		}
	},
	{
		path: '/login',
		name: 'Login',
		component: () => import(/* webpackChunkName: "about" */ '../views/Login.vue')
	},
	{
		path: '/register',
		name: 'Register',
		// route level code-splitting
		// this generates a separate chunk (about.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "about" */ '../views/Register.vue')
	}
];

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes
});

router.beforeEach(async (to, from, next) => {
	if(to.matched.some(record => record.meta.requiresAuth)) {
        if (await Users.AuthenticateUser() === false) {
            next({
                path: '/login',
                params: { nextUrl: to.fullPath }
            });
        }
		else{
			next();
		}
    }
	else {
        if (await Users.AuthenticateUser() === true){
			next({
                path: '/',
                params: { nextUrl: to.fullPath }
            });
		}
		else {
			next();
		}
    }
});

export default router;