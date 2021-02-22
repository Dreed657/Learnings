const Post = require('./post.js');

async function getAll() {
    return await Post.find({}).lean();
}

async function create({content})  {
    let post = new Post(content, new Date());

    return await post.save();
}

module.exports = {
    getAll,
    create,
};