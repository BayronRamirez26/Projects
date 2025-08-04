import { useState } from 'react';
import { useCart } from '../../context/CartContext';
import { useNavigate } from 'react-router-dom';
import { FaCcVisa, FaCcMastercard, FaPaypal } from 'react-icons/fa';
import './PaymentPage.css';
import Header from '../../components/Header/Header';
import Footer from '../../components/Footer/Footer';
import visaLogo from "../../assets/icons/visa.svg";
import mastercardLogo from "../../assets/icons/mastercard.svg";
import paypalLogo from "../../assets/icons/paypal.svg";

function PaymentPage() {
    const { total, clearCart } = useCart();
    const navigate = useNavigate();
    const [paymentMethod, setPaymentMethod] = useState('visa');
    const [cardData, setCardData] = useState({
        name: '',
        number: '',
        expiryMonth: '',
        expiryYear: '',
        cvv: ''
    });
    const [errors, setErrors] = useState({
        name: '',
        number: '',
        expiryMonth: '',
        expiryYear: '',
        cvv: ''
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;

        // Limpiar errores al escribir.
        setErrors(prev => ({ ...prev, [name]: '' }));

        // Validación de cmapos númericos
        if ((name === 'number' || name === 'cvv') && !/^\d*$/.test(value)) {
            return;
        }

        // Limita valores maximos
        if (name === 'number' && value.length > 16) return;
        if (name === 'cvv' && value.length > 3) return;

        setCardData({
            ...cardData,
            [name]: value
        });
    };

    const validateForm = () => {
        let isValid = true;
        const newErrors = {
            name: '',
            number: '',
            expiryMonth: '',
            expiryYear: '',
            cvv: ''
        };

        if (paymentMethod !== 'paypal') {
            if (!cardData.name.trim()) {
                newErrors.name = 'El nombre en la tarjeta es requerido';
                isValid = false;
            }
            if (cardData.number.length !== 16) {
                newErrors.number = 'El número de tarjeta debe tener 16 dígitos';
                isValid = false;
            }
            if (!cardData.expiryMonth) {
                newErrors.expiryMonth = 'El mes de expiración es requerido';
                isValid = false;
            }
            if (!cardData.expiryYear) {
                newErrors.expiryYear = 'El año de expiración es requerido';
                isValid = false;
            }
            if (cardData.cvv.length !== 3) {
                newErrors.cvv = 'El CVV debe tener 3 dígitos';
                isValid = false;
            }
        }

        setErrors(newErrors);
        return isValid;
    };

    const handleSubmit = async (e) => {
  e.preventDefault();

  if (paymentMethod !== 'paypal') {
    if (!validateForm()) return;

    try {
      const response = await fetch('http://localhost:3001/payment', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          cardNumber: cardData.number,
          expiryMonth: cardData.expiryMonth,
          expiryYear: cardData.expiryYear,
          cvc: cardData.cvv,
          currency: 'CRC', // 
          brand: paymentMethod // 'visa', 'mastercard', 'amex'
        })
      });

      const result = await response.json();

      if (!response.ok) {
        alert(`❌ Error: ${result.message || result.error}`);
        return;
      }

      alert('✅ Pago exitoso!');
      clearCart();
      navigate('/home');
    } catch (err) {
      console.error(err);
      alert('❌ Error al conectar con el servidor de pagos');
    }

  } else {
    alert('Redirigiendo a PayPal...');
    clearCart();
    navigate('/home');
  }
};

    const renderPaymentForm = () => {
        if (paymentMethod === 'paypal') {
            return (
                <div className="paypal-method">
                    <p>Serás redirigido a PayPal para completar tu pago</p>
                </div>
            );
        }

        return (
            <>
                <div className="form-group">
                    <label>Nombre en la tarjeta</label>
                    <input
                        type="text"
                        name="name"
                        value={cardData.name}
                        onChange={handleInputChange}
                        className={errors.name ? 'payment-box-error' : ''}
                    />
                    {errors.name && <span className="payment-box-error-text">{errors.name}</span>}
                </div>

                <div className="form-group">
                    <label>Número de la tarjeta</label>
                    <input
                        type="text"
                        name="number"
                        value={cardData.number}
                        onChange={handleInputChange}
                        maxLength="16"
                        placeholder="1234 5678 9012 3456"
                        className={errors.number ? 'payment-box-error' : ''}
                    />
                    {errors.number && <span className="payment-box-error-text">{errors.number}</span>}
                </div>

                <div className="form-row">
                    <div className="form-group">
                        <label>MM</label>
                        <select
                            name="expiryMonth"
                            value={cardData.expiryMonth}
                            onChange={handleInputChange}
                            className={errors.expiryMonth ? 'payment-box-error' : ''}

                        >
                            <option value="">Mes</option>
                            {Array.from({ length: 12 }, (_, i) => (
                                <option key={i} value={String(i + 1).padStart(2, '0')}>
                                    {String(i + 1).padStart(2, '0')}
                                </option>
                            ))}
                        </select>
                        {errors.expiryMonth && <span className="payment-box-error-text">{errors.expiryMonth}</span>}
                    </div>

                    <div className="form-group">
                        <label>YYYY</label>
                        <select
                            name="expiryYear"
                            value={cardData.expiryYear}
                            onChange={handleInputChange}
                            className={errors.expiryYear ? 'payment-box-error' : ''}

                        >
                            <option value="">Año</option>
                            {Array.from({ length: 10 }, (_, i) => {
                                const year = new Date().getFullYear() + i;
                                return (
                                    <option key={year} value={year}>
                                        {year}
                                    </option>
                                );
                            })}
                        </select>
                        {errors.expiryYear && <span className="payment-box-error-text">{errors.expiryYear}</span>}
                    </div>

                    <div className="form-group">
                        <label>CVV</label>
                        <input
                            type="text"
                            name="cvv"
                            value={cardData.cvv}
                            onChange={handleInputChange}
                            maxLength="3"
                            placeholder="123"
                            className={errors.cvv ? 'payment-box-error' : ''}

                        />
                        {errors.cvv && <span className="payment-box-error-text">{errors.cvv}</span>}
                    </div>
                </div>
            </>
        );
    };

    return (
        <>
            <Header />
            <div className="payment-container">
                <h1>Método de pago</h1>

                <div className="payment-methods">
                    <label className={`method-option ${paymentMethod === 'visa' ? 'active' : ''}`}>
                        <input
                            type="radio"
                            name="paymentMethod"
                            checked={paymentMethod === 'visa'}
                            onChange={() => setPaymentMethod('visa')}
                        />
                        <img
                            src={visaLogo}
                            alt="Visa"
                            className="payment-icon"
                        />
                        <span className="visa-icon-text"></span>
                    </label>

                    <label className={`method-option ${paymentMethod === 'mastercard' ? 'active' : ''}`}>
                        <input
                            type="radio"
                            name="paymentMethod"
                            checked={paymentMethod === 'mastercard'}
                            onChange={() => setPaymentMethod('mastercard')}
                        />
                        <img
                            src={mastercardLogo}
                            alt="Mastercard"
                            className="payment-icon"
                        />
                        <span className="mastercard-icon-text"></span>
                    </label>

                    <label className={`method-option ${paymentMethod === 'paypal' ? 'active' : ''}`}>
                        <input
                            type="radio"
                            name="paymentMethod"
                            checked={paymentMethod === 'paypal'}
                            onChange={() => setPaymentMethod('paypal')}
                        />
                        <img
                            src={paypalLogo}
                            alt="PayPal"
                            className="payment-icon"
                        />
                        <span className="paypal-icon-text"></span>
                    </label>
                </div>

                <form onSubmit={handleSubmit}>
                    {renderPaymentForm()}

                    <div className="payment-total">
                        <h3>Total</h3>
                        <p>${total.toFixed(2)}</p>
                    </div>

                    <button type="submit" className="payment-button">
                        Finalizar pago
                    </button>
                </form>
            </div>
            <Footer />
        </>
    );
}

export default PaymentPage;