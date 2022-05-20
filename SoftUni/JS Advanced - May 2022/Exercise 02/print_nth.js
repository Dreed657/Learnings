function printNth(arr, n) {
  return arr
    .map((e, i) => {
      if (!(i % n)) {
        return e;
      }
    })
    .filter((e) => e != undefined);
}

console.log(printNth(["5", "20", "31", "4", "20"], 2));
console.log(printNth(["dsa", "asd", "test", "tset"], 2));
console.log(printNth(["1", "2", "3", "4", "5"], 6));
