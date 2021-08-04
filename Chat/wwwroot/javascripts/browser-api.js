window.onload = function () {
    GoToLoginPage();

    //$(".toast").toast({ autohide: false });
    //$(".toast").toast("show");
    //setTimeout(() => {
    //    $(".toast").toast({ autohide: false });
    //    $(".toast").toast("show");
    //}, 10000);

    //setTimeout(() => {
    //    const lastToast = $(".toast").last();
    //    lastToast.toast("hide");
    //    $('.toast-container').prepend(lastToast);
    //    lastToast.toast("show");
    //    lastToast.toast("show");
    //}, 2000);
}

async function NewToastMessage(title, body, titleClass) {
    ShowToastMessage(title, body, titleClass);
}

//async function ShowToastMessage() {
//    const toastHTML = await fetch("/templates/Additional/Toast.html").then(x => x.text());
//    const newToastEl = jQuery("<div/>").html(toastHTML);
//    $('.toast-container').prepend(newToastEl);

//    const toastMessage = newToastEl.find(".toast");
//    toastMessage.toast({ autohide: false });
//    toastMessage.toast('show');

//    setTimeout(() => toastMessage.toast("hide"), 2000);
//}

async function GetNewUser(e) {
    e.preventDefault();
    const register_button = $("#register");
    register_button.prop("disabled", true);

    const password = $("#password").val();
    const confirm = $("#confirm").val();
    if (password != confirm) {
        NewToastMessage("Error", "Passwords aren't the same", "text-danger");
        register_button.prop("disabled", false);
        return;
    }
    const username = $("#username").val();
    const email = $("#email").val();
    const remember = $("#remember").is(":checked");
    console.log(username, email, password, remember);

    const data = {
        "Username": username,
        "Email": email,
        "Password": password
    };
    const res = await AddUser(data);
    const status = res.status;
    if (status === 201) {
        const user = await res.json();
        console.log(user);
        GoToMainPage();
        return;
    }

    register_button.prop("disabled", false);
    if (status === 403) {
        NewToastMessage("Warning", await res.text(), "text-warning");
    }
    else {
        NewToastMessage("Error", await res.text(), "text-danger");
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