/*global process*/
require('dotenv').config();
require('./config/db');

console.log('A punto de iniciar el servidor...');
console.log('✅Configuración de la base de datos cargada correctamente.');

const app = require('./app');
const PORT = process.env.SERVER_PORT || 3001;

// Pone al servidor a escuchar en el puerto 3001
app.listen(PORT, () => {
  console.log(`✅ Servidor corriendo en http://localhost:${PORT}`);
})
