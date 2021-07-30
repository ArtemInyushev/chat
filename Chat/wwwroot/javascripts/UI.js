function UpdateContent(html) {
    document.getElementsByClassName("content")[0].innerHTML = html;
}

function UpdateLeftHeader(html) {
    document.getElementsByClassName("left_header")[0].innerHTML = html;
}

function UpdateRightHeader(html) {
    document.getElementsByClassName("right_header")[0].innerHTML = html;
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