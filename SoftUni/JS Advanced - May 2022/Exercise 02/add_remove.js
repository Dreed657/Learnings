function addRemove(arr) {
  var count = 1;
  let result = [];

  for (let com of arr) {
    switch (com) {
      case "add":
        result.push(count);
        break;
      case "remove":
        result.pop();
        break;
    }

    count++;
  }

  if (result.length === 0) {
    console.log("Empty");
    return;
  }

  result.forEach((e) => console.log(e));
}

addRemove(["add", "add", "add", "add"]);
addRemove(["add", "add", "remove", "add", "add"]);
addRemove(["remove", "remove", "remove"]);
