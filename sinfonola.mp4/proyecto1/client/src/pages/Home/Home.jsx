
import Footer from "../../components/Footer/Footer.jsx";
import Header from "../../components/Header/Header.jsx";
import Product from "../../components/Product/Product.jsx";
import vinylIcon from "../../assets/icons/vinylIcon.png";
import cdIcon from "../../assets/icons/cdIcon.png";
import caseteIcon from "../../assets/icons/caseteIcon.png";
import headphonesIcon from "../../assets/icons/headphonesIcon.png";
import { useState, useEffect } from "react";
import "./Home.css";

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

function Home() {
  const [outstandingProduct, setOutstandingProduct] = useState(0);
  const [soldProduct, setSoldProduct] = useState(0);
  const [testimonialsSlide, setTestimonialsSlide] = useState(0);
  const [offerProducts, setOfferProducts] = useState([]);
  const [soldProducts, setSoldProducts] = useState([]);

  useEffect(() => {
    const fetchItems = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/products/category/hot?q=offer`); // Updated to use full URL
        const data = await response.json();
        setOfferProducts(data);
      } catch (error) {
        console.error("Error fetching on offer products:", error);
      }

      try {
        const response = await fetch(`${API_BASE_URL}/products/category/hot?q=top-sell`); // Updated to use full URL
        const data = await response.json();
        setSoldProducts(data);
      } catch (error) {
        console.error("Error fetching top-sell products:", error);
      }
    };

    fetchItems();
  }, []);

  const testimonials = [
    <>¡Increíble experiencia! Encontré ese vinilo clásico que llevaba años buscando y llegó en perfectas condiciones. Se nota que cuidan cada detalle. ¡Definitivamente volveré a comprar!<br />— Mariana R.</>,
    <>Me encanta la variedad que ofrecen. Compré varios casetes para mi colección y todos son originales y de excelente calidad. Además, el envío fue rapidísimo.<br />— Carlos M.</>,
    <>Soy fanático del sonido clásico, y esta tienda tiene justo lo que necesito. Compré tres CDs de bandas de los 80 y llegaron impecables. ¡Muy recomendados!<br />— Sofía L.</>,
    <>Excelente servicio y atención al cliente. Tenía dudas sobre un vinilo raro y me ayudaron a resolverlas enseguida. Recibí mi pedido a tiempo y en excelente estado. ¡Un verdadero paraíso para los amantes de la música!<br />— Diego P.</>,
    <>Esta tienda es un tesoro para los amantes de la música. Pedí un lote de vinilos antiguos y cada uno llegó protegido y con un sonido espectacular. Se nota el amor por la música en cada envío. ¡Gracias por mantener viva la magia del formato físico!<br />— Laura V.</>
  ];

  const handlePrevOffer = () => {
    setOutstandingProduct((prev) => (prev === 0 ? offerProducts.length - 1 : prev - 1));
  };

  const handleNextOffer = () => {
    setOutstandingProduct((prev) => (prev === offerProducts.length - 1 ? 0 : prev + 1));
  };

  const handlePrevSold = () => {
    setSoldProduct((prev) => (prev === 0 ? soldProducts.length - 1 : prev - 1));
  };

  const handleNextSold = () => {
    setSoldProduct((prev) => (prev === soldProducts.length - 1 ? 0 : prev + 1));
  };

  return (
    <>
      <Header />
      <main>
        <div className="offer-banner">
          <div className="offer-left-content">
            <h2>OFERTA BEATLE PACK</h2>
            <p>¡Oferta especial 6 vinillos de los Beatles por el precio de 4!</p>
            <button>Compra ya</button>
          </div>
          <img src="/productsImages/offerPhoto.svg" alt="Foto de oferta de los Beatles" />
        </div>

        <div className="info-banner">
          <div className="info-text-container">
            <h2>¡Contamos con una amplia variedad de productos!</h2>
            <a href="/">Ve nuestro catalogo</a>
          </div>

          <div className="amounts-container">
            <div className="info-item">
              <img src={vinylIcon} alt="" />
              <div className="info-item-text">
                <p><b>10.000+</b></p>
                <p>Discos</p>
              </div>
            </div>

            <div className="info-item">
              <img src={headphonesIcon} alt="" />
              <div className="info-item-text">
                <p><b>200+</b></p>
                <p>Accesorios</p>
              </div>
            </div>

            <div className="info-item">
              <img src={cdIcon} alt="" />
              <div className="info-item-text">
                <p><b>500+</b></p>
                <p>Vinilos</p>
              </div>
            </div>

            <div className="info-item">
              <img src={caseteIcon} alt="" />
              <div className="info-item-text">
                <p><b>140+</b></p>
                <p>Cassettes</p>
              </div>
            </div>
          </div>
        </div>

        <div className="products-container">
          <h2>Ofertas</h2>
          <div className="products-slider">
            <button className="slider-button prev" onClick={handlePrevOffer}><i className="bi bi-caret-left-fill"></i></button>
            <div className="slider-wrapper">
              <div
                className="slider-content"
                style={{ transform: `translateX(-${outstandingProduct * 250}px)` }}
              >
                {soldProducts.map((product) => (
                  <Product key={product.product_id} id={product.product_id} image={product.image_path} title={product.name} path={'discogs'}/>
                ))}
              </div>
            </div>
            <button className="slider-button next" onClick={handleNextOffer}><i className="bi bi-caret-right-fill"></i></button>
          </div>
        </div>

        <div className="products-container">
          <h2>Más vendidos</h2>
          <div className="products-slider">
            <button className="slider-button prev" onClick={handlePrevSold}><i className="bi bi-caret-left-fill"></i></button>
            <div className="slider-wrapper">
              <div
                className="slider-content"
                style={{ transform: `translateX(-${soldProduct * 230}px)` }}
              >
                {offerProducts.map((product) => (
                  <Product key={product.product_id} id={product.product_id} image={product.image_path} title={product.name} path={'discogs'}/>
                ))}
              </div>
            </div>
            <button className="slider-button next" onClick={handleNextSold}><i className="bi bi-caret-right-fill"></i></button>
          </div>
        </div>

        <div className="testimonials-container">
          <h2>Escucha las opiniones de nuestros clientes</h2>

          <div className="testimonial-container">
            {testimonialsSlide === 0 && <p>{testimonials[0]}</p>}
            {testimonialsSlide === 1 && <p>{testimonials[1]}</p>}
            {testimonialsSlide === 2 && <p>{testimonials[2]}</p>}
            {testimonialsSlide === 3 && <p>{testimonials[3]}</p>}
            {testimonialsSlide === 4 && <p>{testimonials[4]}</p>}
          </div>
            
          <div className="testimonials-buttons">
            <button id="testimonial1" onClick={() => setTestimonialsSlide(0)}></button>
            <button id="testimonial2" onClick={() => setTestimonialsSlide(1)}></button>
            <button id="testimonial3" onClick={() => setTestimonialsSlide(2)}></button>
            <button id="testimonial4" onClick={() => setTestimonialsSlide(3)}></button>
            <button id="testimonial5" onClick={() => setTestimonialsSlide(4)}></button>
          </div>
        </div>
      </main>
      <Footer/>
    </>
  )
}

export default Home;