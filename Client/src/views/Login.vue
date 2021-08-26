<template>
    <article class="content">
        <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627071932/Chat/lock_inmjg5.jpg" class="login" />

        <section class="login_form">
            <form @submit="login">
                <h1 class="display-4 centered_text white">Login</h1>

                <input type="text" v-model="username" class="input_form blackground white margin_bottom" 
                    placeholder="Username..." maxlength="30" required>
                <input type="password" v-model="password" class="input_form blackground white margin_bottom" 
                    placeholder="Password..." maxlength="30" required>

                <div class="margin_bottom">
                    <input type="checkbox" v-model="remember" class="btn-check" id="remember_me" autocomplete="off">
                    <label class="btn btn-outline-light" for="remember_me">Remember me</label>
                    <input type="submit" class="btn btn-outline-light" value="Log in" :disabled='isDisabled' />
                </div>

                <a href="/register" class="link-light">Create Account</a>
            </form>
        </section>
    </article>
</template>

<script>
import Toast from '../assets/js/toasts';

export default {
    name: "Login",
    data: function() {
        return {
            username: "",
            password: "",
            remember: false,
            isDisabled: false,
        };
    },
    methods: {
        login: async function(e) {
            e.preventDefault();
            this.isDisabled = true;

            const data = {
                "Username": this.username,
                "Password": this.password,
                "RememberMe": this.remember,
            };
            const fetchOptions = {
                method: "POST",
                credentials: "include",
                headers: {
                    'Accept': 'application/json; charset=utf-8',
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify(data),
            }

            let res;
            try {
                res = await fetch("https://localhost:44360/api/Users/Login", fetchOptions);
            }
            catch (error) {
                console.log(error);
            }

            const status = res.status;
            if (status === 200) {
                const user = await res.json();
                
                localStorage.setItem("username", user.username ? user.username : "");
                localStorage.setItem("email", user.email ? user.email : "");
                localStorage.setItem("logoUrl", user.logoUrl ? user.logoUrl : "");

                this.$router.go("Home");
                return;
            }
            else {
                this.isDisabled = false;
                Toast.ShowToastMessage("Error", await res.text(), "text-danger");
            }
        }
    },
}
</script>