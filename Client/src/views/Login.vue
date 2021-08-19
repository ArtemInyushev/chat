<template>
    <div class="fullsize">
        <header>
            <section class="left_header"></section>
    
            <section class="name">
                <h1 class="display-2 turquoise">My chat</h1>
            </section>
    
            <section class="right_header"></section>
        </header>

        <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627071932/Chat/lock_inmjg5.jpg" class="login" />

        <section class="login_form">
            <form @submit="LoginUser">
                <h1 class="display-4 centered_text white">Login</h1>

                <input type="text" v-model="name" class="input_form blackground white margin_bottom" 
                    placeholder="Username..." maxlength="30" required>
                <input type="password" v-model="password" class="input_form blackground white margin_bottom" 
                    placeholder="Password..." maxlength="30" required>

                <div class="margin_bottom">
                    <input type="checkbox" v-model="remember" class="btn-check" id="remember_me" autocomplete="off">
                    <label class="btn btn-outline-light" for="remember_me">Remember me</label>
                    <input type="submit" class="btn btn-outline-light " value="Log in" />
                </div>

                <a href="/register" class="link-light">Create Account</a>
            </form>
        </section>
    </div>
</template>

<script>
import Users from '../assets/js/users';
export default {
    data: function() {
        return {
            name: "",
            password: "",
            remember: false,
        };
    },
    methods: {
        LoginUser: async function(e) {
            e.preventDefault();
            console.log(this.name, this.password, this.remember);
            const res = await Users.LoginUser(this.name, this.password, this.remember);
            console.log(res.status);
        }
    }
}
</script>