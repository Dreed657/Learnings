const express = require('express');

const PORT = process.env.PORT || 5000;
const app = express();

app.get('/', (req, res) => {
    res.send(`Response from ${PORT}`);
});

app.listen(PORT, () => {
    console.log(`Server is listing on ${PORT}...`)
});