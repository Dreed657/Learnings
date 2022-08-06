function solve(arr) {
  let result = {};

  for (let row of arr) {
    let [townName, productName, price] = row.split(" | ");
    price = Number(price);

    if (result[productName]) {
      if (result[productName].price > price) {
        result[productName] = {
          townName,
          price,
        };
      }
    } else {
      result[productName] = {
        townName,
        price,
      };
    }
  }

  for (let [cityName, value] of Object.entries(result)) {
    console.log(`${cityName} -> ${value.price} (${value.townName})`);
  }
}

solve([
  "Sample Town | Sample Product | 1000",
  "Sample Town | Orange | 2",
  "Sample Town | Peach | 1",
  "Sofia | Orange | 3",
  "Sofia | Peach | 2",
  "New York | Sample Product | 10.1",
  "New York | Burger | 10",
]);
