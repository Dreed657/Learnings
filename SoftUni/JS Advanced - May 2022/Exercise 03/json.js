function solve(arr) {
  let result = [];

  for (let row of arr.slice(1, arr.length)) {
    let [name, lang, long] = row.split(" | ");

    let Town = name.replace("| ", "");
    let Latitude = Number(Number(lang).toFixed(2));
    let Longitude = Number(Number(long.replace(" |", "")).toFixed(2));

    result.push({ Town, Latitude, Longitude });
  }

  console.log(JSON.stringify(result));
}

solve([
  "| Town | Latitude | Longitude |",
  "| Sofia | 42.696552 | 23.32601 |",
  "| Beijing | 39.913818 | 116.363625 |",
]);

solve([
  "| Town | Latitude | Longitude |",
  "| Veliko Turnovo | 43.0757 | 25.6172 |",
  "| Monatevideo | 34.50 | 56.11 |",
]);
