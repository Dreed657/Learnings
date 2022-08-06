export const USER_DATA_SESSION_STORAGE_KEY_NAME = "userData";

export function getUserData() {
  return JSON.parse(sessionStorage.getItem(USER_DATA_SESSION_STORAGE_KEY_NAME));
}

export function setUserData(data) {
  sessionStorage.setItem(
    USER_DATA_SESSION_STORAGE_KEY_NAME,
    JSON.stringify(data)
  );
}

export function clearUserData() {
  sessionStorage.removeItem(USER_DATA_SESSION_STORAGE_KEY_NAME);
}
