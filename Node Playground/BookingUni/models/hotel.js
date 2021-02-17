const mongoose = require('mongoose');

const hotelSchema = new mongoose.Schema({
    id: mongoose.Types.ObjectId,
    Name: {
        type: String,
        required: true,
        unique: true
    },
    City: {
        type: String,
        required: true
    },
    ImageUrl: {
        type: String,
        required: true
    },
    FreeRooms: {
        type: Number,
        required: true,
        min: 1,
        max: 100
    },
    Users: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }],
    Owner: {
        type: String,
        required: true
    }
});

module.exports = mongoose.model('Hotel', hotelSchema);