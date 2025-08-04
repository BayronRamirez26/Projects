const pool = require('../config/db');
const filesystem = require('fs');
const path = require('path');
const {encrypt, decrypt} = require('../utils/encryption')

// Web tokens para autenticación del usuario
const secretKey = process.env.JWT_SECRET || 'defaultSecret';
const jwt = require('jsonwebtoken');

// Archivo de usuarios
const usersFile = path.join(__dirname, '../../data/users.json');
let users = [];

exports.userRegister = async (req, res) => {
  const { email, name, phone, password } = req.body;

  // Extraer nombre y apellidos de name
  const parts = name.trim().split(/\s+/);
  const firstName = parts[0] || '';
  const lastName1 = parts[1] || '';
  const lastName2 = parts[2] || '';

  const encryptedPassword = encrypt(password);

  // Insertar usuario en la base de datos
  try {
    const [result] = await pool.execute(
      `INSERT INTO users (
        email,
        user_name,
        user_lastname_1,
        user_lastname_2,
        phone_number,
        password)
      VALUES (?, ?, ?, ?, ?, ?)`,
      [email, firstName, lastName1, lastName2, phone, encryptedPassword]
    );
    return res.status(201).json({ message: 'Usuario registrado correctamente', userId: result.insertId });
  } catch (err) {
    console.error('Error al registrar usuario:', err);
    res.status(500).json({ error: 'Error al registrar usuario' });
  }
};

// Comprobar si un usuario existe e iniciar sesión
exports.userLogin = async (req, res) => {
  const user = req.body;
  let userFromDB = null;

  // Trear información usando el correo
  try {
    const [result] = await pool.execute(
      `SELECT * FROM users WHERE email = ?`,
      [user.email]
    );

    if (result.length > 0) {
      userFromDB = result[0];
    }
  } catch {
    return res.status(404).json({ error: 'No se ha encontrado el usuario' });
  }

  // Comparar contraseña e iniciar sesión
  if (userFromDB !== null) {
    console.log('Usuario encontrado:', userFromDB);
    const decryptedPassword = decrypt(userFromDB.password)

    if (user.password === decryptedPassword) {
      const token = jwt.sign(
        { 
          id: userFromDB.id,
          email: userFromDB.email,
        },
        secretKey,
        { expiresIn: '1h' }
      );

      res.json({
        token,
        user: {
          email: userFromDB.email,
          name: userFromDB.name
        }
      });
    } else {
      return res.status(409).json({ message: 'Contraseña incorrecta' });
    }
  } else {
    return res.status(404).json({ message: 'Usuario no encontrado' });
  }
};

// Obtener datos del usuario usando el email
exports.getUserInfo = async (req, res) => {
  // Obtener el token de sesión
  const authHeader = req.headers.authorization;
  if (!authHeader?.startsWith('Bearer ')) {
    return res.status(401).json({ message: 'Token no proporcionado' });
  }
  const token = authHeader.split(' ')[1];

  try {
    // Verificar token de sesión
    const decoded = jwt.verify(token, secretKey);

    if (!decoded.email) {
      return res.status(403).json({ message: 'No autorizado' });
    }

    let userFromDB = null;

    // Traer información usando el correo
    try {
      const [result] = await pool.execute(
        `SELECT * FROM users WHERE email = ?`,
        [decoded.email]
      );

      if (result.length > 0) {
        userFromDB = result[0];
      }
    } catch {
      return res.status(409).json({ error: 'No se ha encontrado el usuario' });
    }

    if (userFromDB !== null) {
      // Devuelve la información del usuario
      userFromDB.name = [
        userFromDB.user_name || '',
        userFromDB.user_lastname_1 || '',
        userFromDB.user_lastname_2 || ''
      ].filter(Boolean).join(' ');

      res.json({
        name: userFromDB.name || '',
        phone: userFromDB.phone_number || '',
        email: userFromDB.email || '',
        city: userFromDB.city || '',
        zipCode : userFromDB.zip_code || '',
        address: userFromDB.address || '',
        cart: userFromDB.cart || []
      });
    }
  } catch {
    return res.status(401).json({ message: 'Token inválido' });
  }
};

// Nuevas funciones para el carrito
exports.getUserCart = async (req, res) => {
  try {
    let userCart = null;
    let products = null;

    // Traer información del carrito
    try {
      userCart = await pool.execute(
        `SELECT * FROM users_cart WHERE user_id = ?`,
        [req.user.id]
      );
    } catch {
      return res.status(500).json({ error: 'Error al obtener la información del carrito' });
    }

    if (userCart.length > 0) {
      // Traer información de los productos
      try {
        products = await pool.execute(
          `SELECT * FROM products`
        );
      } catch {
        return res.status(500).json({ error: 'Error al los productos' });
      }
    }
    
    if (userCart !== null && products !== null) {
      const cartWihDetails = userCart.map(item => {
        const product = products.find(p => p.id === item.product_id);
        return {
          ...item,
          name: product.name || '',
          price: product.price || '',
          image: product.image_path || ''
        };
      });

      res.json(cartWihDetails);
    } else {
      res.json([]);
    }
  } catch (error) {
    console.error('Error al obtener carrito:', error);
    res.status(500).json([]);;
  }
};

exports.updateUserCart = async (req, res) => {
  try {
    const { cart } = req.body;
    if (!Array.isArray(cart)) {
      return res.status(400).json({ message: 'Formato de carrito inválido' });
    }

    // Eliminar el carrito actual del usuario
    try {
      await pool.execute(
        `DELETE FROM users_cart WHERE user_id = ?`,
        [req.user.id]
      );
    } catch {
      return res.status(500).json({ error: 'Error al eliminar el carrito' });
    }

    // Insertar el nuevo carrito del usuario en la base de datos
    try {
      for (const item of cart) {
        await pool.execute(
          `INSERT INTO users_cart (
            product_id,
            user_id,
            quantity
          ) VALUES (?, ?, ?)`,
          [item.product_id, req.user.id, item.quantity]
        );
      }

      return res.status(201).json({ message: 'Carrito actualizado correctamente', cartId: result.insertId });
    } catch {
      return res.status(500).json({ error: 'Error al actualizar el carrito'});
    }
  } catch {
    return res.status(500).json({ message: 'Algo salio mal al actualzar el carrito' });
  }
};

exports.syncCart = async (req, res) => {
  const { localCart } = req.body;
  const userId = req.user.id;

  try {
    // Obtener el carrito actual del usuario desde la base de datos
    const [dbCart] = await pool.execute(
      'SELECT * FROM users_cart WHERE user_id = ?',
      [userId]
    );

    // Fusionar carritos
    const mergedCart = [...dbCart];
    localCart.forEach(item => {
      const existingIndex = mergedCart.findIndex(i => i.product_id === item.id);
      if (existingIndex >= 0) {
        mergedCart[existingIndex].quantity += item.quantity;
      } else {
        mergedCart.push({ product_id: item.id, quantity: item.quantity });
      }
    });

    // Limpiar el carrito actual del usuario en la base de datos
    await pool.execute('DELETE FROM users_cart WHERE user_id = ?', [userId]);

    // Insertar el carrito fusionado
    for (const item of mergedCart) {
      await pool.execute(
        'INSERT INTO users_cart (user_id, product_id, quantity) VALUES (?, ?, ?)',
        [userId, item.product_id, item.quantity]
      );
    }

    res.json(mergedCart);
  } catch (error) {
    console.error('Error al sincronizar carrito:', error);
    res.status(500).json({ message: 'Error interno del servidor' });
  }
};
