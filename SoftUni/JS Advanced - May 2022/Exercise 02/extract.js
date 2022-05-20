function extract(arr) {
  var result = [];

  arr.reduce((a, v) => {
    if (v >= a) {
      result.push(v);
      a = v;
    }

    return a;
  }, 0);

  return result;
}

console.log(extract([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log("-----");
console.log(extract([1, 2, 3, 4]));
console.log("-----");
console.log(extract([20, 3, 2, 15, 6, 1]));
