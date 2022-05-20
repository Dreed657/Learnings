function cook(n, ...operants) {
  let state = n;

  for (let operator of operants) {
    switch (operator) {
      case "chop":
        state = state / 2;
        break;
      case "dice":
        state = Math.sqrt(state);
        break;
      case "spice":
        state = state + 1;
        break;
      case "bake":
        state = state * 3;
        break;
      case "fillet":
        state = state - state * 0.2;
        break;
    }
    console.log(state);
  }
}

console.log("------------");
cook("32", "chop", "chop", "chop", "chop", "chop");
console.log("------------");
cook("9", "dice", "spice", "chop", "bake", "fillet");
