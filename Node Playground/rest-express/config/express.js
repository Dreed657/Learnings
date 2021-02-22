const express = require('express');
const bodyParser = require('body-parser');
const logger = require('../middlewares/logger');

module.exports = (app) => {
    app.use(bodyParser.urlencoded({ extended: true }));

    app.use(bodyParser.json());

    app.use(logger);
}