const app = require('../app');
const axios = require('axios');
const path = require('path');
const filesystem = require('fs');

const hotProductsFile = path.join(__dirname, '../../data/hot.json');

exports.getHotProductsByType = async (req, res) => {
  const type = req.query.q;
  try {
    let hotProducts = [];
    if (filesystem.existsSync(hotProductsFile)) {
      const allHotProducts = JSON.parse(filesystem.readFileSync(hotProductsFile));
      hotProducts = allHotProducts.filter(product => product.type === type);
    }

    res.json(hotProducts);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información de reproductores' });
  }
};

// Obtener un producto hot por ID
exports.getHotProductById = async (req, res) => {
  const id = req.params.id;
  try {
    let product = null;
    if (filesystem.existsSync(hotProductsFile)) {
      const allHotProducts = JSON.parse(filesystem.readFileSync(hotProductsFile));
      product = allHotProducts.find(product => product.id == id);
    }
    
    if (product) {
      res.json(product);
    } else {
      res.status(404).json({ error: 'Producto hot no encontrado' });
    }
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información del producto hot' });
  }
};