let button = document.getElementById("btn1")

let port = "7121"
let url = `https://localhost:${port}/api/users`

let getAllUsernames = async () => {
    let response = await fetch(url);
    let data = await response.json();

    console.log(data)
}

button.addEventListener("click", getAllUsernames)