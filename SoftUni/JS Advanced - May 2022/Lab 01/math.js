function calc(a, b, o) {
  let result;

  switch (o) {
    case "+":
      result = a + b;
      break;
    case "-":
      result = a - b;
      break;
    case "*":
      result = a * b;
      break;
    case "/":
      result = a / b;
      break;
    case "%":
      result = a % b;
      break;
    case "**":
      result = a ** b;
      break;
  }

  console.log(result);
}

calc(5, 6, "+");
calc(3, 5.5, "*");
