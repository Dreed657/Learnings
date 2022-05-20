function extractUpper(str) {
  console.log(
    str
      .split(/[.|,| |?|!]+/)
      .filter((w) => w !== "")
      .map((w) => {
        return w.toUpperCase();
      })
      .join(", ")
  );
}

extractUpper("Hi, how are you?");
extractUpper("Dot. Comma, Space Exclamation! Question?");
extractUpper("hello");
