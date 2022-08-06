function solve(arr, direction) {
  let methods = {
    asc: (a, b) => a - b,
    desc: (a, b) => b - a,
  };

  return arr.sort(methods[direction]);
}

console.log(solve([14, 7, 17, 6, 8], "asc"));
console.log(solve([14, 7, 17, 6, 8], "desc"));
