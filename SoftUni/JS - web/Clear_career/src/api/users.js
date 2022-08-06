import { clearUserData, setUserData } from "../util.js";
import { get, post } from "./api.js";

export async function login(email, password) {
  const result = await post("/users/login", { email, password });

  setUserData(convertResultToUserData(result));

  return result;
}

export async function register(email, password) {
  const result = await post("/users/register", {
    email,
    password,
  });

  setUserData(convertResultToUserData(result));

  return result;
}

export async function logout() {
  await get("/users/logout");
  clearUserData();
}

function convertResultToUserData(result) {
  return {
    id: result._id,
    email: result.email,
    accessToken: result.accessToken,
  };
}
