import { get, post } from "../api/api.js";

export async function getTotalApplications(offerId) {
  return get(
    `/data/applications?where=offerId%3D%22${offerId}%22&distinct=_ownerId&count`
  );
}

export async function isUserApplied(offerId, userId) {
  const result = await get(
    `/data/applications?where=offerId%3D%22${offerId}%22%20and%20_ownerId%3D%22${userId}%22&count`
  );

  return result === 1;
}

export async function applyToOffer(offerId) {
  return post("/data/applications", { offerId });
}
