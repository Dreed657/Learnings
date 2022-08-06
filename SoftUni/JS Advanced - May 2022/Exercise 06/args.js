function solve() {
  let result = {};

  for (let arg of arguments) {
    let type = typeof arg;

    console.log(`${type}: ${arg}`);

    if (!result[type]) {
      result[type] = 0;
    }

    result[type]++;
  }

  Object.entries(result)
    .sort((a, b) => b[1] - a[1])
    .forEach(([type, num]) => console.log(`${type} = ${num}`));
}

solve("cat", 42, 531, function () {
  console.log("Hello world!");
});
