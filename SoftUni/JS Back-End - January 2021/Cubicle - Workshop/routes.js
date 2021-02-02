const { Router } = require('express');

const homeController = require('./controllers/homeController');
const cubesController = require('./controllers/cubesController');
const acessoryController = require('./controllers/accessoryController');

const router = Router();

router.use(homeController);
router.use('/cubes', cubesController);
router.use('/accessories', acessoryController);
router.get('*', (req, res) => {
    res.render('404', { title: 'Page Not Found' });
});

module.exports = router;