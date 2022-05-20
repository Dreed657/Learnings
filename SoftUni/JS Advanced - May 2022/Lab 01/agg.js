function agg(arr) {
  console.log(arr.reduce((v, c) => (v += c)));
  console.log(arr.reduce((v, c) => v + 1 / c, 0));
  console.log(arr.join(""));
}

agg([1, 2, 3]);
agg([2, 4, 8, 16]);
