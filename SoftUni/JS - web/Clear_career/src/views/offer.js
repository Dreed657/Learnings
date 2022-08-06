import {
  applyToOffer,
  getTotalApplications,
  isUserApplied,
} from "../api/applications.js";
import { getById, deleteOffer } from "../api/offers.js";
import { html, nothing } from "../lib.js";
import { getUserData } from "../util.js";

const template = (
  offer,
  applications,
  isApplied,
  userData,
  onDelete,
  onApply
) => html`
  <!-- Details page -->
  <section id="details">
    <div id="details-wrapper">
      <img id="details-img" src=${offer.imageUrl} alt="example1" />
      <p id="details-title">${offer.title}</p>
      <p id="details-category">
        Category: <span id="categories">${offer.category}</span>
      </p>
      <p id="details-salary">
        Salary: <span id="salary-number">${offer.salary}</span>
      </p>
      <div id="info-wrapper">
        <div id="details-description">
          <h4>Description</h4>
          <span>${offer.description}</span>
        </div>
        <div id="details-requirements">
          <h4>Requirements</h4>
          <span>${offer.requirements}</span>
        </div>
      </div>
      <p>Applications: <strong id="applications">${applications}</strong></p>

      ${userData
        ? html`
            <!--Edit and Delete are only for creator-->
            <div id="action-buttons">
              ${userData.id == offer._ownerId
                ? html`
                    <a href=${`/offer/${offer._id}/edit`} id="edit-btn">Edit</a>
                    <a @click=${onDelete} id="delete-btn">Delete</a>
                  `
                : html`
                    <!--Bonus - Only for logged-in users ( not authors )-->
                    ${!isApplied
                      ? html`<a @click=${onApply} id="apply-btn">Apply</a>`
                      : nothing}
                  `}
            </div>
          `
        : nothing}
    </div>
  </section>
`;

export async function offerView(ctx) {
  const { id } = ctx.params;
  const userData = getUserData();

  const offer = await getById(id);
  const applications = await getTotalApplications(id);
  const isApplied = await isUserApplied(id, userData.id);

  console.log("appled?", isApplied);

  ctx.render(
    template(offer, applications, isApplied, userData, onDelete, onApply)
  );

  async function onDelete() {
    await deleteOffer(id);
    ctx.page.redirect("/dashboard");
  }

  async function onApply() {
    await applyToOffer(id);
    location.reload();
  }
}
