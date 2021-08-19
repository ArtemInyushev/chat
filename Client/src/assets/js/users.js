class Users {
    static GetFetchOptions(data) {
        const fetchOptions = {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            mode: "cors", // no-cors, cors, *same-origin
            cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
            credentials: "include", // include, *same-origin, omit
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

    static async AuthenticateUser(){
        const res = await fetch("https://localhost:44360/api/Users/Authenticate", {
            credentials: "include",
        });
        const status = res.status;
        if (status === 200) {
            return true;
        }
        else if (status === 401) {
            return false;
        }
        else {
            console.log("Something went wrong");
            return false;
        }
    }

    static async LoginUser(username, password, remember){
        const fetchOptions = this.GetFetchOptions({
            "Username": username,
            "Password": password,
            "RememberMe": remember,
        });
        try {
            return await fetch("https://localhost:44360/api/Users/Login", fetchOptions);
        }
        catch (error) {
            console.log(error);
        }
    }
}

export default Users;