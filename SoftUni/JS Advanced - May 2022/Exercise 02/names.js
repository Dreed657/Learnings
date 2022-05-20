function names(arr) {
  arr.sort().forEach((e, i) => {
    console.log(`${i + 1}.${e}`);
  });
}

names(["John", "Bob", "Christina", "Ema"]);
