const { Router } = require('express');
const cubesService = require('../services/cubesServices'); 

const router = Router();

router.get('/', (req, res) => {
    let cubes = cubesService.getAll(req.query);

    res.render('index', { title: 'Browse', cubes });
});

router.get('/details/:id', (req, res) => {
    let cube = cubesService.getOne(req.params.id);

    if (!cube) {
        res.redirect('/');
    }
    
    res.render('details', { title: `This is ${req.params.id}`, cube });
});

router.get('/create', (req, res) => {
    res.render('create', { title: 'Create new cube' });
});

router.post('/create', (req, res) => {
    cubesService.create(req.body);
    res.redirect('/');
});


module.exports = router;