import { useState, useEffect } from "react";
import Header from "../../../components/Header/Header"
import Footer from "../../../components/Footer/Footer"
import CategoryLayout from "../../../components/CategoryLayout/CategoryLayout";

const API_BASE_URL = "http://localhost:3001"; // Base URL for the server

function CdsPage() {
  const [products, setProducts] = useState([]);
  const [allGenres, setAllGenres] = useState([]);
  const [allArtists, setAllArtists] = useState([]);

  useEffect(() => {
    const fetchItems = async () => {
      const response = await fetch(`${API_BASE_URL}/products/subcategory?q=cd`);
      const data = await response.json();
      setProducts(data || []);

      const genres = [...new Set(data.flatMap(item => item.genre))];
      setAllGenres(genres);

      const artists = [...new Set(data.map(item => {return item.artist;}))];
      const sortedArtists = artists.toSorted((a, b) => a.localeCompare(b));
      setAllArtists(sortedArtists); // Sort alphabetically
    };

    fetchItems();
  }, []);

  return (
    <>
      <Header/>
      <main>
        <div className="banner">
          <img src="/categoryHeaders/formats/bannerCdCategory.png" alt="Banner Cds" className="banner-image" />
          <h1 className="banner-text">Cds a los mejores precios</h1>
        </div>
        <CategoryLayout
          items={products}
          allGenres={allGenres}
          allArtists={allArtists}
          isFormat={true}
        />
      </main>
      <Footer/>
    </>
  );
};

export default CdsPage;