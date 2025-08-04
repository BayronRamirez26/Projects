import React, { useState, useEffect } from 'react';
import "./ProductDetail.css";
import Header from "../../components/Header/Header.jsx";
import Footer from "../../components/Footer/Footer.jsx";
import Product from "../../components/Product/Product.jsx"; // Asegúrate de tener este componente
import { useParams } from 'react-router-dom';
import { useCart } from '../../context/CartContext';

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

const ProductDetail = () => {
  const { id } = useParams();
  const { path } = useParams();
  const { addToCart } = useCart();
  const [quantity, setQuantity] = useState(1);
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Estado para productos recomendados (excluyendo el producto actual)
  const [soldProducts, setSoldProducts] = useState([]);

  // Cargar detalle del producto
  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/products/${id}`);
        if (!response.ok) {
          throw new Error('Producto no encontrado');
        }
        const data = await response.json();
        setProduct(data);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchProduct();
  }, [id]);

  // Cargar productos recomendados basados en la subcategoría
  useEffect(() => {
    if (!product?.subcategory || product.subcategory.length === 0) return;

    const fetchRecommendedBySubcategory = async () => {
      try {
        const subcategory = product.subcategory;
        console.log(subcategory)
        const response = await fetch(`${API_BASE_URL}/products/subcategory?q=${subcategory}`);

        if (!response.ok) {
          throw new Error('Error al obtener productos recomendados');
        }
        const data = await response.json();

        // Filtrar para no incluir el producto actual en las recomendaciones
        const filteredRecommendations = data.filter(item => item.product_id.toString() !== product.product_id.toString());

        setSoldProducts(filteredRecommendations);
      } catch (err) {
        console.error(err);
      }
    };

    fetchRecommendedBySubcategory();
  }, [product]);

  if (loading) return <p>Cargando...</p>;
  if (error) return <p>Error: {error}</p>;
  if (!product) return null;

  const artistName = product.artist;
  const genre = product.genre;
  const year = product.year || "No disponible";
  const imageUrl = product.image_path;
  const description = product.description || "No disponible";

  const handleAddToCart = () => {
    if (!product) return;

    addToCart({
      id: product.product_id,
      name: product.name,
      price: product.price,
      image: imageUrl,
      quantity: quantity
    });

    alert(`${quantity} ${product.name} añadido(s) al carrito!`);
  };

  return (
    <>
      <Header />
      <div className="product-detail">
        <div className="product-card">
          <div className="product-image-container">
            <img src={imageUrl} alt={product.name} className="product-image" />
          </div>
          <div className="product-info">
            <h2 className="product-name">{product.name}</h2>
            <ul className="product-description">
              {(product.category === 'formats' || product.category === 'pre-sell') && (
                <>
                  <li><strong>Artista:</strong> {artistName}</li>
                  <li><strong>Género:</strong> {genre}</li>
                </>
              )}
              {(product.category !== 'formats' && product.category !== 'pre-sell') && (
                <li><strong>Descripción: <br/></strong>{description}</li>
              )}
              <li><strong>Año:</strong> {year}</li>
            </ul>
            <div className="product-price">
              ${product.price}
            </div>
            <div className="product-actions">
              <div className="quantity-selector">
                <button
                  className="quantity-button"
                  onClick={() => setQuantity(prev => Math.max(1, prev - 1))}
                >
                  −
                </button>
                <span className="quantity-value">{quantity}</span>
                <button
                  className="quantity-button"
                  onClick={() => setQuantity(prev => prev + 1)}
                >
                  +
                </button>
              </div>
              <button
                className="add-to-cart-button"
                onClick={handleAddToCart}
              >
                AGREGAR AL CARRITO
              </button>
            </div>
          </div>
        </div>
      </div>

      <div className="products-row">
        <h2>Recomendaciones similares</h2>
        <div className="product-list">
          {soldProducts.slice(0, 4).map((recommendedProduct) => (
            <Product
              key={recommendedProduct.product_id}
              id={recommendedProduct.product_id}
              image={recommendedProduct.image_path}
              title={recommendedProduct.name}
              path={path}
            />
          ))}
        </div>
      </div>
      <Footer />
    </>
  );
};

export default ProductDetail;
