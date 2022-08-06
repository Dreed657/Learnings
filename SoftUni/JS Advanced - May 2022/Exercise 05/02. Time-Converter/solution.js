function attachEventsListeners() {
  let buttons = document.querySelectorAll("input[type=button]");
  for (let button of buttons) {
    button.addEventListener("click", convert);
  }

  function convert(event) {
    let input = event.target.parentElement.childNodes[3];

    let name = input.id;
    let value = input.value;

    let seconds = 0;
    let minutes = 0;
    let hours = 0;
    let days = 0;

    switch (name) {
      case "seconds":
        seconds = value;
        minutes = value / 60;
        hours = value / 3600;
        days = value / 86400;
        break;
      case "minutes":
        seconds = value * 60;
        minutes = value;
        hours = value / 60;
        days = value / 24;
        break;
      case "hours":
        seconds = value * 3600;
        minutes = value * 60;
        hours = value;
        days = value / 24;
        break;
      case "days":
        seconds = value * 86400;
        minutes = value * 1440;
        hours = value * 24;
        days = value;
        break;
    }

    document.querySelector("input#seconds").value = seconds;
    document.querySelector("input#minutes").value = minutes;
    document.querySelector("input#hours").value = hours;
    document.querySelector("input#days").value = days;
  }
}
