const express = require("express");
const cors = require("cors");
const bodyParser = require("body-parser");
const logger = require("./logger");
const mongoose = require("mongoose");

const dotenv = require("dotenv");
dotenv.config();

const PORT = process.env.PORT || 9999;
const app = express();

console.log(process.env.MONGODB);

mongoose.connect(process.env.MONGODB, {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});

const db = mongoose.connection;
db.on("error", console.error.bind(console, "connection error:"));
db.once("open", function () {
  console.log("CONNECTION TO DB IS GOOOOOOD");
});

const kittySchema = new mongoose.Schema({
  name: String,
});

const Kitten = mongoose.model("Kitten", kittySchema);

app.use(express.urlencoded({ extended: true }));
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.json());
app.use(cors());
app.use(logger);

app.get("/", (req, res) => res.send("Hello World!"));

app.get("/env", (req, res) => {
  return res.status(200).send({
    PORT: process.env.PORT,
    MONGODB: process.env.MONGODB,
  });
});

app.get("/kittens", (req, res) => {
  Kitten.find()
    .then((kittens) => {
      res.send({ Count: kittens.length, kittens });
    })
    .catch((err) => {
      res.status(500).send(err);
    });
});

app.get("/kittens/:id", (req, res) => {
  Kitten.findById(req.params.id)
    .then((kitten) => {
      if (!kitten) {
        res
          .status(404)
          .send({ message: "This exact litte fuck it's in the bag" });
      }
      res.status(200).send(kitten);
    })
    .catch((err) => {
      res.status(500).send(err);
    });
});

app.post("/kittens", (req, res) => {
  if (!req.body.name) {
    return res.status(400).send({
      message: "Name can not be empty!",
    });
  }

  const kitten = new Kitten({
    name: req.body.name || "Random",
  });

  kitten
    .save()
    .then((data) => {
      res.send(data);
    })
    .catch((err) => {
      res.status(500).send(err);
    });
});

app.listen(PORT, console.log(`Server is listeing on ${PORT}...`));
