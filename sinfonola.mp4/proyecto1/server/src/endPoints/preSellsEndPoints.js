const app = require('../app');
const axios = require('axios');
const path = require('path');
const filesystem = require('fs');

const preSellsFile = path.join(__dirname, '../../data/pre_sells.json');

exports.getPreSellProducts = async (req, res) => {
  const type = req.query.q;
  try {
    let preSells = [];
    if (filesystem.existsSync(preSellsFile)) {
      const allPreSells = JSON.parse(filesystem.readFileSync(preSellsFile));
      preSells = allPreSells.filter(product => product.type === type);
    }

    res.json(preSells);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información de reproductores' });
  }
};

// Obtener un producto de pre-venta por ID
exports.getPreSellProductById = async (req, res) => {
  const id = req.params.id;
  try {
    let product = null;
    if (filesystem.existsSync(preSellsFile)) {
      const allPreSells = JSON.parse(filesystem.readFileSync(preSellsFile));
      product = allPreSells.find(product => product.id == id);
    }

    if (product) {
      res.json(product);
    } else {
      res.status(404).json({ error: 'Producto de pre-venta no encontrado' });
    }
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información del producto de pre-venta' });
  }
};