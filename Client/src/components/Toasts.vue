<template>
    <div class="toast-container position-fixed end-0 w-25">
        <div v-for="index in 5" :key="index" class="toast w-100 text-white hide" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-dark text-white">
                <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627997941/Chat/0276e7e10311f0f161c5c38a2d7b8008_qqgv8k.jpg" class="rounded me-2" height="16" alt="...">
                <strong class="me-auto"></strong>
                <small>just now</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body bg-white text-dark"></div>
        </div>
    </div>
    <!--
    <div class="toast-container position-fixed end-0 w-25">
        <div v-for="toast in toasts" :key="toast.id" class="toast w-100 text-white" 
            :class="{'hide': toast.hidden, 'fade show': !toast.hidden}" role="alert" aria-live="assertive" aria-atomic="true">

            <div class="toast-header bg-dark text-white">
                <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627997941/Chat/0276e7e10311f0f161c5c38a2d7b8008_qqgv8k.jpg" class="rounded me-2" height="16" alt="...">
                <strong class="me-auto" :class="toast.titleClass">{{ toast.title }}</strong>
                <small>just now</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body bg-white text-dark">{{ toast.body }}</div>
        </div>
    </div>
    -->
</template>

<script>
export default {
    name: "Toasts",
    data: function() {
        return {
            toasts: [
                {id:1, hidden: true, title: "", titleClass: "", body: ""},
                {id:2, hidden: true, title: "", titleClass: "", body: ""},
                {id:3, hidden: true, title: "", titleClass: "", body: ""},
                {id:4, hidden: true, title: "", titleClass: "", body: ""},
                {id:5, hidden: true, title: "", titleClass: "", body: ""},
            ],
        };
    },
    methods: {
        showToastMessage(title, body, titleClass) {
            let index = this.toasts.map(el => el.hidden).lastIndexOf(true);
            if(index < 0){
                index = this.toasts.length - 1;
            }
            const toast = this.toasts[index];
            console.log(toast.id);
            toast.title = title;
            toast.body = body;
            toast.titleClass = titleClass;
            toast.hidden = false;
            setTimeout(() => { toast.hidden = true}, 10000);
        }
    },
    created: function() {
        this.$on('showToast', this.showToastMessage);
    },
}
</script>

<style scoped>
.transition {
    transition: 1s;
}
</style>