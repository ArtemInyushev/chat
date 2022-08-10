<template>
	<article class="content">
		<article class="content_flex">
			<section class="main_left">
				<section class="user_search flex">
					<div class="search_icon centered_text">
						<i class="fas fa-search fa-lg"></i>
					</div>
					<input class="search_input blackground white" type="text" 
						@input="getNameFilterWithDelay" placeholder="Search" maxlength="25"/>
				</section>
				<section class="all_users">
					<label class="inline white">All users</label>
					<section class="chat flex">
						<section class="chat_image">
							<img src="https://res.cloudinary.com/duzykfess/image/upload/v1628780843/Chat/user_aga0w2.png" class="rounded_img" alt="...">
						</section>
						<section class="chat_info">
							<label class="white">Username</label><br />
							<label class="text-muted">Message text...</label>
						</section>
						<section class="chat_additional centered_text">
							<small class="white">12:00</small><br />
							<label class="text-muted">1</label>
						</section>
					</section>
					<section class="chat flex">
						<section class="chat_image">
							<img src="https://res.cloudinary.com/duzykfess/image/upload/v1628780843/Chat/user_aga0w2.png" class="rounded_img" alt="...">
						</section>
						<section class="chat_info">
							<label class="white">Username</label><br />
							<label class="text-muted">Message text...</label>
						</section>
						<section class="chat_additional centered_text">
							<small class="white">12:00</small><br />
							<label class="text-muted">1</label>
						</section>
					</section>
				</section>
			</section>
			<section class="main_right">
				<section class="user_description">
					<section class="chat_header flex">
						<section class="chat_image">
							<img src="https://res.cloudinary.com/duzykfess/image/upload/v1628780843/Chat/user_aga0w2.png" class="rounded_img" alt="...">
						</section>
						<section class="chat_info">
							<label class="white">Username</label><br />
							<label class="text-muted">Message text...</label>
						</section>
						<section class="chat_additional centered_text">
							<small class="white">12:00</small><br />
							<label class="text-muted">1</label>
						</section>
					</section>
				</section>
			</section>
		</article>
	</article>
</template>

<script>
import * as signalR from "@microsoft/signalr";

export default {
	name: "Main",
	data: function() {
		return {
			hubConnection: null,
			activeChats: [],
			allChats: [],
			nameFilter: "",
			delay: null,
		};
	},
	computed: {
		filteredActiveChats: function() {
			return this.nameFilter === "" 
				? this.activeChats 
				: this.activeChats.filter(x => x.username.toLowerCase().includes(this.nameFilter));
		},
	},
	methods: {
		getNameFilterWithDelay(e) {
			clearTimeout(this.delay);
			this.delay = setTimeout(() => {
				this.nameFilter = e.target.value.toLowerCase().trim();
			}, 1000);
		},
	},
	watch: {
		nameFilter: function(val) { console.log(val); }
	},
	mounted: async function() {
		this.hubConnection = new signalR.HubConnectionBuilder()
			.withUrl("https://localhost:44360/chat")
			.configureLogging(signalR.LogLevel.Information)
			.build();
		this.hubConnection.start();
	}
}
</script>

<style scoped>
section.main_left {
    height: 100%;
    width: 25%;
    border-right: 2px solid rgba(44, 210, 240, 0.596);
}

section.main_right {
    height: 100%;
    width: 75%;
}

section.user_description {
	width: 100%;
	height: 10%;
}

section.chat_header {
	height:100%;
    width: 100%;
	border: 2px solid green;
    border-radius: 30px;
    margin-top: 1px;
    margin-bottom: 1px;
}

section.user_search {
    height: 7%;
    width: 100%;
    border-bottom: 2px solid rgba(44, 210, 240, 0.596);
}

section.chat_additional {
    height: 100%;
    width: 15%;
}

section.all_users {
    width: 100%;
}

section.chat {
    height:50px;
    width: 100%;
    border: 2px solid green;
    border-radius: 30px;
    margin-top: 1px;
    margin-bottom: 1px;
}

section.chat_image {
    height: 100%;
    width: 15%;
}

section.chat_info {
    height: 100%;
    width: 70%;
}

div.search_icon {
    width: 10%;
    margin-top: auto;
    margin-bottom: auto;
}

input.search_input {
    width: 85%;
    border: none;
}

input.search_input:focus {
    outline: none;
}
</style>