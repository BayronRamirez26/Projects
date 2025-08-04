import { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useSearch } from '../../context/SearchContext';
import Header from '../../components/Header/Header';
import Footer from '../../components/Footer/Footer';
import CategoryLayout from '../../components/CategoryLayout/CategoryLayout';

const API_BASE_URL = "http://localhost:3001";

function SearchResults() {
  const location = useLocation();
  const navigate = useNavigate();
  const { searchResults, setSearchResults, isSearching, setIsSearching } = useSearch();
  const [isLoading, setIsLoading] = useState(false);
  const [allFormats, setAllFormats] = useState([]);


  useEffect(() => {
    const searchParams = new URLSearchParams(location.search);
    const query = searchParams.get('q');

    if (query) {
      const fetchAllSearchResults = async () => {
        setIsLoading(true);
        setSearchResults([]);

        try {
          const apiCalls = [
            fetch(`${API_BASE_URL}/players/search?q=${query}`),
            fetch(`${API_BASE_URL}/accessories/search?q=${query}`),
            fetch(`${API_BASE_URL}/discogs/search?q=${query}`)
          ];

          const responses = await Promise.allSettled(apiCalls);

          let combinedResults = [];
          let collectedFormats = new Set(); 

          for (const res of responses) {
            if (res.status === 'fulfilled') {
              try {
                const data = await res.value.json();
                if (Array.isArray(data)) {
                  combinedResults = combinedResults.concat(data);

                  // Recopilar formatos únicos
                  data.forEach(item => {
                    if (item.format) {
                      if (Array.isArray(item.format)) {
                        item.format.forEach(format => {
                          if (format && typeof format === 'string') { 
                            collectedFormats.add(format.trim()); 
                          }
                        });
                      } else if (typeof item.format === 'string') { 
                        collectedFormats.add(item.format.trim());
                      }
                    }
                  });

                } else {
                  console.warn('API returned non-array data:', data);
                }
              } catch (parseError) {
                console.error('Error parsing JSON from response:', parseError);
              }
            } else {
              console.error('API call failed:', res.reason);
            }
          }

          const uniqueResults = [];
          const seenIds = new Set();

          combinedResults.forEach(item => {
            if (item.id && !seenIds.has(item.id)) {
              uniqueResults.push(item);
              seenIds.add(item.id);
            } else if (!item.id && !uniqueResults.some(existingItem => existingItem.title === item.title && existingItem.cover_image === item.cover_image)) {
              uniqueResults.push(item);
            }
          });

          // Revolver el arreglo uniqueResults antes de setearlo
          const shuffledResults = uniqueResults
          .map(value => ({ value, sort: Math.random() }))
          .sort((a, b) => a.sort - b.sort)
          .map(({ value }) => value);

          setSearchResults(shuffledResults || []);

          setAllFormats(Array.from(collectedFormats).sort()); //array de los formatos de los resultados
          setIsSearching(false);

        } catch (error) {
          console.error('Overall search error:', error);
          setIsSearching(false);
        } finally {
          setIsLoading(false);
        }
      };

      fetchAllSearchResults();
    }
  }, [location.search, setSearchResults, setIsSearching]);

  return (
    <>
      <Header />
      <main>
        <div className="search-results-container">
          {isLoading ? (
            <div className="loading">Buscando productos...</div>
          ) : searchResults.length > 0 ? (
            <CategoryLayout
              categoryName="Resultados de búsqueda"
              categoryDescription={`${searchResults.length} resultados encontrados`}
              items={searchResults}
              allFormats={allFormats}
              isFormat={false}
            />
          ) : (
            <div className="no-results">
              <h2 className='category'>No se encontraron resultados</h2>
              <p className='category'>Intenta con diferentes términos de búsqueda</p>
            </div>
          )}
        </div>
      </main>
      <Footer />
    </>
  );
}

export default SearchResults;