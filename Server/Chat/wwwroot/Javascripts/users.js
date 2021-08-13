function GetFetchOptions(data) {
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
    return fetchOptions;
}

async function AuthenticateUser() {
    const res = await fetch("api/Users/Authenticate");
    const status = res.status;
    if (status === 200) {
        return true;
    }
    else if (status == 401) {
        return false;
    }
    else {
        console.log("Something went wrong");
        return false;
    }
}

async function LoginUser(data) {
    const fetchOptions = GetFetchOptions(data);
    try {
        return await fetch("api/Users/Login", fetchOptions);
    }
    catch (error) {
        console.log(error);
    }
}

async function LogoutUser() {
    const res = await fetch("api/Users/Logout");
    if (res.status === 200) {
        return true;
    }
    else {
        console.log("Logout error");
        return false;
    }
}

async function AddUser(data) {
    const fetchOptions = GetFetchOptions(data);
    try {
        return await fetch("api/Users", fetchOptions);
    }
    catch (error) {
        console.log(error);
    }
}