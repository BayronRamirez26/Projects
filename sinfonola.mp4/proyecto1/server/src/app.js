// Configuración del servidor
const express = require('express');
const cors = require('cors');
require('dotenv').config();
const routes = require('./routes')

const app = express();
app.use(cors());
app.use(express.json());

// Rutas del servidor
app.use('/', routes);

module.exports = app;