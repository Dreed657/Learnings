const { expect } = require("chai");
const carService = require("./03. Car service_Resources");

describe("carService", function () {
  describe("isItExpensive", function () {
    it("happy path", function () {
      expect(carService.isItExpensive("Engine")).to.equal(
        "The issue with the car is more severe and it will cost more money"
      );
      expect(carService.isItExpensive("Transmission")).to.equal(
        "The issue with the car is more severe and it will cost more money"
      );
    });

    it("invalid input", function () {
      expect(carService.isItExpensive("Brakes")).to.equal(
        "The overall price will be a bit cheaper"
      );
    });
  });

  describe("discount", function () {
    it("happy path", function () {
      // No discount
      expect(carService.discount(2, 1000)).to.equal(
        "You cannot apply a discount"
      );

      // 15%
      expect(carService.discount(5, 1000)).to.equal(
        `Discount applied! You saved ${150}$`
      );

      // 30%
      expect(carService.discount(10, 1000)).to.equal(
        `Discount applied! You saved ${300}$`
      );
    });

    it("invalid input", function () {
      expect(() => carService.discount("2", 1000)).to.throw("Invalid input");
      expect(() => carService.discount(5, "1000")).to.throw("Invalid input");
    });
  });

  describe("partsToBuy", function () {
    const catalog = [
      {
        part: "oil",
        price: 50,
      },
      {
        part: "oil filter",
        price: 10,
      },
      {
        part: "fuel filter",
        price: 10,
      },
    ];
    const partsNeeded = ["oil filter", "oil"];

    it("happy path", function () {
      expect(carService.partsToBuy(catalog, partsNeeded)).to.equal(60);
    });

    it("invalid input", function () {
      expect(() => carService.partsToBuy("not array", [])).to.throw(
        "Invalid input"
      );
      expect(() => carService.partsToBuy([], "not array")).to.throw(
        "Invalid input"
      );
    });
  });
});
