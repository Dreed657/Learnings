const express = require('express');
const handlerbars = require('express-handlebars');
const logger = require('../middlewares/logger')

function setupExpress(app) {
    app.engine('hbs', handlerbars({
        extname: 'hbs'
    }));

    app.set('view engine', 'hbs')

    app.use(express.static('static'));

    app.use(express.urlencoded({
        extended: true
    }));

    app.use(logger);
}

module.exports = setupExpress;