import { html } from "../lib.js";

import { getById, updateMeme } from "../api/memes.js";
import { notify } from "../notify.js";

const edit = (onSubmit, meme) => html`
  <!-- Edit Meme Page ( Only for logged user and creator to this meme )-->
  <section id="edit-meme">
    <form @submit=${onSubmit} id="edit-form">
      <h1>Edit Meme</h1>
      <div class="container">
        <label for="title">Title</label>
        <input
          id="title"
          type="text"
          placeholder="Enter Title"
          name="title"
          value=${meme.title}
        />
        <label for="description">Description</label>
        <textarea
          id="description"
          placeholder="Enter Description"
          name="description"
        >
${meme.description}</textarea
        >
        <label for="imageUrl">Image Url</label>
        <input
          id="imageUrl"
          type="text"
          placeholder="Enter Meme ImageUrl"
          name="imageUrl"
          value=${meme.imageUrl}
        />
        <input type="submit" class="registerbtn button" value="Edit Meme" />
      </div>
    </form>
  </section>
`;

export async function editView(ctx) {
  const meme = await getById(ctx.params.id);

  ctx.render(edit(onSubmit, meme));

  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const title = formData.get("title");
    const description = formData.get("description");
    const imageUrl = formData.get("imageUrl");

    if (!title || !description || !imageUrl) {
      notify("All fields are required!");
      console.log("error happend!");
      return;
    }

    console.log("no error");

    const result = await updateMeme(
      ctx.params.id,
      title,
      description,
      imageUrl
    );

    ctx.page.redirect(`/memes/${result._id}`);
  }
}
