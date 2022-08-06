function solve() {
  let textField = document.getElementById("text");
  let caseField = document.getElementById("naming-convention");
  let resultField = document.getElementById("result");

  switch (caseField.value) {
    case "Camel Case":
      resultField.textContent = camel(textField.value);
      break;
    case "Pascal Case":
      resultField.textContent = pascal(textField.value);
      break;
    default:
      resultField.textContent = "Error!";
      break;
  }

  function camel(string) {
    let arr = string.toLowerCase().split(" ");

    let result = [arr[0]];

    for (let i = 1; i < arr.length; i++) {
      let word = arr[i];
      word = word.charAt(0).toUpperCase() + word.slice(1);
      result.push(word);
    }
    return result.join("");
  }

  function pascal(string) {
    let arr = string.toLowerCase().split(" ");

    let result = [];

    for (let i = 0; i < arr.length; i++) {
      let word = arr[i];
      word = word.charAt(0).toUpperCase() + word.slice(1);
      result.push(word);
    }
    return result.join("");
  }
}
