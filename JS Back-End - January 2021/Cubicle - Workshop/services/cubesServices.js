const uniqid = require('uniqid');
const Cube = require('../models/cube');
const cubeData = require('../data/cubeData');

function getAll(query) {
    let result = cubeData.getAll();

    if (query.search) {
        result = result.filter(x => x.name.toLocaleLowerCase().includes(query.search));
    }

    if (query.from) {
        result = result.filter(x => x.level >= query.from);
    }

    if (query.to) {
        result = result.filter(x => x.level <= query.to);
    }

    return result;
}

function getOne(id) {
    return cubeData.getOne(id);
}

function create(data) {
    let cube = new Cube(
        uniqid(),
        data.name,
        data.description,
        data.imageUrl,
        data.difficultyLevel
    );

    return cubeData.create(cube);
}

module.exports = {
    getAll,
    getOne,
    create,
}