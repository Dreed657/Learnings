const { expect } = require("chai");
const bookSelection = require("./bookSelection");

describe("bookSelection", () => {
  describe("isGenreSuitable", () => {
    it("happy path", () => {
      expect(bookSelection.isGenreSuitable("Thriller", 2)).to.equal(
        "Books with Thriller genre are not suitable for kids at 2 age"
      );
      expect(bookSelection.isGenreSuitable("Horror", 5)).to.equal(
        "Books with Horror genre are not suitable for kids at 5 age"
      );
    });

    it("Age above 12", () => {
      expect(bookSelection.isGenreSuitable("Horror", 50)).to.equal(
        "Those books are suitable"
      );
    });

    it("Wrong ganre", () => {
      expect(bookSelection.isGenreSuitable("Comedy", 5)).to.equal(
        "Those books are suitable"
      );
    });

    it("Age not number", () => {
      expect(bookSelection.isGenreSuitable("Comedy", "5")).to.equal(
        "Those books are suitable"
      );
    });
  });

  describe("isItAffordable", () => {
    it("Happy path", () => {
      expect(bookSelection.isItAffordable(5, 10)).to.equal(
        "Book bought. You have 5$ left"
      );
      expect(bookSelection.isItAffordable(15, 10)).to.equal(
        "You don't have enough money"
      );
    });

    it("Invalid input", () => {
      expect(() => bookSelection.isItAffordable("5", 10)).to.throw(
        "Invalid input"
      );
      expect(() => bookSelection.isItAffordable(15, "10")).to.throw(
        "Invalid input"
      );
    });
  });

  describe("suitableTitles", () => {
    it("Happy path", () => {
      expect(
        bookSelection.suitableTitles(
          [
            { title: "Movie 1", genre: "Horror" },
            { title: "Movie 2", genre: "Thriller" },
            { title: "Movie 3", genre: "Horror" },
          ],
          "Horror"
        )
      ).to.deep.equal(["Movie 1", "Movie 3"]);
    });

    it("Invalid input", () => {
      expect(() => bookSelection.suitableTitles("Movie 1", "Horror")).to.throw(
        "Invalid input"
      );
      expect(() =>
        bookSelection.suitableTitles(
          [
            { title: "Movie 1", genre: "Horror" },
            { title: "Movie 2", genre: "Thriller" },
            { title: "Movie 3", genre: "Horror" },
          ],
          530
        )
      ).to.throw("Invalid input");
    });
  });
});
