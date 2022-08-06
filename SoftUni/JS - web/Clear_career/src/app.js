import { page, render } from "./lib.js";
import { getUserData } from "./util.js";
import { logout } from "./api/users.js";

import { homeView } from "./views/home.js";
import { dashboardView } from "./views/dashboard.js";
import { loginView } from "./views/login.js";
import { registerView } from "./views/register.js";
import { newOfferView } from "./views/newOffer.js";
import { offerView } from "./views/offer.js";
import { editOfferView } from "./views/editOffer.js";

const main = document.querySelector("main");

document.getElementById("logoutBtn").addEventListener("click", onLogout);

page(decorateContext);
page("/", homeView);
page("/dashboard", dashboardView);
page("/login", loginView);
page("/register", registerView);
page("/offer/:id", offerView);
page("/create", newOfferView);
page("/offer/:id/edit", editOfferView);

updateNav();
page.start();

function decorateContext(ctx, next) {
  ctx.render = renderMain;
  ctx.updateNav = updateNav;
  next();
}

function renderMain(template) {
  render(template, main);
}

function onLogout() {
  logout();
  updateNav();
  page.redirect("/dashboard");
}

function updateNav() {
  const userData = getUserData();

  if (userData) {
    document.querySelector(".user").style.display = "block";
    document.querySelector(".guest").style.display = "none";
  } else {
    document.querySelector(".user").style.display = "none";
    document.querySelector(".guest").style.display = "block";
  }
}
