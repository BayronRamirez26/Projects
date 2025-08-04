const express = require('express');
const authMiddleware = require('./endPoints/authMiddleware');
const router = express.Router();

// Endpoints para las rutas
const usersEndPoints = require('./endPoints/usersEndPoints');
const productsEndPoints = require ('./endPoints/productsEndPoints');
const discogsEndPoints = require('./endPoints/discogsEndPoints');
const ebayEndPoints = require('./endPoints/ebayEndPoints');
const playersEndPoints = require('./endPoints/playersEndPoints')
const accesoriesEndPoints = require('./endPoints/accessoriesEndPoints');
const hotEndPoints = require('./endPoints/hotEndPoints');
const preSellsEndPoints = require('./endPoints/preSellsEndPoints');
const { processPayment } = require('./endPoints/paymentEnpoints');

// Rutas para los usuarios
router.post('/users/register', usersEndPoints.userRegister);
router.post('/users/login', usersEndPoints.userLogin)
router.get('/users/getInfo', usersEndPoints.getUserInfo)
router.get('/users/cart',authMiddleware, usersEndPoints.getUserCart);
router.put('/users/cart', authMiddleware, usersEndPoints.updateUserCart);
router.post('/users/cart/sync', authMiddleware, usersEndPoints.syncCart);

// Rutas para los productos
router.get('/products', productsEndPoints.getAllProducts);
router.get('/products/search', productsEndPoints.getProductsByName);
router.get('/products/category', productsEndPoints.getProductsByCategory);
router.get('/products/subcategory', productsEndPoints.getProductsBySubcategory);
router.get('/products/formats/genre', productsEndPoints.getProductsByGenre);
router.get('/products/category/hot', productsEndPoints.getHotProducts);
router.get('/products/:id', productsEndPoints.getProductById);

// Rutas para Discogs
router.get('/discogs/products', discogsEndPoints.getDiscogsProducts);
router.get('/discogs/search', discogsEndPoints.getDiscogsProducts);
router.get('/discogs/products/:id', discogsEndPoints.getDiscogsProductById);
router.get('/discogs/genre', discogsEndPoints.getDiscogsProductsByGenre);
router.get('/discogs/style', discogsEndPoints.getDiscogsProductsByStyle);

// Rutas para eBay
router.get('/ebay/products', ebayEndPoints.getEbayProducts);
router.get('/ebay/products/:id', ebayEndPoints.getEbayProductById);

// Rutas para los productos de los .json
router.get('/players/products', playersEndPoints.getPlayersByType);
router.get('/players/search', playersEndPoints.getPlayersByName);
router.get('/players/products/:id', playersEndPoints.getPlayerById);

router.get('/accessories/products', accesoriesEndPoints.getAccessoriesByType);
router.get('/accessories/search', accesoriesEndPoints.getAccessoriesByName);
router.get('/accessories/products/:id', accesoriesEndPoints.getAccessoryById);

router.get('/hot/products', hotEndPoints.getHotProductsByType);
router.get('/hot/products/:id', hotEndPoints.getHotProductById);

router.get('/pre-sells/products', preSellsEndPoints.getPreSellProducts);
router.get('/pre-sells/products/:id', preSellsEndPoints.getPreSellProductById);

//Ruta Payment
router.post('/payment', processPayment);

module.exports = router;