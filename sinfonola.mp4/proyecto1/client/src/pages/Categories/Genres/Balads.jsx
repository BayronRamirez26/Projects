import { useState, useEffect } from "react";
import Header from "../../../components/Header/Header"
import Footer from "../../../components/Footer/Footer"
import CategoryLayout from "../../../components/CategoryLayout/CategoryLayout";

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

function BaladasPage() {
  const [products, setProducts] = useState([]);
  const [allArtists, setAllArtists] = useState([]);
    
  useEffect(() => {
    const fetchItems = async () => {
      const response = await fetch(`${API_BASE_URL}/products/formats/genre?q=ballad`);
      const data = await response.json();
      setProducts(data || []);

      const artists = [...new Set(data.map(item => {
        // Split the title on " - " and take the first part
        return item.title.split(' - ')[0]
          .replace(/\(\d+\)$/, '') // Remove trailing (number)
          .trim(); // Trim whitespace
      }))];
      setAllArtists(artists.toSorted((a, b) => a.localeCompare(b))); // Sort alphabetically
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
        <CategoryLayout
          items={products}
          allArtists={allArtists}
          isFormat={true}
          genre="Balada"
          path="discogs"
        />
      </main>
      <Footer/>
    </>
  );
};

export default BaladasPage;