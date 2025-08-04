import { useState, useEffect  } from "react";
import { useCart } from "../../context/CartContext.jsx"; 
import { useSearch } from "../../context/SearchContext";
import { Link, useNavigate  } from "react-router-dom";
import "./Header.css"

function NavBar() {
  const [formatsHovered, setFormatsHovered] = useState(false);
  const [gendersHovered, setGendersHovered] = useState(false);
  const [playersHovered, setPlayersHovered] = useState(false);
  const [accesoriesHovered, setAccesoriesHovered] = useState(false);
  const [hotHovered, setHotHovered] = useState(false);

  return (
    <>
      <nav className="categories">
        <div className="categories-item" onMouseEnter={() => setFormatsHovered(true)} onMouseLeave={() => setFormatsHovered(false)}>
          <button className="nav-button">Formatos</button>
          {formatsHovered && (
            <ul 
              id="formats-submenu" 
              className={`categories-submenu ${formatsHovered ? "submenu-visible" : "submenu-hiden"}`}>
              <Link to="/formats/vinyls" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Vinilos</li>
              </Link>
              <Link to="/formats/casetes" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Casetes</li>
              </Link>
              <Link to="/formats/cds" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Cds</li>
              </Link>
            </ul>
          )}
        </div>
    
        <div className="categories-item" onMouseEnter={() => setGendersHovered(true)} onMouseLeave={() => setGendersHovered(false)}>
          <button className="nav-button">Géneros</button>
          {gendersHovered && (
            <ul id="music-genders-submenu" className={`categories-submenu ${gendersHovered ? "submenu-visible" : "submenu-hidden"}`}>
              <Link to="/genres/rock" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Rock</li>
              </Link>
              <Link to="/genres/hiphop" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>HipHop</li>
              </Link>
              <Link to="/genres/pop" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Pop</li>
              </Link>
              <Link to="/genres/jazz" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Jazz</li>
              </Link>
              <Link to="/genres/reggaeton" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Reggaetón</li>
              </Link>
              <Link to="/genres/blues" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Blues</li>
              </Link>
              <Link to="/genres/disco" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Disco</li>
              </Link>
              <Link to="/genres/electronica" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Electrónica</li>
              </Link>
              <Link to="/genres/metal" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Metal</li>
              </Link>
              <Link to="/genres/baladas" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Baladas</li>
              </Link>
              <Link to="/genres/latina" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Latina</li>
              </Link>
              <Link to="/genres/rap" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
                <li>Rap</li>
              </Link>  
            </ul>
          )}
        </div>

        <div className="categories-item" onMouseEnter={() => setPlayersHovered(true)} onMouseLeave={() => setPlayersHovered(false)}>
          <button className="nav-button" >Reproductores</button>
          <ul id="players-submenu"  className={`categories-submenu ${playersHovered ? "submenu-visible" : "submenu-hidden"}`}>
            <Link to="/players/cassette-players" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Reproductores de casetes</li>
            </Link>  
            <Link to="/players/mp-players" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Reproductores MP3/MP4</li>
            </Link> 
          </ul>
        </div>

        <div className="categories-item" onMouseEnter={() => setAccesoriesHovered(true)} onMouseLeave={() => setAccesoriesHovered(false)}>
          <button className="nav-button">Accesorios</button>
          <ul id="accesories-submenu" className={`categories-submenu ${accesoriesHovered ? "submenu-visible" : "submenu-hidden"}`}>
            <Link to="/accesories/cases" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Estuches</li>
            </Link> 
            <Link to="/accesories/adapters" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Adaptadores</li>
            </Link> 
            <Link to="/accesories/cleaners" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Limpiadores</li>
            </Link> 
            <Link to="/accesories/earphones" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Audífonos</li>
            </Link> 
          </ul>
        </div>  

        <div className="categories-item" onMouseEnter={() => setHotHovered(true)} onMouseLeave={() => setHotHovered(false)}>
          <button className="nav-button">HOT</button>
          <ul id="hot-submenu" className={`categories-submenu ${hotHovered ? "submenu-visible" : "submenu-hidden"}`}>
            <Link to="/hot/top-sells" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Top Ventas</li>
            </Link>
            <Link to="/hot/new-products" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Novedades</li>
            </Link> 
            <Link to="/hot/offers" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
              <li>Ofertas</li>
            </Link> 
          </ul>
        </div>

        <div className="categories-item">
          <Link to="/pre-sells" style={{ textDecoration: "none", color: "inherit", width: "100%" }}>
            <button className="nav-button">Preventa</button>
          </Link>
        </div>
      </nav>
    </>
  )
}


function Header() {
  const [searchClicked, setSearchClicked] = useState(false);
  const [hamburgerClicked, setHamburgerClicked] = useState(false);
  const {itemCount}  = useCart();
  const { searchQuery, setSearchQuery, setIsSearching } = useSearch();
  const navigate = useNavigate();
  // Detectar si el usuario está logueado por el token en localStorage
  const isAuthenticated = Boolean(localStorage.getItem('token'));

  const handleSearch = (e) => {
    e.preventDefault();
    if (searchQuery.trim()) {
      setIsSearching(true);
      navigate(`/search?q=${encodeURIComponent(searchQuery)}`);
      setSearchQuery(''); // limpiar campo de busqueda
    }
  };

  const handleKeyDown = (e) => {
    if (e.key === 'Enter') {
      e.preventDefault();
      handleSearch(e);
    }
  };
  
  return (
    <header className="header">
      <div className="hamburger-menu">
        <button id="hamburger-icon" onClick={() => setHamburgerClicked(!hamburgerClicked)}><i className="bi bi-list"></i></button>
        {hamburgerClicked && (<NavBar/>)}
        <input className={`search-input ${searchClicked ? "visible" : ""}`} 
        type="text" 
        placeholder="Buscar..." 
        value={searchQuery} 
        onChange={(e) => setSearchQuery(e.target.value)} 
        onKeyDown={handleKeyDown}/>
      </div>

      <Link to={"/home"}>
        <img className="icon-image" src="/logo2.png" alt="Icon image" />
      </Link>

      <div className="search-categories">
        <input 
          className={`search-input ${searchClicked ? "visible" : ""}`}
          type="text" 
          placeholder="Buscar..." 
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          onKeyDown={handleKeyDown}
        />
        <NavBar/>
      </div>

      <div className="search-login-cart">
        <button className="search-button" onClick={() => {setSearchClicked(!searchClicked)}}><i className="bi bi-search"></i></button>
        <Link to={isAuthenticated ? "/profile" : "/sign-in"} className="cart-button">
          <i className="bi bi-person"></i>
        </Link>
         {/* Botón del carrito con contador */}
         <Link to="/cart" className="cart-button">
          <i className="bi bi-cart2"></i>
          {itemCount > 0 && (
            <span className="cart-count">{itemCount}</span>
          )}
        </Link>
      </div>
    </header>
  );
}

export default Header