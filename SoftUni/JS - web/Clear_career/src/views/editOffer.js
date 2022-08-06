import { editOffer, getById } from "../api/offers.js";
import { html } from "../lib.js";

const template = (onSubmit, data) => html`
  <!-- Edit Page (Only for logged-in users) -->
  <section id="edit">
    <div class="form">
      <h2>Edit Offer</h2>
      <form @submit=${onSubmit} class="edit-form">
        <input
          type="text"
          name="title"
          id="job-title"
          placeholder="Title"
          value=${data.title}
        />
        <input
          type="text"
          name="imageUrl"
          id="job-logo"
          placeholder="Company logo url"
          value=${data.imageUrl}
        />
        <input
          type="text"
          name="category"
          id="job-category"
          placeholder="Category"
          value=${data.category}
        />
        <textarea
          id="job-description"
          name="description"
          placeholder="Description"
          rows="4"
          cols="50"
        >
${data.description}
      </textarea>
        <textarea
          id="job-requirements"
          name="requirements"
          placeholder="Requirements"
          rows="4"
          cols="50"
        >
${data.requirements}</textarea
        >
        <input
          type="text"
          name="salary"
          id="job-salary"
          placeholder="Salary"
          value=${data.salary}
        />

        <button type="submit">post</button>
      </form>
    </div>
  </section>
`;

export async function editOfferView(ctx) {
  const { id } = ctx.params;

  const offer = await getById(id);

  ctx.render(template(onSubmit, offer));

  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const title = formData.get("title");
    const imageUrl = formData.get("imageUrl");
    const category = formData.get("category");
    const description = formData.get("description");
    const requirements = formData.get("requirements");
    const salary = formData.get("salary");

    if (
      !title ||
      !imageUrl ||
      !category ||
      !description ||
      !requirements ||
      !salary
    ) {
      alert("All fields are required!");
      return;
    }

    await editOffer(id, {
      title,
      imageUrl,
      category,
      description,
      requirements,
      salary,
    });
    ctx.page.redirect(`/offer/${id}`);
  }
}
