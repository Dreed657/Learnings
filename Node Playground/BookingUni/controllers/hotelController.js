const { Router } = require('express');

const hotelService = require('../services/hotelService');

const router = Router();

router.get('/create', (req, res) => {
    res.render('hotel/create');
});

router.get('/details', (req, res) => {
    res.render('hotel/details');
});

router.get('/edit', (req, res) => {
    res.render('hotel/edit');
});

module.exports = router;