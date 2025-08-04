const app = require('../app');
const axios = require('axios');
const path = require('path');
const filesystem = require('fs');

const accessoriesFile = path.join(__dirname, '../../data/accessories.json');

exports.getAccessoriesByType = async (req, res) => {
  const type = req.query.q;
  try {
    let accessories = [];
    if (filesystem.existsSync(accessoriesFile)) {
      const allaccessories = JSON.parse(filesystem.readFileSync(accessoriesFile));
      accessories = allaccessories.filter(accessory => accessory.type === type);
    }

    res.json(accessories);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información de reproductores' });
  }
};

// Obtener todos los reproductores por nombre
exports.getAccessoriesByName = async (req, res) => {
  const query = req.query.q;
  try {
    let accessories = [];
    if (filesystem.existsSync(accessoriesFile)) {
      const allAccessories = JSON.parse(filesystem.readFileSync(accessoriesFile));
      accessories = allAccessories.filter(accessory => accessory.title.toLowerCase().includes(query.toLowerCase()));
    }

    res.json(accessories);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información de reproductores' });
  }
};

// Obtener un accesorio por ID
exports.getAccessoryById = async (req, res) => {
  const id = req.params.id;
  try {
    let accessory = null;
    if (filesystem.existsSync(accessoriesFile)) {
      const allAccessories = JSON.parse(filesystem.readFileSync(accessoriesFile));
      accessory = allAccessories.find(accessory => accessory.id == id);
    }
    if (accessory) {
      res.json(accessory);
    } else {
      res.status(404).json({ error: 'Accesorio no encontrado' });
    }
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información del accesorio' });
  }
};
