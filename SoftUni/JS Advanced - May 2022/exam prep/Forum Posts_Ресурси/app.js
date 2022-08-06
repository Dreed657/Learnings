window.addEventListener("load", solve);

function solve() {
  document.getElementById("publish-btn").addEventListener("click", () => {
    const title = document.getElementById("post-title");
    const category = document.getElementById("post-category");
    const content = document.getElementById("post-content");

    const titleValue = title.value;
    const categoryValue = category.value;
    const contentValue = content.value;

    if (titleValue == "" || categoryValue == "" || contentValue == "") {
      return;
    }

    const liEl = document.createElement("li");

    const articleEl = document.createElement("article");
    const titleEl = document.createElement("h4");
    const categoryEl = document.createElement("p");
    const contentEl = document.createElement("p");

    titleEl.innerText = titleValue;
    categoryEl.innerText = "Category: " + categoryValue;
    contentEl.innerText = "Content: " + contentValue;

    articleEl.appendChild(titleEl);
    articleEl.appendChild(categoryEl);
    articleEl.appendChild(contentEl);

    const editBtn = document.createElement("button");
    const approveBtn = document.createElement("button");

    editBtn.addEventListener("click", () => {
      liEl.remove();
      title.value = titleValue;
      category.value = categoryValue;
      content.value = contentValue;
    });
    editBtn.innerText = "Edit";
    editBtn.classList.add("action-btn", "edit");

    approveBtn.addEventListener("click", () => {
      document.getElementById("published-list").appendChild(liEl);
      editBtn.remove();
      approveBtn.remove();
    });
    approveBtn.innerText = "Approve";
    approveBtn.classList.add("action-btn", "approve");

    liEl.appendChild(articleEl);
    liEl.appendChild(editBtn);
    liEl.appendChild(approveBtn);
    liEl.classList.add("rpost");

    document.getElementById("review-list").appendChild(liEl);

    title.value = "";
    category.value = "";
    content.value = "";
  });

  document.getElementById("clear-btn").addEventListener("click", () => {
    document.getElementById("published-list").innerText = "";
  });
}
