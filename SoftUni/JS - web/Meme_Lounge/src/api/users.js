import { clearUserData, setUserData } from "../util.js";
import { get, post } from "./api.js";

export async function login(email, password) {
  const result = await post("/users/login", { email, password });

  setUserData(convertResultToUserData(result));

  return result;
}

export async function register(username, email, password, gender) {
  const result = await post("/users/register", {
    username,
    email,
    password,
    gender,
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
    username: result.username,
    email: result.email,
    gender: result.gender,
    accessToken: result.accessToken,
  };
}
