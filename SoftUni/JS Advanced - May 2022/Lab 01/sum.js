function sum(a, b) {
  let sum = 0;

  for (let i = Number(a); i <= Number(b); i++) {
    sum += i;
  }

  console.log(sum);
}

sum("1", "5");
sum("-8", "20");
