const { Router } = require('express');

const isGuest = require('../middlewares/isGuest');
const isAuthenticated = require('../middlewares/isAuthenticated');

const userService = require('../services/userService');
const { COOKIE_NAME } = require('../config/index');

const router = Router();

router.get('/login', isGuest, (req, res) => {
    res.render('user/login');
});

router.post('/login', isGuest, async (req, res) => {
    const { username, password } = req.body;

    try {
        let token = await userService.login({ username, password });

        res.cookie(COOKIE_NAME, token);
        res.redirect('/');
    } catch (error) {
        res.render('user/login', { error });
    }
});

router.get('/register', isGuest, (req, res) => {
    res.render('user/register');
});

router.post('/register', isGuest, async (req, res) => {
    const { email, username, password, rePassword } = req.body;

    if (password != rePassword) {
        return res.render('user/register', { errors: { message: 'Passwords missmatch!' }});
    }

    try {
        let user = await userService.register({Email: email, Username: username, Password: password });

        res.redirect('/user/login');
    } catch (errors) {
        console.log(errors);
        // let errors = Object.keys(err?.errors).map(x => ({ message: err.errors[x].properties.message }))[0];

        res.render('user/register', { errors });
    }
})

router.get('/logout', isAuthenticated, (req, res) => {
    res.clearCookie(COOKIE_NAME);
    res.redirect('/');
});

router.get('/profile', (req, res) => {
    res.render('user/profile');
});

module.exports = router;