function UpdateContent(html) {
    $(".content").html(html);
}

function UpdateLeftHeader(html) {
    $(".left_header").html(html);
}

function UpdateRightHeader(html) {
    $(".right_header").html(html);
}

function RenderMainPage() {
    Promise.all([
        fetch("/templates/Main/Content.html").then(x => x.text()),
        fetch("/templates/Main/LeftHeader.html").then(x => x.text()),
        fetch("/templates/Main/RightHeader.html").then(x => x.text()),
    ])
    .then(([mainHTML, leftHeaderHTML, rightHeaderHTMl]) => {
        UpdateContent(mainHTML);
        UpdateLeftHeader(leftHeaderHTML);
        UpdateRightHeader(rightHeaderHTMl);
    })
    .catch(err => console.error(err));
}

function RenderLoginPage() {
    fetch("/templates/Login/Content.html")
    .then(x => x.text())
    .then(html => {
        UpdateContent(html);
        UpdateLeftHeader("");
        UpdateRightHeader("");
    })
    .catch(err => console.error(err));
}

function RenderCreateAccountPage() {
    Promise.all([
        fetch("/templates/CreateAccount/Content.html").then(x => x.text()),
        fetch("/templates/CreateAccount/LeftHeader.html").then(x => x.text()),
    ])
    .then(([mainHTML, leftHeaderHTML]) => {
        UpdateContent(mainHTML);
        UpdateLeftHeader(leftHeaderHTML);
        UpdateRightHeader("");
    })
    .catch(err => console.error(err));
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