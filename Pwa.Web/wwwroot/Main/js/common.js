let header = document.querySelector("header");
let searchBox = document.querySelector(".search_box");
let searchCloseBoxBtn = document.querySelector(".search_box button");
let searchBtn = document.querySelector(".search_btn");
let btnHambergerMenu = document.querySelector(".hamberger_menu_btn");
let hambergerMenu = document.querySelector("header nav");
let btnClosehambergerMenu = document.querySelector("header nav button");
let body = document.body;

searchBtn.addEventListener("click", () => {
  searchBox.classList.add("search_active");
});

searchCloseBoxBtn.addEventListener("click", () => {
  searchBox.classList.remove("search_active");
});

btnHambergerMenu.addEventListener("click", () => {
  hambergerMenu.classList.toggle("active_menu");
  header.classList.add("overlay");
  body.style.overflow = "hidden";
});
btnClosehambergerMenu.addEventListener("click", () => {
  hambergerMenu.classList.remove("active_menu");
  header.classList.remove("overlay");
  body.style.overflow = "unset";
});

body.addEventListener("click", (e) => {
  if (e.target.classList.contains("overlay")) {
    hambergerMenu.classList.remove("active_menu");
    header.classList.remove("overlay");
    body.style.overflow = "unset";
  }
});
