import { useState, useEffect } from "react";
import Header from "../../../components/Header/Header"
import Footer from "../../../components/Footer/Footer"
import CategoryPage from "../../../components/CategoryLayout/CategoryLayout";

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

function TopSellsPage() {
  const [products, setProducts] = useState([]);
    
  useEffect(() => {
    const fetchItems = async () => {
      const response = await fetch(`${API_BASE_URL}/products/category/hot?q=top_sells`);
      const data = await response.json();
      setProducts(data || []);
    };

    fetchItems();
  }, []);

  return (
    <>
      <Header/>
      <main>
        <div className="banner">
          <img src="/categoryHeaders/genres/baladasBanner.png" alt="Banner Baladas" className="banner-image" />
        </div>
        <CategoryPage items={products} isFormat={false} path={"hot"}/>
      </main>
      <Footer/>
    </>
  );
};

export default TopSellsPage;