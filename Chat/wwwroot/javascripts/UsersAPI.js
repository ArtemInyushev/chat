async function CreateUser(e) {
    e.preventDefault();

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

    const html = await fetch("/templates/Main.html").then(x => x.text());
    //UpdateContent(html);
}