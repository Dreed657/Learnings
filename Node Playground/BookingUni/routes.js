const { Router } = require('express');

const homeController = require('./controllers/homeController');

var router = Router();

router.use('/', homeController);

module.exports = router;