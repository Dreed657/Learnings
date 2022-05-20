function timeToWalk(steps, meters, kmH) {
  let distance = steps * meters;
  let speedInMs = kmH / 3.6;
  let time = Math.floor(distance / speedInMs);
  let breaks = Math.floor(distance / 500);

  let hours = Math.floor(time / 3600);
  let minutes = Math.floor(time / 60);
  let seconds = Math.floor(time % 60);

  console.log(
    `${hours < 10 ? "0" + hours : hours}:${minutes + breaks}:${seconds}`
  );
}

timeToWalk(4000, 0.6, 5);
timeToWalk(2564, 0.7, 5.5);
