import React, { useState, useEffect } from "react";
import Product from "../../components/Product/Product.jsx";
import "./OrdersClient.css";

const API_BASE_URL = "http://localhost:3001";

const orderStatus = {
  0: "Por enviar",
  1: "Enviado para entrega",
  2: "Entregado",
  3: "Cancelado",
};

export default function OrdersClient({ orders }) {
  const [products, setProducts] = useState([]);

  const allProductIds = orders.flatMap(order => order.slice(3));
  console.log(allProductIds);
  
  const uniqueIds = [...new Set(allProductIds)];

  useEffect(() => {
    async function fetchAllProducts() {
      try {
        const vinyls = await fetch(`${API_BASE_URL}/discogs/products?q=vinyl`).then(res => res.json());
        const cds = await fetch(`${API_BASE_URL}/discogs/products?q=CD`).then(res => res.json());
        const cassettes = await fetch(`${API_BASE_URL}/discogs/products?q=cassette`).then(res => res.json());

        const all = [...vinyls, ...cds, ...cassettes];
        setProducts(all);
      } catch (error) {
        console.error("Error al traer productos Discogs:", error);
      }
    }

    fetchAllProducts();
  }, []);


  if (!orders || orders.length === 0) {
    return <p>No hay órdenes en tu historial.</p>;
  }

  return (
    <div className="orders-container">
      {orders.map((order, index) => {
        const [orderId, totalPrice, status, ...productIds] = order;

        return (
          <div key={index} className="order">
            <div className="order-header">
              <p className={status === 1 ? "status-shipped" : "status-other"}>
                {orderStatus[status]}
              </p>
              <p><strong>Total: ${totalPrice.toLocaleString()}</strong></p>
            </div>

            <div className="products">
              {productIds.map((id, idx) => {
                const product = products.find(p => String(p.id) === String(id));

                if (!product) {
                  return (
                    <div key={idx} className="product">
                      <p>Producto no encontrado: {id}</p>
                    </div>
                  );
                }

                return (
                  <div key={idx} className="product-card">
                    <div className="product-image-container">
                      <img
                        src={product.cover_image || product.image}
                        alt={product.title}
                        className="product-image"
                        onError={(e) => {
                          e.target.onerror = null;
                          e.target.src = "/productsImages/cds/1989CD.png";
                        }}
                      />
                    </div>
                    <div className="product-info">
                      <h4 className="product-name">{product.title}</h4>
                    </div>
                  </div>
                );
              })}
            </div>
          </div>
        );
      })}
    </div>
  );
}
