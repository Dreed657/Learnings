function solve(obj) {
  var result = {};

  result.model = obj.model;

  if (obj.power <= 90) {
    result.engine = { power: 90, volume: 1800 };
  } else if (obj.power <= 120) {
    result.engine = { power: 120, volume: 2400 };
  } else if (obj.power <= 200) {
    result.engine = { power: 200, volume: 3500 };
  }

  result.carriage = { type: obj.carriage, color: obj.color };
  result.wheels = new Array(4).fill(
    obj.wheelsize % 2 ? obj.wheelsize : obj.wheelsize - 1,
    0,
    4
  );

  console.log(result);
}

solve({
  model: "VW Golf II",
  power: 90,
  color: "blue",
  carriage: "hatchback",
  wheelsize: 14,
});
solve({
  model: "Opel Vectra",
  power: 110,
  color: "grey",
  carriage: "coupe",
  wheelsize: 17,
});
