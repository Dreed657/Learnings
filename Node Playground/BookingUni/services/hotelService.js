const hotel = require('../models/hotel');

async function getAll() {
    return hotel.find({}).lean();
}

module.exports = {
    getAll,
};