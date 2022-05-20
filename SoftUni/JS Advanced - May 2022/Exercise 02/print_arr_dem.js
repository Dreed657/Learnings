function printArrDemiter(arr, d) {
  return arr.join(d);
}

console.log(printArrDemiter(["One", "Two", "Three", "Four", "Five"], "-"));
console.log(
  printArrDemiter(["How about no?", "I", "will", "not", "do", "it!"], "_")
);
