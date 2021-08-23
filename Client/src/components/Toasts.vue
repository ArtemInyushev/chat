<template>
    <div class="toast-container position-fixed end-0 w-25">
        <div class="toast w-100 hide" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-dark text-white">
                <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627997941/Chat/0276e7e10311f0f161c5c38a2d7b8008_qqgv8k.jpg" class="rounded me-2" height="16" alt="...">
                <strong class="me-auto"></strong>
                <small>just now</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body bg-white text-dark"></div>
        </div>

        <div class="toast w-100 hide" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-dark text-white">
                <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627997941/Chat/0276e7e10311f0f161c5c38a2d7b8008_qqgv8k.jpg" class="rounded me-2" height="16" alt="...">
                <strong class="me-auto"></strong>
                <small>just now</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body bg-white text-dark"></div>
        </div>

        <div class="toast w-100 hide" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-dark text-white">
                <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627997941/Chat/0276e7e10311f0f161c5c38a2d7b8008_qqgv8k.jpg" class="rounded me-2" height="16" alt="...">
                <strong class="me-auto"></strong>
                <small>just now</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body bg-white text-dark"></div>
        </div>

        <div class="toast w-100 hide" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-dark text-white">
                <img src="https://res.cloudinary.com/duzykfess/image/upload/v1627997941/Chat/0276e7e10311f0f161c5c38a2d7b8008_qqgv8k.jpg" class="rounded me-2" height="16" alt="...">
                <strong class="me-auto"></strong>
                <small>just now</small>
                <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body bg-white text-dark"></div>
        </div>

        <div class="toast w-100 hide" role="alert" aria-live="assertive" aria-atomic="true">
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
    v-bind:class="{'hide': hidden, 'fade show': !hidden}"
    
    <div class="toast-container position-fixed end-0 w-25">

    </div>
    -->
</template>

<script>
export default {
    name: "Toasts",
    data: function() {
        return {
            hidden: true,
        };
    }
}
</script>