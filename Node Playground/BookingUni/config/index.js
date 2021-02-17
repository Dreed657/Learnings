const config = {
    development: {
        PORT: 3000,
        DB_CONNECTION: 'mongodb://localhost/bookuni',
        SALT_ROUNDS: 10,
        SECRET: 'navuhodonosor',
        COOKIE_NAME: 'USER_SESSION',
    },
    production: {
        PORT:80,
        SALT_ROUNDS: 10,
        SECRET: 'navuhodonosor',
        COOKIE_NAME: 'USER_SESSION',
    }
}

// TODO: Add process env getter
module.exports = config['development'];