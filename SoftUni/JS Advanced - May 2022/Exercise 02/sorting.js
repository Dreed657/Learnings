function sortingNumber(input) {
  let sort = input.slice().sort((a, b) => a - b);
  let sortReverse = input.slice().sort((a, b) => b - a);
  let arr = [];

  for (let i = 0; i < sort.length / 2; i++) {
    arr.push(sort[i], sortReverse[i]);
  }

  return arr;
}

console.log(sortingNumber([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
