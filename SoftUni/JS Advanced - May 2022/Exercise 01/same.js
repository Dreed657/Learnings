function sameFunc(n) {
  n = n.toString();

  let firstLetter = n[0];
  let isSame = true;
  let sum = 0;

  for (let i = 0; i < n.length; i++) {
    if (n[i] != firstLetter) {
      isSame = false;
    }

    sum += Number(n[i]);
  }

  console.log(isSame);
  console.log(sum);
}

sameFunc(2222222);
sameFunc(1234);
