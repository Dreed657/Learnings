import { get, post, put, del } from "./api.js";

export async function getAllOffers() {
  return get("/data/offers?sortBy=_createdOn%20desc");
}

export async function getById(id) {
  return get(`/data/offers/${id}`);
}

export async function newOffer(data) {
  return post("/data/offers", data);
}

export async function editOffer(id, data) {
  return put(`/data/offers/${id}`, data);
}

export async function deleteOffer(id) {
  return del(`/data/offers/${id}`);
}
