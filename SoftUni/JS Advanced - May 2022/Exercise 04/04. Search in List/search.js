function search() {
  let searchTerm = document.getElementById("searchText").value;
  let listItems = [...document.querySelectorAll("li")];
  let result = document.getElementById("result");

  console.log(listItems);

  let matched = listItems.filter((e) => e.textContent.includes(searchTerm));

  matched.map((e) => {
    e.style["text-decoration"] = "underline";
    e.style["font-weight"] = "bold";
  });

  result.textContent = `${matched.length} matches found`;
}
