function solve(arr) {
  arr
    .sort((cur, next) => {
      if (cur.length === next.length) {
        return cur.localeCompare(next);
      }
      return cur.length - next.length;
    })
    .forEach((e) => console.log(e));
}

solve(["alpha", "beta", "gamma"]);
console.log("=====");
solve(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
console.log("=====");
solve(["test", "Deny", "omen", "Default"]);
