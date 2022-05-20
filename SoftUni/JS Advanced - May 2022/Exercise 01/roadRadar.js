function radar(speed, zone) {
  let zoneLimit;

  switch (zone) {
    case "motorway":
      zoneLimit = 130;
      break;
    case "interstate":
      zoneLimit = 90;
      break;
    case "city":
      zoneLimit = 50;
      break;
    case "residential":
      zoneLimit = 20;
      break;
  }

  if (speed <= zoneLimit) {
    console.log(`Driving ${speed} km/h in a ${zoneLimit} zone`);
    return;
  }

  let difference = speed - zoneLimit;
  let valuationType;

  if (difference <= 20) {
    valuationType = "speeding";
  } else if (difference <= 40) {
    valuationType = "excessive speeding";
  } else {
    valuationType = "reckless driving";
  }

  console.log(
    `The speed is ${difference} km/h faster than the allowed speed of ${zoneLimit} - ${valuationType}`
  );
}

radar(0, "residential");
radar(15, "residential");
radar(20, "residential");
radar(21, "residential");
radar(25, "residential");
radar(45, "residential");
radar(145, "residential");

radar(40, "city");
radar(21, "residential");
radar(120, "interstate");
radar(200, "motorway");
