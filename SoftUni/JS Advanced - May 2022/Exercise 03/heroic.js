function solve(arr) {
  var result = [];

  for (let hero of arr) {
    let [name, level, items] = hero.split(" / ");

    result.push({
      name,
      level: Number(level),
      items: items ? items.split(", ") : [],
    });
  }

  return JSON.stringify(result);
}

solve([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
solve(["Jake / 1000 / Gauss, HolidayGrenade"]);
