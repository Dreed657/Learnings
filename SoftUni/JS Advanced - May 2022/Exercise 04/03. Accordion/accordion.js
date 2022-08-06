function toggle() {
  let button = document.querySelector(".button");
  let extra = document.querySelector("#extra");

  if (button.textContent == "More") {
    button.textContent = "Less";
    extra.style.display = "block";
  } else {
    button.textContent = "More";
    extra.style.display = "none";
  }
}
