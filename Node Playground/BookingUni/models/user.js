const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const { SALT_ROUNDS, SECRET } = require('../config');

const userSchema = new mongoose.Schema({
    id: mongoose.Types.ObjectId,
    Email: {
        type: String,
        required: true,
        unique: true
    },
    Username: {
        type: String,
        required: true,
        unique: true
    },
    Password: {
        type: String,
        required: true
    },
    BookedHotels: [{
        type: mongoose.Types.ObjectId,
        ref: 'Hotel'
    }],
    OfferedHotels: [{
        type: mongoose.Types.ObjectId,
        ref: 'Hotel'
    }]
});

userSchema.pre('save', function(next) {
    bcrypt.genSalt(SALT_ROUNDS)
        .then(salt => {
            return bcrypt.hash(this.Password, salt);
        })
        .then(hash => {
            this.Password = hash;
            next();
        })
        .catch(err => {
            console.error(err);
        })
});

module.exports = mongoose.model('User', userSchema);