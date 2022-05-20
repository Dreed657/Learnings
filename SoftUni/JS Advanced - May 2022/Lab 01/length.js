function length(...words) {
  let total = words.reduce((v, c) => (v += c.length));

  console.log(total);
  console.log(Math.floor(total / words.length));
}

length("chocolate", "ice cream", "cake");
length("pasta", "5", "22.3");
