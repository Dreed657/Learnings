const Hotel = require('../models/hotel');

async function getOne(id) {
    return Hotel.findById(id).lean();
}

async function getAll() {
    return Hotel.find({}).lean();
}

async function create({ name, city, freeRooms, imgUrl }, userId) {
    let hotel = new Hotel({
        Name: name,
        City: city,
        ImageUrl: imgUrl,
        FreeRooms: freeRooms,
        Owner: userId
    });

    return await hotel.save();
}

async function updateOne(hotelId, hotelData) {
    return await Hotel.updateOne({_id: hotelId}, hotelData);
}

async function deleteOne(hotelId) {
    return await Hotel.deleteOne({_id: hotelId});
}

module.exports = {
    getOne,
    getAll,
    create,
    updateOne,
    deleteOne,
};