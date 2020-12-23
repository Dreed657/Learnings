import * as _ from 'underscore';

class User {
    constructor(public name: string, public age: number) {}

    doSomething() {
        return _.range(0, 10, 1);
    }
}

const gosho = new User('Gosho', 20);

console.log(gosho.doSomething);