import { useState, useEffect } from "react";
import Header from "../../../components/Header/Header";
import Footer from "../../../components/Footer/Footer"
import CategoryPage from "../../../components/CategoryLayout/CategoryLayout";

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

function CassettesPlayersPage() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    async function fetchProducts() {
      try {
        const response = await fetch(`${API_BASE_URL}/products/subcategory?q=cassette player`); // Updated to use full URL
        const data = await response.json();
        setProducts(data);
      } catch (error) {
        console.error("Error fetching products:", error);
      }
    }

    fetchProducts();
  }, []);

  return (
    <>
      <Header/>
      <main>
        <div className="banner">
          <img src="/../../../public/categoryHeaders/formats/bannerCassettesCategory.png" alt="Banner Cassette" className="banner-image" />
        </div>
        <CategoryPage
          items={products} isFormat = {false} path="players"
        />
      </main>
      <Footer/>
    </>
  );
};

export default CassettesPlayersPage;