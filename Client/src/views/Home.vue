<template>
	<article class="content">
		<article class="content_flex">
			<section class="main_left">
				<section class="user_search flex">
					<div class="search_icon centered_text">
						<i class="fas fa-search fa-lg"></i>
					</div>
					<input class="search_input blackground white" type="text" placeholder="Search"  maxlength="25"/>
				</section>
				<section class="all_users">
					<label class="inline white">All users</label>
					<section class="chat flex" onclick="alert('hello');">
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
			</section>
		</article>
	</article>
</template>

<script>
// @ is an alias to /src
//import HelloWorld from '@/components/HelloWorld.vue'

export default {
	name: 'Home',
	components: {
		//HelloWorld
	}
}
</script>
