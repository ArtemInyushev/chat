async function AddUser(username, email, password) {
    const data = {
        "Username": username,
        "Email": email,
        "Password": password
    }
    const fetchOptions = {
        method: "POST", // *GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors, cors, *same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        credentials: "same-origin", // include, *same-origin, omit
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json; charset=UTF-8',
            //"Content-Type": "application/x-www-form-urlencoded",
        },
        redirect: "follow", // manual, *follow, error
        referrer: "no-referrer", // no-referrer, *client
        body: JSON.stringify(data), // body data type must match "Content-Type"
    };
    console.log(fetchOptions.body);

    const id = await fetch("api/Users", fetchOptions).then(x => x.text());
    console.log(id);
}