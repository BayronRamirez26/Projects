# Proyecto 1 - Sinfonola

Este proyecto es una aplicación web desarrollada con Vite en el cliente y un servidor Node.js con Express. La aplicación permite a los usuarios explorar productos musicales como cassettes, CDs y vinilos.

## Requisitos previos

Es necesario tener instalados los siguientes programas en el sistema:

- [Node.js](https://nodejs.org/) (versión 14 o superior)
- [npm](https://www.npmjs.com/) (incluido con Node.js)

## Instrucciones para ejecutar el programa

### 1. Clonar el repositorio

Clonar este repositorio en la máquina local utilizando el siguiente comando:

```bash
git clone https://github.com/tu-usuario/tu-repositorio.git
```

### 2. Instalar dependencias

#### Cliente

Navegar a la carpeta del cliente y ejecutar el siguiente comando para instalar las dependencias necesarias:

```bash
cd proyecto1/client
npm install
```

#### Servidor

Navegar a la carpeta del servidor y ejecutar el siguiente comando para instalar las dependencias necesarias:

```bash
cd ../server
npm install
```

Instalar las dependencias específicas del servidor ejecutando el siguiente comando:

```bash
npm install express cors axios dotenv jsonwebtoken
```

### 3. Ejecutar el cliente

Para iniciar el cliente, navegar a la carpeta `client` y ejecutar el siguiente comando:

```bash
npm run dev
```

### 4. Ejecutar el servidor

Para iniciar el servidor, navegar a la carpeta `server` y ejecutar el siguiente comando:

```bash
cd ../server/src
node server.js
```
