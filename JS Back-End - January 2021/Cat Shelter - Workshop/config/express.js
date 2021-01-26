const express = require('express');
const handlebars = require('express-handlebars');
const logger = require('../middleware/logger');

module.exports = (app) => {
    app.engine('hbs', handlebars({
        extname: 'hbs',
    }));

    app.set('view engine', 'hbs');

    app.use(express.static('public'));

    app.use(express.urlencoded({
        extended: true,
    }));

    app.use(logger);
};