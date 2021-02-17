const express = require('express');
const handlerbars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const logger = require('../middlewares/logger')
const auth = require('../middlewares/auth');

function setupExpress(app) {
    app.engine('hbs', handlerbars({
        extname: 'hbs'
    }));

    app.set('view engine', 'hbs')

    app.use(express.static('static'));

    app.use(express.urlencoded({
        extended: true
    }));

    app.use(cookieParser());

    app.use(logger);
    app.use(auth());
}

module.exports = setupExpress;