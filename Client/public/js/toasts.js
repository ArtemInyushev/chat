/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
window.onload = async function () {
    console.log("hello");
    await ShowToastMessage("Error", "Passwords aren't the same", "text-danger");
    await ShowToastMessage("Error", "Passwords aren't the same", "text-danger");
    await ShowToastMessage("Error", "Passwords aren't the same", "text-danger");
}

async function ShowToastMessage(title, body, titleClass) {
    let toastEl = $(".toast.hide").last();
    if (!toastEl.length) {
        toastEl = $(".toast").last();
    }
    $('.toast-container').prepend(toastEl);
    await UpdateToastMessage(toastEl, title, body, titleClass);
    toastEl.toast({ delay: 10000 });
    toastEl.toast("show");
}

async function UpdateToastMessage(toast, title, body, titleClass) {
    const titleEl = toast.find("strong");
    titleEl.text(title);
    if (titleClass) {
        if (!titleEl.hasClass(titleClass)) {
            titleEl.removeClass(function (index, className) {
                return (className.match(/(^|\s)text-\S+/g) || []).join(' ');
            });
            titleEl.addClass(titleClass);
        }        
    }
    toast.find(".toast-body").text(body);
}