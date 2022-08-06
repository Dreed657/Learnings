const { expect } = require("chai");
const { lookupChar } = require("./charLookUp");

describe("lookupChar", () => {
  it("string not string", () => {
    expect(lookupChar(3, 3)).to.be.undefined;
  });

  it("index not number", () => {
    expect(lookupChar("asdasdasd", "index")).to.be.undefined;
  });

  it("index floating number", () => {
    expect(lookupChar("asdasdasd", 1.1)).to.be.undefined;
  });

  it("index less then length of string", () => {
    expect(lookupChar("asd", 30)).to.equal("Incorrect index");
  });

  it("not string", () => {
    expect(lookupChar("test", -30)).to.equal("Incorrect index");
  });

  it("working correctly", () => {
    expect(lookupChar("test", 2)).to.equal("s");
  });
});
