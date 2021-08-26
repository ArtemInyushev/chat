import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

async function AuthenticateUser() {
	try {
		const res = await fetch("https://localhost:44360/api/Users/Authenticate", {
			credentials: "include",
		});
		const status = res.status;
		if (status === 200) {
			return true;
		}
		else if (status !== 401) {
			console.log("Something went wrong");
		}
	}
	catch(error) {
		console.log(error);
	}
	return false;
}

const routes = [
	{
		path: '/',
		name: 'Home',
		components: {
			default: () => import('../views/Home.vue'),
			left: () => import('../components/main/LeftHeader.vue'),
			right: () => import('../components/main/RightHeader.vue'),
		},
		meta: {
			requiresAuth: true
		}
	},
	{
		path: '/login',
		name: 'Login',
		components: {
			default: () => import('../views/Login.vue'),
			left: "",
			right: "",
		}
	},
	{
		path: '/register',
		name: 'Register',
		components: {
			default: () => import('../views/Register.vue'),
			left: () => import('../components/register/LeftHeader.vue'),
			right: "",
		}
	},
];

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
});

router.beforeEach(async (to, from, next) => {
	if(to.matched.some(record => record.meta.requiresAuth)) {
        if (await AuthenticateUser() === false) {
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
        if (await AuthenticateUser() === true){
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