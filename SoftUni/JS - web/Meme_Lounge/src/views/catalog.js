import { html } from "../lib.js";

import { getAllMemes } from "../api/memes.js";

const catalog = (memes) => html`
  <!-- All Memes Page ( for Guests and Users )-->
  <section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
      ${
        memes.length != 0
          ? memes.map(memeCard)
          : html`<p class="no-memes">No memes in database.</p>`
      }

  </section>
`;

const memeCard = (meme) => html`
  <div class="meme">
    <div class="card">
      <div class="info">
        <p class="meme-title">${meme.title}</p>
        <img class="meme-image" alt="meme-img" src=${meme.imageUrl} />
      </div>
      <div id="data-buttons">
        <a class="button" href="/memes/${meme._id}">Details</a>
      </div>
    </div>
  </div>
`;

export async function catalogView(ctx) {
  const memes = await getAllMemes();

  ctx.render(catalog(memes));
}
