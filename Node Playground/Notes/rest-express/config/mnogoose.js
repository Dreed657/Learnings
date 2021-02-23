const config = require('./index');
const mongoose = require('mongoose');

module.exports = () => {
    mongoose.Promise = global.Promise;

    mongoose.connect(config.url, {
        useNewUrlParser: true,
        useUnifiedTopology: true
    }).then(() => {
        console.log("Successfully connected to the database!");
    }).catch(err => {
        console.error('Could not connect to the database. Exiting now...', err);
        process.exit();
    });

}