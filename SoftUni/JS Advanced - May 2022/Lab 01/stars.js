function stars(n) {
  for (let i = 0; i < n - 1; i++) {
    let row = [];

    //top left
    for (let y = n - 1; y > i; y--) {
      row.push(" ");
    }
    for (let y = 0; y <= i; y++) {
      row.push("*");
    }

    //top right
    for (let y = 0; y < i; y++) {
      row.push("*");
    }

    console.log(row.join(" "));
  }

  for (let i = 0; i < n; i++) {
    let row = [];

    //bottom left
    for (let y = 0; y < i; y++) {
      row.push(" ");
    }
    for (let y = i; y < n - 1; y++) {
      row.push("*");
    }

    //bottom right
    for (let y = i; y < n; y++) {
      row.push("*");
    }

    console.log(row.join(" "));
  }
}

// stars(1);
// stars(2);
// stars(5);
// stars(7);
stars(20);
