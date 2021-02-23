const express = require('express');

const PORT = 3000;
const app = express();

require('./config/mnogoose')();
require('./config/express')(app);

require('./routes/note.routes')(app);

app.listen(PORT, console.log(`Server is listeing on ${PORT}...`));