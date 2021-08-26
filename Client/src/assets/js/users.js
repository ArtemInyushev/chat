class User {
    static async AuthenticateUser(){
        try {
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
        catch(error) {
            console.log(error);
        }        
    }

    static async LogoutUser(){
        try {
            const res = await fetch("https://localhost:44360/api/Users/Logout", {
                credentials: "include",
            });
            if (res.status === 200) {
                return true;
            }
            else {
                console.log("Logout error");
                return false;
            }
        }
        catch (error) {
            console.log(error);
        }
    }

    static async AddUser(username, email, password, remember){
        const data = {
            "Username": username,
            "Email": email,
            "Password": password,
            "RememberMe": remember,
        };
        const fetchOptions = {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify(data),
        };
        try {
            return await fetch("https://localhost:44360/api/Users", fetchOptions);
        }
        catch (error) {
            console.log(error);
        }
    }
}

export default User;