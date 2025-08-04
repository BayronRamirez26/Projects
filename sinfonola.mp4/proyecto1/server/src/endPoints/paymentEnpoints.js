const axios = require('axios');

function isValidExpiry(month, year) {
  const now = new Date();
  const cardDate = new Date(parseInt(year), parseInt(month) - 1);
  return cardDate > new Date(now.getFullYear(), now.getMonth());
}

function isValidCVC(cvc, brand) {
  if (brand === "amex") return /^\d{4}$/.test(cvc);
  return /^\d{3}$/.test(cvc);
}

async function isBinFromCostaRica(bin) {
  try {
    const res = await axios.get(`https://lookup.binlist.net/${bin}`);
    return res.data?.country?.name === "Costa Rica";
  } catch (err) {
    console.error('❌ Error al consultar el BIN:', err.message);
    return false;
  }
}

// 👉 POST /api/payment
exports.processPayment = async (req, res) => {
  const { cardNumber, expiryMonth, expiryYear, cvc, currency, brand } = req.body;

  try {
    if (!/^\d{16}$/.test(cardNumber)) {
      return res.status(400).json({ success: false, message: 'Número de tarjeta inválido' });
    }

    const bin = cardNumber.slice(0, 6);
    const isCR = await isBinFromCostaRica(bin);
    if (!isCR) {
      return res.status(400).json({ success: false, message: 'La tarjeta no pertenece a un banco de Costa Rica' });
    }

    if (!isValidExpiry(expiryMonth, expiryYear)) {
      return res.status(400).json({ success: false, message: 'Fecha de expiración inválida' });
    }

    if (!isValidCVC(cvc, brand)) {
      return res.status(400).json({ success: false, message: 'Código CVC inválido' });
    }

    if (!['CRC', 'USD'].includes(currency)) {
      return res.status(400).json({ success: false, message: 'Moneda no válida' });
    }

    return res.status(200).json({ success: true, message: 'Transacción aprobada' });

  } catch (err) {
    console.error(err.response?.data || err.message);
    return res.status(500).json({ error: 'Error interno al procesar el pago' });
  }
};