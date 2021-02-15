const config = {
    development: {
        PORT: 3000
    },
    production: {
        PORT:80
    }
}

// TODO: Add process env getter
module.exports = config['development'];