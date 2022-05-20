function radius(r) {
  let argType = typeof r;
  if (argType != "number") {
    console.log(
      `We can not calculate the circle area, because we receive a ${argType}.`
    );
    return;
  }

  console.log((Math.PI * Math.pow(r, 2)).toFixed(2));
}

radius(5);
radius("name");
