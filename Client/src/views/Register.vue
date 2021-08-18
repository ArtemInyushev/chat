<template>
	<div class="fullsize">
		<header>
            <section class="left_header">
				<a href="/login">
					<button type="button" class="btn btn-outline-light">Go back to Login</button>
				</a>
			</section>
    
            <section class="name">
                <h1 class="display-2 turquoise">My chat</h1>
            </section>
    
            <section class="right_header"></section>
        </header>

		<article class="content_flex">
			<section class="half_size flex">
				<h1 class="display-1 centered_text create_header white">Create Account<br> Now</h1>
			</section>
			<section class="half_size">
				<section class="create_form">
					<form onsubmit="GetNewUser(event)">
						<h1 class="display-4 centered_text white">Fill the form</h1>

						<div class="margin_bottom">
							<label class="turquoise"><i class="fas fa-user"></i> Username</label>
							<input type="text" class="input_form blackground white" id="username" maxlength="30" minlength="3"
								pattern="[\w_]+" title="Username can contain only letters, digits and underscores" required>
						</div>
						<div class="margin_bottom">
							<label class="turquoise"><i class="fas fa-user"></i> Email</label>
							<input type="email" class="input_form blackground white" id="email" maxlength="50" required>
						</div>
						<div class="margin_bottom">
							<label class="turquoise"><i class="fas fa-user"></i> Password</label>
							<input type="password" class="input_form blackground white" id="password" maxlength="30" minlength="6"
								pattern="[\w_]+" title="Username can contain only letters, digits and underscores" required>
						</div>
						<div class="margin_bottom">
							<label class="turquoise"><i class="fas fa-user"></i> Confirm Password</label>
							<input type="password" class="input_form blackground white" id="confirm" maxlength="30" minlength="6" required>
						</div>

						<div class="form-check">
							<input class="form-check-input" type="checkbox" id="remember">
							<label class="form-check-label turquoise">Remember me</label>
						</div>

						<input type="submit" class="btn btn-outline-light float_right margin_top" id="register" value="Register" />
					</form>
				</section>
			</section>
		</article>
	</div>
</template>
