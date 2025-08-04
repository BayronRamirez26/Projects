const app = require('../app');
const axios = require('axios');
const path = require('path');
const filesystem = require('fs');

const playersFile = path.join(__dirname, '../../data/players.json');

// Obtener todos los reproductores
exports.getPlayersByType = async (req, res) => {
  const type = req.query.q;
  try {
    let players = [];
    if (filesystem.existsSync(playersFile)) {
      const allPlayers = JSON.parse(filesystem.readFileSync(playersFile));
      players = allPlayers.filter(player => player.type === type);
    }

    res.json(players);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información de reproductores' });
  }
};

// Obtener todos los reproductores por nombre
exports.getPlayersByName = async (req, res) => {
  const query = req.query.q;
  try {
    let players = [];
    if (filesystem.existsSync(playersFile)) {
      const allPlayers = JSON.parse(filesystem.readFileSync(playersFile));
      players = allPlayers.filter(player => player.title.toLowerCase().includes(query.toLowerCase()));
    }

    res.json(players);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información de reproductores' });
  }
};

// Obtener un reproductor por ID
exports.getPlayerById = async (req, res) => {
  const id = req.params.id;
  try {
    let player = null;
    if (filesystem.existsSync(playersFile)) {
      const allPlayers = JSON.parse(filesystem.readFileSync(playersFile));
      player = allPlayers.find(player => player.id == id);
    }
    
    if (player) {
      res.json(player);
    } else {
      res.status(404).json({ error: 'Reproductor no encontrado' });
    }
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información del reproductor' });
  }
};
