const pool = require('../config/db');

// Obtener un producto por ID
exports.getProductById = async (req, res) => {
  const id = req.params.id;

  try {
    const [result] = await pool.execute(
      `SELECT * FROM products WHERE product_id = ?`,
      [id]
    );

    res.json(result[0] || {});
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al consultar la información del producto' });
  }
};

// Obtener todos los productos
exports.getAllProducts = async (req, res) => {
  try {
    const [result] = await pool.execute(
      `SELECT * FROM products`
    );

    res.json(result || {});
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al obtener los productos' });
  }
};

// Obtener los productos por nombre
exports.getProductsByName = async (req, res) => {
  const query = req.query.q;
  try {
    const [result] = await pool.execute(
      `SELECT * FROM products WHERE name LIKE ?`,
      [`%${query}%`]
    );

    res.json(result || []);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al buscar los productos en la base de datos' });
  }
};

// Obtener todos los productos por categoría
exports.getProductsByCategory = async (req, res) => {
  const category = req.query.q;
  try {
    const [result] = await pool.execute(
      `SELECT * FROM products WHERE category = ?`,
      [category]
    );

    res.json(result || []);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al obtener los productos por categoria' });
  }
};

// Obtener todos los productos por subcategoría
exports.getProductsBySubcategory = async (req, res) => {
  const subcategory = req.query.q;
  try {
    const [result] = await pool.execute(
      `SELECT * FROM products WHERE subcategory = ?`,
      [subcategory]
    );

    res.json(result || []);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al obtener los productos por subcategoria' });
  }
};

// Obtener todos los productos por genero
exports.getProductsByGenre = async (req, res) => {
  const genre = req.query.q;
  try {
    const [result] = await pool.execute(
      `SELECT * FROM products WHERE genre = ?`,
      [genre]
    );

    res.json(result || []);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al obtener los productos por genero'});
  }
};

// Obtener los productos de la categoría hot
exports.getHotProducts = async (req, res) => {
  const subcategory = req.query.q;
  try {
    let result;
    if (subcategory == "top-sells") {
      [result] = await pool.execute(
        `SELECT * FROM products WHERE is_top_sell = 1`,
      );
    } else if (subcategory == "new") {
      [result] = await pool.execute(
        `SELECT * FROM products WHERE is_new = 1`,
      );
    } else {
      [result] = await pool.execute(
        `SELECT * FROM products WHERE is_offer = 1`,
      );
    }

    // Revolver el arreglo result
    for (let i = result.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [result[i], result[j]] = [result[j], result[i]];
    }

    res.json(result || []);
  } catch (err) {
    console.error(err.response?.data || err.message);
    res.status(500).json({ error: 'Error al obtener los productos por genero'});
  }
};
