function prevDay(year, month, day) {
  let date = new Date(year, month, day, 0, 0, 0, 0);

  date.setDate(date.getDate() - 1);

  console.log(`${date.getFullYear()}-${date.getMonth()}-${date.getUTCDate()}`);
}

prevDay(2016, 9, 30);
prevDay(2016, 10, 1);
