class SmartHike {
  constructor(username) {
    this.username = username;
    this.goals = {};
    this.listOfHikes = [];
    this.resources = 100;
  }

  addGoal(peak, altitude) {
    if (this.goals.hasOwnProperty(peak)) {
      return `${peak} has already been added to your goals`;
    }

    this.goals[peak] = altitude;
    return `You have successfully added a new goal - ${peak}`;
  }

  hike(peak, time, difficultyLevel) {
    if (!this.goals.hasOwnProperty(peak)) {
      throw new Error(`${peak} is not in your current goals`);
    }

    if (this.resources <= 0) {
      throw new Error("You don't have enough resources to start the hike");
    }

    let requiredResources = time * 10;

    if (this.resources - requiredResources <= 0) {
      return "You don't have enough resources to complete the hike";
    }

    this.resources -= requiredResources;
    this.listOfHikes.push({ peak, time, difficultyLevel });
    let requiredResorcesInPercent = (this.resources / 100) * 100;

    return `You hiked ${peak} peak for ${time} hours and you have ${requiredResorcesInPercent}% resources left`;
  }

  rest(time) {
    let restTime = time * 10;
    this.resources += restTime;

    if (this.resources >= 100) {
      this.resources = 100;
      return `Your resources are fully recharged. Time for hiking!`;
    }

    return `You have rested for ${time} hours and gained ${restTime}% resources`;
  }

  showRecord(criteria) {
    if (this.listOfHikes.length == 0) {
      return `${this.username} has not done any hiking yet`;
    }

    if (criteria == "all") {
      let result = [];

      result.push("All hiking records:");

      for (let hike of this.listOfHikes) {
        result.push(
          `${this.username} hiked ${hike.peak} for ${hike.time} hours`
        );
      }

      return result.join("\n");
    } else {
      let fastest = this.listOfHikes
        .filter((h) => h.difficultyLevel == criteria)
        .sort((a, b) => b.time - a.time)[0];

      if (!fastest) {
        return `${this.username} has not done any ${criteria} hiking yet`;
      } else {
        return `${this.username}'s best ${criteria} hike is ${fastest.peak} peak, for ${fastest.time} hours`;
      }
    }
  }
}

const user = new SmartHike("Vili");
console.log(user.addGoal("Musala", 2925));
console.log(user.addGoal("Rui", 1706));
console.log(user.hike("Musala", 8, "hard"));
console.log(user.hike("Rui", 3, "easy"));
console.log(user.hike("Everest", 12, "hard"));
