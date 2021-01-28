const { Router } = require('express');

const router = Router();

router.get('/about', (req, res) => {
    res.render('about', { title: 'About page' });
});


module.exports = router;