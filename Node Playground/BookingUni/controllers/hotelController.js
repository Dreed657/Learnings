const { Router } = require('express');

const userService = require('../services/userService');
const hotelService = require('../services/hotelService');
const isAuthenticated = require('../middlewares/isAuthenticated');

const router = Router();

router.get('/create', isAuthenticated, (req, res) => {
    res.render('hotel/create', { username: req.user.username });
});

router.post('/create', isAuthenticated, async (req, res) => {
    const { name, city, freeRooms, imgUrl } = req.body;

    await hotelService.create({ name, city, freeRooms, imgUrl }, req.user._id)
        .then(() => res.redirect('/'))
        .catch(() => res.status(500).end());
});

router.get('/details/:hotelId', isAuthenticated, async (req, res) => {
    let hotel = await hotelService.getOne(req.params.hotelId);

    res.render('hotel/details', { hotel, username: req.user.username });
});

router.get('/edit/:hotelId', isAuthenticated, (req, res) => {
    hotelService.getOne(req.params.hotelId)
        .then(hotel => {
            console.log(hotel);
            res.render('hotel/edit', { hotel, username: req.user.username });
        })
        .catch(() => res.status(500).end());
});

router.post('/edit/:hotelId', isAuthenticated, async (req, res) => {
    const data = req.body;
    await hotelService.updateOne(req.params.hotelId, data);

    res.redirect(`/hotel/details/${req.params.hotelId}`);
});

router.delete('/delete/:hotelId', isAuthenticated, (req, res) => {
    hotelService.deleteOne(req.params.hotelId);

    res.redirect('/');
});

router.get('/book/:hotelId', isAuthenticated, async (req, res) => {
    await userService.bookHotel(req.params.hotelId, req.user._id)
        .then(() => res.redirect('/'))
        .catch(err => console.log(err));
});

module.exports = router;