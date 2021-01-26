const { create } = require('express-handlebars');
const fs = require('fs');
const path = require('path');
const cubesDb = require('../config/database.json');

module.exports = {
    getAll() {
        return cubesDb;
    },

    getOne(id) {
        return cubesDb.find(x => x.id == id);
    },

    create(cube) {
        cubesDb.push(cube);

        return fs.writeFile(path.join(__dirname, '../config/database.json'), JSON.stringify(cubesDb), (err) => {
            if (err) {
                console.log(err);
                return;
            }
        });
    }
};