<template>
    <div>
        <button type="button" class="btn btn-outline-light" data-bs-toggle="modal" data-bs-target="#logout_modal">Log out</button>

        <!-- Logout Modal -->
        <div class="modal fade" id="logout_modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content border-0">
                    <div class="modal-header darkground border-primary text-primary">
                        <h5 class="modal-title" id="staticBackdropLabel">Log out</h5>
                        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body darkground text-primary">
                        Are you sure?
                    </div>
                    <div class="modal-footer border-primary darkground">
                        <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal">Go back</button>
                        <button type="button" class="btn btn-outline-primary" data-bs-dismiss="modal" v-on:click="logout">Log out</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import User from '../../assets/js/users';
import Toast from '../../assets/js/toasts';

export default {
	name: 'RightHeader',
	methods: {
		logout: async function() {
            if(await User.LogoutUser()){
                localStorage.removeItem("username");
                localStorage.removeItem("email");
                localStorage.removeItem("logoUrl");
                this.$router.go("Login");
            }
            else{
                Toast.ShowToastMessage("Error", "Mistake during logout", "text-danger");
            }
		}
	}
}
</script>