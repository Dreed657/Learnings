function solve(arr) {
  let result = {};

  for (let product of arr) {
    let [name, price] = product.split(" : ");
    let firstLetter = name.charAt(0);

    if (!result.hasOwnProperty(firstLetter)) {
      result[firstLetter] = [{ name, price }];
    } else {
      result[firstLetter].push({ name, price });
    }
  }

  let printable = Object.entries(result).sort();

  for (let [letter, value] of printable) {
    console.log(letter);
    value
      .sort((a, b) => a.name.toLowerCase().localeCompare(b.name.toLowerCase()))
      .forEach((p) => console.log(`\t${p.name}: ${p.price}`));
  }
}

// solve([
//   "Appricot : 20.4",
//   "Fridge : 1500",
//   "TV : 1499",
//   "Deodorant : 10",
//   "Boiler : 300",
//   "Apple : 1.25",
//   "Anti-Bug Spray : 15",
//   "T-Shirt : 10",
// ]);

solve([
  "Banana : 2",
  "Rubics Cube : 5",
  "Raspberry P : 4999",
  "Rolex : 100000",
  "Rollon : 10",
  "Rali Car : 2000000",
  "Pesho : 0.000001",
  "Barrel : 10",
]);
