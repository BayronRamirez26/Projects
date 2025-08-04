import React, { useState } from 'react';
import PropTypes from 'prop-types';
import './CategoryLayout.css';
import filterIcon from "../../assets/icons/filter.png";
import { useNavigate } from 'react-router-dom';

const CategoryLayout = ({categoryDescription, items, allGenres = [], allArtists = [], allFormats = [], isFormat=true}) => {
  // Pagination state
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 16;
  
  // Filter and sort state
  const [sortBy, setSortBy] = useState('default');
  const [artistFilter, setArtistFilter] = useState('');
  const [genreFilter, setGenreFilter] = useState('');
  const [showFilters, setShowFilters] = useState(false);
  const [formatFilter, setFormatFilter] = useState('');

  // Process items based on filters and sorting
  const processedItems = [...items]
    .filter(item => {
      if (!artistFilter) return true;
      const itemArtist = (item.artist || '').toLowerCase();
      return itemArtist.includes(artistFilter.toLowerCase());
    })
    .filter(item => {
      if (genreFilter === '') return true;
      const itemGenre = Array.isArray(item.genre) ? item.genre : [item.genre];
      return itemGenre.some(g => (g || '').toLowerCase().includes(genreFilter.toLowerCase()));
    })
    .filter(item => {
      if (formatFilter === '') return true;
      const itemFormat = Array.isArray(item.format) ? item.format : [item.format];
      return itemFormat.some(f => (f || '').toLowerCase().includes(formatFilter.toLowerCase()));
    })
    .sort((a, b) => {
      if (sortBy === 'price') return a.price - b.price;
      if (sortBy === 'year') return a.year - b.year;
      return 0;
    });

  // Calculate pagination
  const totalItems = processedItems.length;
  const totalPages = Math.ceil(totalItems / itemsPerPage);
  const currentItems = processedItems.slice(
    (currentPage - 1) * itemsPerPage,
    currentPage * itemsPerPage
  );

  // Calculate displayed items range
  const startItem = (currentPage - 1) * itemsPerPage + 1;
  const endItem = Math.min(currentPage * itemsPerPage, totalItems);

  // Calculate if we have any filters to show
  const hasFilters = allArtists.length > 0 || allGenres.length > 0 || allFormats.length > 0;

  // Generate smart pagination buttons
  const getPaginationButtons = () => {
    const buttons = [];
    const maxVisibleButtons = 3; // Number of buttons to show (excluding first/last/ellipsis)
    const halfVisibleButtons = Math.floor(maxVisibleButtons / 2);

    buttons.push(1); //first page is always shown
    
    if (currentPage - halfVisibleButtons > 2) {
      buttons.push('...');
    }

    // Calculate range of visible page numbers
    let startPage = Math.max(2, currentPage - halfVisibleButtons);
    let endPage = Math.min(totalPages - 1, currentPage + halfVisibleButtons);

    if (currentPage <= halfVisibleButtons) {
      endPage = maxVisibleButtons;
    }
    if (currentPage >= totalPages - halfVisibleButtons) {
      startPage = totalPages - maxVisibleButtons + 1;
    }

    //add visible number pages
    for (let i = startPage; i <= endPage; i++) {
      if (i > 1 && i < totalPages) {
        buttons.push(i);
      }
    }

    //show the ellipsis (the "...") before the last page
    if (currentPage + halfVisibleButtons < totalPages - 1) {
      buttons.push('...');
    }

    //always show last page
    if (totalPages > 1) {
      buttons.push(totalPages);
    }

    return buttons;
  };

  const navigate = useNavigate();

  const handleCardClick = (id, path) => {
    navigate(`/${encodeURIComponent(path)}/product/${id}`);
  }

  return (
    <div className="category">
      <div className="category-header">
        <p>{categoryDescription}</p>
      </div>
      
      <div className="controls">
        <span>Productos {startItem}-{endItem} de {totalItems}</span>
        
        {hasFilters && (
          <button 
            className="filter-button"
            onClick={() => setShowFilters(!showFilters)}
          >
            <img src={filterIcon} alt="" />{' '}
            Filtros
          </button>
        )}
        
        <select 
          className="sort-select"
          value={sortBy}
          onChange={(e) => {
            setSortBy(e.target.value);
            setCurrentPage(1);
          }}
        >
          <option value="default">Ordenar por</option>
          <option value="price">Precio</option>
          <option value="year">Año</option>
        </select>
      </div>
      
      {hasFilters && showFilters && (
        <div className="filter-dropdown">
          {allArtists.length > 0 && (
            <div className="filter-group">
              <label htmlFor="artist-filter-select">Artista:</label>
              <select
                id="artist-filter-select"
                value={artistFilter}
                onChange={(e) => {
                  setArtistFilter(e.target.value);
                  setCurrentPage(1);
                }}
              >
                <option value="">Todos</option>
                {allArtists.map(artist => (
                  <option key={artist} value={artist}>{artist}</option>
                ))}
              </select>
            </div>
          )}
          
          {allGenres.length > 0 && (
            <div className="filter-group"> 
              <label htmlFor="genre-filter-select">Género:</label>
              <select
                id="genre-filter-select"
                value={genreFilter}
                onChange={(e) => {
                  setGenreFilter(e.target.value);
                  setCurrentPage(1);
                }}
              >
                <option value="">Todos</option>
                {allGenres.map(genre => (
                  <option key={genre} value={genre}>{genre}</option>
                ))}
              </select>
            </div>
          )}

          {allFormats.length > 0 && (
            <div className="filter-group"> 
              <label htmlFor="format-filter-select">Formato:</label>
              <select
                id="format-filter-select"
                value={formatFilter}
                onChange={(e) => {
                  setFormatFilter(e.target.value);
                  setCurrentPage(1);
                }}
              >
                <option value="">Todos</option>
                {allFormats.map(format => (
                  <option key={format} value={format}>{format}</option>
                ))}
              </select>
            </div>
          )}

        </div>
      )}
      
      <div className="category-grid">
        {currentItems.map((item) => (
          <div key={item.id || item._id || JSON.stringify(item)} className="category-card"
          onClick={() => handleCardClick(item.product_id, item.subcategory)}
          style={{ cursor: 'pointer' }}>
            <img src={item.image_path} alt={item.name} id={isFormat ? "" : "non-format-image"}/>
            <div className="category-info">
              <h3>{item.name}</h3>
              <div className="price">
                {item.price !== undefined ? `$${item.price}` : "No disponible"}
              </div>
              <ul>
                <li>{isFormat ? `Artista: ${item.artist}` : ""}</li>
                <li>{isFormat ? `Género: ${item.genre}` : ""}</li>
                <li>Año: {item.year}</li>
              </ul>
            </div>
          </div>
        ))}
      </div>
      
      {totalPages > 1 && (
        <div className="pagination">
          {getPaginationButtons().map((page, index) =>
            page === '...' ? (
              <span key={`ellipsis-${page}-${index}`} className="ellipsis">...</span>
            ) : (
              <button
                key={`page-btn-${page}`}
                className={`page-btn ${currentPage === page ? 'active' : ''}`}
                onClick={() => setCurrentPage(page)}
              >
                {page}
              </button>
            )
          )}
        </div>
      )}
    </div>
  );
};

CategoryLayout.propTypes = {
  categoryDescription: PropTypes.string.isRequired,
  items: PropTypes.array.isRequired,
  allGenres: PropTypes.array,
  allArtists: PropTypes.array,
  allFormats: PropTypes.array,
  isFormat: PropTypes.bool
};

export default CategoryLayout;