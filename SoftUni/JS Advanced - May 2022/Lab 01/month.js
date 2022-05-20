function dayOfMonth(month, year) {
  let date = new Date(year, month, 0);

  console.log(date.getDate());
}

dayOfMonth(1, 2012);
dayOfMonth(2, 2021);
