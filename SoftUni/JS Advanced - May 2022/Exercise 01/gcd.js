function getGcd(n0, n1) {
  let result = (x, y) => {
    if (!y) {
      return x;
    }

    return result(y, x % y);
  };

  console.log(result(n0, n1));
}

getGcd(15, 5);
getGcd(2154, 458);
