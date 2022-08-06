import { get, post, put, del } from "./api.js";

export async function getAllMemes() {
  return get("/data/memes?sortBy=_createdOn%20desc");
}

export async function getById(id) {
  return get(`/data/memes/${id}`);
}

export async function getByUserId(userId) {
  return get(
    `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
  );
}

export async function createMeme(title, description, imageUrl) {
  return post("/data/memes", { title, description, imageUrl });
}

export async function updateMeme(id, title, description, imageUrl) {
  return put(`/data/memes/${id}`, { title, description, imageUrl });
}

export async function deleteMeme(id) {
  return del(`/data/memes/${id}`);
}
