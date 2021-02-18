const { Router } = require('express');

const hotelService = require('../services/hotelService');

const router = Router();

router.get('/', (req, res) => {
    hotelService.getAll()
        .then(hotels => {
            res.render('index', { hotels, username: req.user?.username });
        })
        .catch(() => res.status(500).end());
});

module.exports = router;