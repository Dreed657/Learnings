const express = require("express");

const PORT = process.env.PORT || 5000;
const app = express();

app.get("/", (req, res) => {
  res.send(`Response from ${PORT}`);
});

app.get("/env", (req, res) => {
  res.json({
    timestamp: new Date(),
    pid: process.pid,
    platform: process.platform,
    version: process.version,
    versions: process.versions,
  });
});

app.get("/update", (req, res) => {
  res.json({
    message: "containers has been updated!",
    timestamp: new Date(),
  });
});

// app.get("/data", (req, res) => {
//   res.json({
//     friends: [
//       {
//         id: 0,
//         name: "Latisha Boyle",
//       },
//       {
//         id: 1,
//         name: "Florine Kaufman",
//       },
//       {
//         id: 2,
//         name: "Allison Holman",
//       },
//     ],
//   });
// });

app.listen(PORT, () => {
  console.log(`Server is listing on ${PORT}...`);
});
