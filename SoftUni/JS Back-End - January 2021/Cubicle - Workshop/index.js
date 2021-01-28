const express = require('express');

const routes = require('./routes');
const config = require('./config/config');
const app = express();

require('./config/express')(app);

app.use(routes);

app.listen(config.PORT, () => console.log(`Server is listening on https://localhost:${config.PORT}...`));