import "./Product.css";
import { Link } from 'react-router-dom';

function Product({ image, title, id, path }) {
  return (
    <>
      <div className="product-container">
        <img className="product-image-view" src={`${image}`} alt={title}></img>
        <p>{title}</p>
        <Link to={`/${encodeURIComponent(path)}/product/${id}`}>Más información {">"}</Link>
      </div>
    </>
  );
}

export default Product;