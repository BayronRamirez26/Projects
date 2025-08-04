import { useState } from 'react'
import { Link } from 'react-router-dom';
import { useCart } from '../../context/CartContext';
import Header from '../../components/Header/Header';
import Footer from '../../components/Footer/Footer';
import './CartPage.css';


function CartPage() {
  const {
    cartItems,
    discountedAmount,
    removeFromCart,
    updateQuantity,
    total,
    itemCount,
    applyCoupon,
    clearCart
  } = useCart();

  const [couponCode, setCouponCode] = useState('');
  console.log('Carrito en CartPage:', cartItems);
  // Calcular subtotal, envío e impuestos
  const subtotal = cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
  const shipping = 1.00; // Costo fijo de envío
  const taxes = 0.00; // Impuestos calculables
  const discount = 0.00; // Descuento por cupón

  return (
    <>
      <Header />
      <div className="cart-container">
        <table className="cart-table">
          <thead>
            <tr>
              <th>Producto</th>
              <th>Precio Unitario</th>
              <th>Cantidad</th>
              <th>Total</th>
            </tr>
          </thead>
          <tbody>
            {cartItems.map((item) => (
              <tr key={item.id}>
                <td>
                  <div className="product-info">
                    {item.image && <img src={item.image} alt={item.name} />}
                    <span>{item.name}</span>
                  </div>
                </td>
                <td>${item.price}</td>
                <td>
                  <div className="quantity-controls">
                    <button onClick={() => updateQuantity(item.id, item.quantity - 1)}>-</button>
                    <span>{item.quantity}</span>
                    <button onClick={() => updateQuantity(item.id, item.quantity + 1)}>+</button>
                  </div>
                </td>
                <td>${(item.price * item.quantity)?.toFixed(2)}</td>
                <td>
                  <button
                    onClick={() => removeFromCart(item.id)}
                    className="remove-btn"
                  >
                    ×
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <div className="cart-summary-container">
          {/* Acciones del carrito (limpiar) */}
          {cartItems.length > 0 && (
            <div className="cart-actions">
              <button onClick={clearCart} className="clear-cart-btn">
                Limpiar carrito
              </button>
            </div>
          )}

          {/* Sección del cupón */}
          <div className="coupon-section">
            <h3>Código del cupón</h3>
            <input
              type="text"
              value={couponCode}
              onChange={(e) => setCouponCode(e.target.value)}
              placeholder="Ingresa tu código"
            />
            <button
              onClick={() => applyCoupon(couponCode)}
              className="apply-coupon-btn"
            >
              Aplicar cupón
            </button>
          </div>

          {/* Resumen de la orden */}
          <div className="order-summary">
            <h3>Resumen de la orden</h3>
            <div className="summary-row">
              <span>Artículos</span>
              <span>{itemCount}</span>
            </div>
            <div className="summary-row">
              <span>Subtotal</span>
              <span>${total?.toFixed(2)}</span>
            </div>
            <div className="summary-row">
              <span>Envío</span>
              <span>${shipping.toFixed(2)}</span>
            </div>
            <div className="summary-row">
              <span>Impuestos</span>
              <span>${taxes.toFixed(2)}</span>
            </div>
            <div className="summary-row discount">
              <span>Descuento por cupón</span>
              <span>-${discountedAmount.toFixed(2)}</span>
            </div>
            <div className="summary-row total">
              <span>Total:</span>
              <span>${(total + shipping + taxes - discount)?.toFixed(2)}</span>
            </div>
          </div>

          <Link to="/payment" className="checkout-btn ">
            Proceder al pago
          </Link>
        </div>
      </div>
      <Footer />
    </>
  );
}

export default CartPage;