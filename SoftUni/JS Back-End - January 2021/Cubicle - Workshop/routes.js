const { Router } = require('express');

const homeController = require('./controllers/homeController');
const cubesController = require('./controllers/cubesController');

const router = Router();

router.use(homeController);
router.use(cubesController);
router.get('*', (req, res) => {
    res.render('404', { title: 'Page Not Found' });
});

module.exports = router;