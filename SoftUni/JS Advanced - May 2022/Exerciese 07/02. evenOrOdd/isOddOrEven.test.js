import { expect } from "chai";
import { isOddOrEven } from "./isOddOrEven";

describe("isOddOrEven", () => {
  it("not string", () => {
    expect(isOddOrEven(2)).to.be.undefined;
  });

  it("even", () => {
    expect(isOddOrEven("test")).to.equal("even");
  });

  it("odd", () => {
    expect(isOddOrEven("tests")).to.equal("odd");
  });
});
