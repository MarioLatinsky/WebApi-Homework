let getButton = document.getElementById("btn1");
let getId = document.getElementById("place_id");
let getAuthor = document.getElementById("place_author");
let getTitle = document.getElementById("place_title");

let port = "7228";
let url = `https://localhost:${port}/api/books/postbook`;

let createNewBook = async () => {
  var book = {
    Id: getId.value,
    Author: getAuthor.value,
    Title: getTitle.value,
  };
  var options = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(book),
  };
  ///////////////////////////////////////
  // not sure what this part does exactly
  let response = await fetch(url, options);
  let data = await response.json();
  //////////////////////////////////////
  console.log(data);
};

getButton.addEventListener("click", createNewBook);
