const { Router } = require('express');
const cubesService = require('../services/cubesServices'); 
const accessoryService = require('../services/accessoryService');

const router = Router();

router.get('/', (req, res) => {
    cubesService.getAll(req.query)
        .then(cubes => {
            console.log(cubes);
            res.render('index', { title: 'Browse', cubes });
        })
        .catch(() => res.status(500).end());
    
});

router.get('/details/:id', (req, res) => {
    cubesService.getOneWithAccessories(req.params.id)
        .then(cube => {
            res.render('details', { title: `This is ${req.params.id}`, cube });
        })
        .catch(() => res.status(500).end());
});

router.get('/create', (req, res) => {
    res.render('create', { title: 'Create new cube' });
});

router.post('/create', (req, res) => {
    cubesService.create(req.body);
    res.redirect('/');
});

router.get('/:cubeId/attach', async (req, res) => {
    let cube = await cubesService.getOne(req.params.cubeId);
    let accessories = await accessoryService.getAllUnattached(cube.accessories);

    res.render('attachAccessory', {cube, accessories});
});

router.post('/:cubeId/attach', (req, res) => {
    cubesService.attachAccessory(req.params.cubeId, req.body.accessory)
        .then(() => res.redirect(`/cubes/details/${req.params.cubeId}`))
});

module.exports = router;