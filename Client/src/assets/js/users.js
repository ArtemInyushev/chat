class Users {
    static async AuthenticateUser(){
        const res = await fetch("https://localhost:44360/api/Users/Authenticate");
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
}

export default Users;