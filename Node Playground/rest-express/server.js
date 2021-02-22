const express = require('express');
const postService = require('./postService')

const PORT = process.env.PORT || 3000;
const app = express();
require('./db')();


app.use(express.json());

app.use((req, res, next) => {
    console.log(`%c [${req.method}] ${req.originalUrl}`, "color: green");
    next();
});

app.get('/', (req, res) => {
    res.send('Rest Api is living here!');
});

app.get('/api/post', async (req, res) => {
    await postService.getAll()
        .then(posts => res.json(posts))
        .catch(err => res.sendStatus(500).end(err.message));
});

app.post('/api/post', (req, res) => {
    console.log(req.body);
    postService.create(req.body)
        .then(post => res.json(post))
        .catch(err => res.sendStatus(500).end(err));
});

app.listen(PORT, console.log(`Server is listing on port ${PORT}....`));