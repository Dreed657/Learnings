const mongoose = require('mongoose');

const postSchema = new mongoose.Schema({
    content: String,
    createdOn: Date
});

module.exports = mongoose.model('Post', postSchema);