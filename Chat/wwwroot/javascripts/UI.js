function UpdateContent(html) {
    document.getElementsByClassName("content")[0].innerHTML = html;
}

function UpdateLeftHeader(html) {
    document.getElementsByClassName("left_header")[0].innerHTML = html;
}

function UpdateRightHeader(html) {
    document.getElementsByClassName("right_header")[0].innerHTML = html;
}

function LoadMainPage() {
    Promise.all([
        fetch("/templates/Main.html").then(x => x.text()),
        fetch("/templates/LeftHeader.html").then(x => x.text()),
        fetch("/templates/RightHeader.html").then(x => x.text()),
    ])
    .then(([mainHTML, leftHeaderHTML, rightHeaderHTMl]) => {
        UpdateContent(mainHTML);
        UpdateLeftHeader(leftHeaderHTML);
        UpdateRightHeader(rightHeaderHTMl);
    })
    .catch(err => console.error(err));
}