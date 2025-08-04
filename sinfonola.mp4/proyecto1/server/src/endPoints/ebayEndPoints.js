const app = require('../app');
const axios = require('axios');
require('dotenv').config();
const fs = require('fs');
const path = require('path');

const clientId = process.env.EBAY_CLIENT_ID;
const clientSecret = process.env.EBAY_CLIENT_SECRET;

const getToken = async () => {
  const credentials = Buffer.from(`${clientId}:${clientSecret}`).toString('base64');

  try {
    const response = await axios.post(
      'https://api.ebay.com/identity/v1/oauth2/token',
      'grant_type=client_credentials&scope=https://api.ebay.com/oauth/api_scope',
      {
        headers: {
          Authorization: `Basic ${credentials}`,
          'Content-Type': 'application/x-www-form-urlencoded',
        },
      }
    );

    return response.data.access_token;
  } catch (error) {
    console.error('Error al obtener el token de eBay:', error.response?.data || error.message);
    throw new Error('No se pudo obtener el token de eBay');
  }
};

// Obtener productos de eBay
exports.getEbayProducts = async (req, res) => {
  try {
    const token = await getToken();

    let response = await axios.get('https://api.ebay.com/buy/browse/v1/item_summary/search', {
      params: { 
        q: req.query.q ,
        condition_ids: '1000',
      },
      headers: {
        Authorization: `Bearer ${token}`,
        'X-Locale': 'es_ES',
      },
    });

    const items = response.data.itemSummaries || [];
    const processedItems = items.map(item => ({
      id: item.itemId,
      title: item.title,
      price: item.price.value,
      cover_image: item.image?.imageUrl || '',
      year: item.itemOriginDate.substring(0, 4)
    }));

    // Guardar en cassetePlayers.json
    // const dataPath = path.join(__dirname, '../../data/cases.json');
    // fs.writeFileSync(dataPath, JSON.stringify(processedItems, null, 2), 'utf8');
    
    res.json({itemSummaries: processedItems});
    
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar eBay' });
  }
};

// Obtener un solo producto de eBay por id
exports.getEbayProductById = async (req, res) => {
  try {
    const id = req.params.id;
    const token = await getToken();
    const response = await axios.get(`https://api.ebay.com/buy/browse/v1/item/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    res.json(response.data);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar eBay' });
  }
};