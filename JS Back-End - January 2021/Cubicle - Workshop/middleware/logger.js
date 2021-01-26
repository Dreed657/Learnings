module.exports = (req, res, next) => {
    console.log(`[${req.method}] URL: ${req.originalUrl}`);

    next();
};