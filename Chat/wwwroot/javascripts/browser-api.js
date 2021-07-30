window.onload = function () {
    GoToLoginPage();
}

$(document).ready(function () {
    $('.toast').toast('show');
});

async function GetNewUser(e) {
    e.preventDefault();
    const register_button = document.getElementById("register");
    register_button.disabled = true;

    const password = document.getElementById("password").value;
    const confirm = document.getElementById("confirm").value;
    if (password != confirm) {
        console.log("Passwords aren't the same!");
        return;
    }
    const username = document.getElementById("username").value;
    const email = document.getElementById("email").value;
    const remember = document.getElementById("remember").checked;
    console.log(username, email, password, remember);

    const data = {
        "Username": username,
        "Email": email,
        "Password": password
    };
    const res = await AddUser(data);
    const status = res.status;
    const user = await res.json();
    if (status === 201) {
        console.log(typeof(user), user);
        GoToMainPage();
    }
    else if (status === 403) {
        console.log(user);
        register_button.disabled = false;
    }
    else {
        console.log("Something got wrong", user);
    }
}

function LogoutAction() {
    GoToLoginPage();
}

function GoToMainPage() {
    RenderMainPage();
}

function GoToLoginPage() {
    RenderLoginPage();
}

function GoToCreateAccountPage() {
    RenderCreateAccountPage();
}