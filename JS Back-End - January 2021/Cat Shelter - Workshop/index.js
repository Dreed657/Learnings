const express = require('express');

const config = require('./config/config');
const app = express();

require('./config/express')(app);

app.get('/', (req, res) => {
    res.render('index');
});

app.listen(config.PORT, () => console.log(`Server is listening on https://localhost:${config.PORT}...`));