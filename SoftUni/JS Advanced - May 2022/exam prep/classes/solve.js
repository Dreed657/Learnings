class Garden {
  constructor(spaceAvailable) {
    this.spaceAvailable = spaceAvailable;
    this.plants = [];
    this.storage = [];
  }

  addPlant(plantName, spaceRequired) {
    if (this.spaceAvailable < spaceRequired) {
      throw new Error("Not enough space in the garden.");
    }

    this.plants.push({
      plantName,
      spaceRequired,
      ripe: false,
      quantity: 0,
    });
    this.spaceAvailable -= spaceRequired;

    return `The ${plantName} has been successfully planted in the garden.`;
  }

  ripenPlant(plantName, quantity) {
    const plant = this.plants.find((p) => p.plantName == plantName);

    if (!plant) {
      throw new Error(`There is no ${plantName} in the garden.`);
    }

    if (plant.ripe) {
      throw new Error(`The ${plantName} is already ripe.`);
    }

    if (quantity <= 0) {
      throw new Error("The quantity cannot be zero or negative.");
    }

    plant.ripe = true;
    plant.quantity += quantity;

    return quantity == 1
      ? `${quantity} ${plantName} has successfully ripened.`
      : `${quantity} ${plantName}s have successfully ripened.`;
  }

  harvestPlant(plantName) {
    const plant = this.plants.find((p) => p.plantName == plantName);

    if (!plant) {
      throw new Error(`There is no ${plantName} in the garden.`);
    }

    if (!plant.ripe) {
      throw new Error(
        `The ${plantName} cannot be harvested before it is ripe.`
      );
    }

    const plantIndex = this.plants.findIndex((p) => p.plantName == plantName);
    this.plants.splice(plantIndex, 1);
    this.storage.push({ plantName: plant.plantName, quantity: plant.quantity });
    this.spaceAvailable += plant.spaceRequired;

    return `The ${plantName} has been successfully harvested.`;
  }

  generateReport() {
    const result = [];

    result.push(`The garden has ${this.spaceAvailable} free space left.`);

    result.push(
      "Plants in the garden: " +
        this.plants
          .sort((a, b) => a.plantName.localeCompare(b.plantName))
          .map((p) => p.plantName)
          .join(", ")
    );

    if (this.storage.length < 1) {
      result.push("Plants in storage: The storage is empty.");
    } else {
      result.push(
        "Plants in storage: " +
          this.storage.map((p) => `${p.plantName} (${p.quantity})`).join(", ")
      );
    }

    return result.join("\n");
  }
}
