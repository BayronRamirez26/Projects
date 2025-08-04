const app = require('../app')
const axios = require('axios')

const DISCOGS_TOKEN = "hUrTFDKLtWGwRHbvLsJlDhPuADPNVUcGJBUtKjCX"


// Obtener todos los productos de Discogs
exports.getDiscogsProducts = async (req, res) => {
  try {
    const query = req.query.q;

    // Obtiene los productos de la base de datos de Discogs
    const response = await axios.get('https://api.discogs.com/database/search', {
      params: {
        q: query,
        format: ['vinyl', 'cassette', 'CD'],
        type: 'release',
        token: DISCOGS_TOKEN,
      },
    });

    // Filtrar títulos con menos de 40 caracteres y eliminar duplicados por title
    const seenTitles = new Set();
    const filteredItems = (response.data.results || []).filter(
      item => {
        const valid =
          item.title &&
          item.cover_image &&
          !item.cover_image.includes("spacer.gif") &&
          item.title.length <= 40 &&
          item.title !== "Mak* - Mas Fiestas Con El Grupo Mak" &&
          !seenTitles.has(item.title);
        if (valid) seenTitles.add(item.title);
        return valid;
      }
    );

    const allItems = filteredItems.map(item => ({
      ...item,
      type: query
    }));

    // Devolver respuesta con productos filtrados
    res.json(allItems);

  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar Discogs' });
  }
};


// Obtener un solo producto de discogs por id
exports.getDiscogsProductById = async (req, res) => {
  try {
    const id = req.params.id;
    const response = await axios.get(`https://api.discogs.com/releases/${id}`, {
      params: { token: DISCOGS_TOKEN },
    });

    let item = { 
      ...response.data, 
      type: response.data.genres ? response.data.genres.join(', ') : "No disponible" 
    };

    res.json(item);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar Discogs' });
  }
};

// Obtener productos por genero
exports.getDiscogsProductsByGenre = async (req, res) => {
  try {
    const query = req.query.q;

    // Obtiene los productos de la base de datos de Discogs
    const response = await axios.get('https://api.discogs.com/database/search', {
      params: {
        format: ['vinyl', 'CD', 'cassette'],
        genre: query,
        token: DISCOGS_TOKEN,
        per_page: 10, // por ejemplo
      },
    });

    // Filtrar títulos con menos de 40 caracteres y eliminar duplicados por title
    const seenTitles = new Set();
    const filteredItems = (response.data.results || []).filter(
      item => {
        const valid =
          item.title &&
          item.cover_image &&
          !item.cover_image.includes("spacer.gif") &&
          !seenTitles.has(item.title);
        if (valid) seenTitles.add(item.title);
        return valid;
      }
    );

    // Devolver respuesta con productos filtrados
    res.json(filteredItems);

  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar Discogs' });
  }
};

// Obtener los productos de Discogs por estilo
exports.getDiscogsProductsByStyle = async (req, res) => {
  try {
    const query = req.query.q;

    // Obtiene los productos de la base de datos de Discogs
    const response = await axios.get('https://api.discogs.com/database/search', {
      params: {
        format: ['vinyl', 'CD', 'cassette'],
        style: query,
        token: DISCOGS_TOKEN,
      },
    });

    // Filtrar títulos con menos de 40 caracteres y eliminar duplicados por title
    const seenTitles = new Set();
    const filteredItems = (response.data.results || []).filter(
      item => {
        const valid =
          item.title &&
          item.cover_image &&
          !item.cover_image.includes("spacer.gif") &&
          !seenTitles.has(item.title);
        if (valid) seenTitles.add(item.title);
        return valid;
      }
    );

    // Devolver respuesta con productos filtrados
    res.json(filteredItems);

  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar Discogs' });
  }
};