import React from 'react';
import { CartProvider, useCart } from '../../context/CartContext'; // Asegúrate de la ruta correcta
import { Link } from 'react-router-dom'; // Si estás usando React Router

const ProductoDePrueba = ({ id, name, price, image }) => {
  const {cartItems, addToCart } = useCart();
  console.log('Carrito después de añadir:', cartItems);
  return (
    <div style={{ border: '1px solid #ccc', padding: '10px', margin: '10px' }}>
      <h3>{name}</h3>
      {image && <img src={image} alt={name} style={{ maxWidth: '100px', maxHeight: '100px' }} />}
      <p>Precio: ${price.toFixed(2)}</p>
      <button onClick={() => addToCart({ id, name, price, image })}>Añadir al carrito</button>
      
    </div>
    
  );
  
  
};

const TestProductosPage = () => {
  return (
    <div>
      <h1>Página de Productos de Prueba</h1>
      <ProductoDePrueba
        id={1}
        name="Disco de vinilo Meet the Beatles"
        price={29.99}
        image="/productsImages/vinyls/meetTheBeatlesVinyl.png" // Reemplaza con una imagen real si tienes
      />
      <ProductoDePrueba
        id={2}
        name="Taza con logo de la banda"
        price={12.50}
        image="https://via.placeholder.com/100/00FF00/FFFFFF?Text=Taza" // Reemplaza con una imagen real si tienes
      />
      <ProductoDePrueba
        id={3}
        name="Camiseta vintage"
        price={25.00}
        image="https://via.placeholder.com/100/0000FF/FFFFFF?Text=Camiseta" // Reemplaza con una imagen real si tienes
      />
      <Link to="/cart">Ir al Carrito</Link> {/* Asegúrate de que la ruta sea correcta */}
    </div>
  );
};

const TestProductosPageWrapper = () => (
    <TestProductosPage />
);

export default TestProductosPageWrapper;