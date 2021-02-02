const Accessory = require('../models/Accessory');
const Cube = require('../models/cube');

function getAll(query) {
    let result = Cube.find({}).lean();

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
    return Cube.findById(id).lean();
}

function create(data) {
    let cube = new Cube(data);

    return cube.save();
}

function getOneWithAccessories(id) {
    return Cube.findById(id)
        .populate('accessories')
        .lean();
}

async function attachAccessory(productId, accessoryId) {
    let product = await Cube.findById(productId)
    let accessry = await Accessory.findById(accessoryId);

    product.accessories.push(accessry);
    return product.save();
}

module.exports = {
    getAll,
    getOne,
    create,
    getOneWithAccessories,
    attachAccessory,
}