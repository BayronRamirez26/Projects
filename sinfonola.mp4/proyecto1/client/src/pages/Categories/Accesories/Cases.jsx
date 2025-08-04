import { useState, useEffect } from "react";
import Header from "../../../components/Header/Header";
import Footer from "../../../components/Footer/Footer"
import CategoryPage from "../../../components/CategoryLayout/CategoryLayout";

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

function CasesPage() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    async function fetchProducts() {
      try {
        const response = await fetch(`${API_BASE_URL}/products/subcategory?q=cases`); // Updated to use full URL
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
          <img src="\categoryHeaders\extras\cases.jpg" alt="Banner Estuches" className="banner-image" />
        </div>
        <CategoryPage items={products} isFormat = {false} path="accessories"/>
      </main>
      <Footer/>
    </>
  );
};

export default CasesPage;