window.addEventListener("load", solve);

function solve() {
  document.getElementById("publish").addEventListener("click", (e) => {
    e.preventDefault();

    const makeField = document.getElementById("make");
    const modelField = document.getElementById("model");
    const yearField = document.getElementById("year");
    const fuelField = document.getElementById("fuel");
    const originalField = document.getElementById("original-cost");
    const sellField = document.getElementById("selling-price");

    const makeValue = makeField.value;
    const modelValue = modelField.value;
    const yearValue = yearField.value;
    const fuelValue = fuelField.value;
    const originalValue = Number(originalField.value);
    const sellValue = Number(sellField.value);

    if (
      makeValue == "" ||
      modelValue == "" ||
      yearValue == "" ||
      fuelValue == "" ||
      originalValue == "" ||
      sellValue == ""
    ) {
      return;
    }

    if (sellValue < 0 || originalValue < 0) {
      return;
    }

    if (sellValue < originalValue) {
      return;
    }

    const tr = document.createElement("tr");
    tr.classList.add("row");

    const makeTd = document.createElement("td");
    makeTd.innerText = makeValue;

    const modelTd = document.createElement("td");
    modelTd.innerText = modelValue;

    const yearTd = document.createElement("td");
    yearTd.innerText = yearValue;

    const fuelTd = document.createElement("td");
    fuelTd.innerText = fuelValue;

    const originalTd = document.createElement("td");
    originalTd.innerText = originalValue;

    const sellTd = document.createElement("td");
    sellTd.innerText = sellValue;

    const actionsTd = document.createElement("td");

    const editBtn = document.createElement("button");
    editBtn.innerText = "Edit";
    editBtn.classList.add("action-btn", "edit");
    editBtn.addEventListener("click", () => {
      tr.remove();
      makeField.value = makeValue;
      modelField.value = modelValue;
      yearField.value = yearValue;
      fuelField.value = fuelValue;
      originalField.value = originalValue;
      sellField.value = sellValue;
    });

    const sellBtn = document.createElement("button");
    sellBtn.innerText = "Sell";
    sellBtn.classList.add("action-btn", "sell");
    sellBtn.addEventListener("click", () => {
      tr.remove();

      const liEl = document.createElement("li");
      liEl.classList.add("each-list");

      const carEl = document.createElement("span");
      carEl.innerText = `${makeValue} ${modelValue}`;

      const yearEl = document.createElement("span");
      yearEl.innerText = yearValue;

      const profitEl = document.createElement("span");
      profitEl.innerText = Number(sellValue) - Number(originalValue);

      liEl.appendChild(carEl);
      liEl.appendChild(yearEl);
      liEl.appendChild(profitEl);

      document.getElementById("cars-list").appendChild(liEl);

      document.getElementById("profit").innerText = Array.from(
        document.getElementById("cars-list").children
      )
        .map((car) => Number(car.children[2].innerText))
        .reduce((acc, a) => acc + a, 0)
        .toFixed(2);
    });

    actionsTd.appendChild(editBtn);
    actionsTd.appendChild(sellBtn);

    tr.appendChild(makeTd);
    tr.appendChild(modelTd);
    tr.appendChild(yearTd);
    tr.appendChild(fuelTd);
    tr.appendChild(originalTd);
    tr.appendChild(sellTd);
    tr.appendChild(actionsTd);

    document.getElementById("table-body").appendChild(tr);

    makeField.value = "";
    modelField.value = "";
    yearField.value = "";
    fuelField.value = "";
    originalField.value = "";
    sellField.value = "";
  });
}
