import "./Footer.css";
import visaLogo from "../../assets/icons/visa.svg";
import mastercardLogo from "../../assets/icons/mastercard.svg";
import paypalLogo from "../../assets/icons/paypal.svg";

function Footer() {
  return (
    <footer className="footer-container">
      <div className="main-content">
        <div className="contact-info-container">
          <h2>Contáctenos</h2>
          <p>Correo:<br/>offTheRecords@gmailcom</p>
          <p>Telefono:<br/>1111-1111</p>
          <div className="icons-container">
            <a href=""><i className="bi bi-twitter-x"></i></a>
            <a href=""><i className="bi bi-facebook"></i></a>
            <a href=""><i className="bi bi-instagram"></i></a>
            <a href=""><i className="bi bi-linkedin"></i></a>
          </div>
        </div>

        <div className="more-info-container">
          <h2>Más información</h2>
          <a href="">Preguntas frecuentes</a>
          <a href="">Acerca del sitio</a>
          <a href="">Términos y condiciones</a>
          <a href="">Normas de privacidad</a>
          <a href="">Políticas de devolución</a>
        </div>

        <div className="payment-methods-container">
          <h2>Métodos de pago</h2>
          <div className="payment-methods-icons">
            <img src={visaLogo} alt="Logotipo de visa"/>
            <img id="mastercard-icon" src={mastercardLogo} alt="Logotipo de mastercard"/>
            <img src={paypalLogo} alt="Logotipo de paypal"/>
          </div>
        </div>
      </div>

      <p id="rights-disclaimer">© 2025 Off The Records. Todos los derechos reservados</p>
    </footer>
  );
}

export default Footer;