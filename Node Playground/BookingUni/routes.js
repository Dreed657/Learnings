const { Router } = require('express');

const homeController = require('./controllers/homeController');
const userController = require('./controllers/userController');
const hotelController = require('./controllers/hotelController');

var router = Router();

router.use('/', homeController);
router.use('/hotel', hotelController);
router.use('/user', userController);

module.exports = router;