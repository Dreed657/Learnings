import { html, nothing } from "../lib.js";

import { deleteMeme, getById } from "../api/memes.js";
import { getUserData } from "../util.js";

const memeDetails = (meme, userData, onDelete) => html`
  <!-- Details Meme Page (for guests and logged users) -->
  <section id="meme-details">
    <h1>${meme.title}</h1>
    <div class="meme-details">
      <div class="meme-img">
        <img alt="meme-alt" src=${meme.imageUrl} />
      </div>
      <div class="meme-description">
        <h2>Meme Description</h2>
        <p>${meme.description}</p>

        ${userData.id == meme._ownerId
          ? html`
              <a class="button warning" href="/edit/${meme._id}">Edit</a>
              <button class="button danger" @click=${onDelete}>Delete</button>
            `
          : nothing}
      </div>
    </div>
  </section>
`;

export async function memeDetailsView(ctx) {
  const { id } = ctx.params;

  const meme = await getById(id);
  const userData = getUserData();

  ctx.render(memeDetails(meme, userData, onDelete));

  async function onDelete() {
    await deleteMeme(id);
    ctx.page.redirect("/memes");
  }
}
