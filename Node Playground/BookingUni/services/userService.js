const User = require('../models/user');
const Hotel = require('../models/hotel');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SECRET } = require('../config/index');

async function getOne(id) {
    return await User.findById(id)
        .populate('BookedHotels')
        .lean();
}

async function login({ username, password }) {
    let user = await User.findOne({ Username: username });
    if (!user) {
        throw { messege: 'User not found' };
    }

    let isMatch = await bcrypt.compare(password, user.Password);
    if (!isMatch) {
        throw { message: 'Password does not match' };
    }
    
    console.log(user);

    let token = jwt.sign({ _id: user._id, username: user.Username }, SECRET);


    console.log(token);
    console.log(SECRET);
    return token;
}

async function register({Email, Username, Password}) {
    const user = new User({
        Email,
        Username,
        Password
    });

    return await user.save();
}

async function bookHotel(hotelId, userId){
    let hotel = await Hotel.findById(hotelId);
    let user = await User.findById(userId);

    user.BookedHotels.push(hotel._id);
    hotel.Users.push(user._id);
    return await user.save();
}

module.exports = {
    login,
    register,
    getOne,
    bookHotel,
};