const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const logger = require('../middlewares/logger');

module.exports = (app) => {
    app.use(bodyParser.urlencoded({ extended: true }));

    app.use(bodyParser.json());

    app.use(cors());

    app.use(logger);
}