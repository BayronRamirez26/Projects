import { createContext, useState, useContext } from 'react';

const SearchContext = createContext();

export const SearchProvider = ({ children }) => {
  const [searchQuery, setSearchQuery] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [isSearching, setIsSearching] = useState(false);

  return (
    <SearchContext.Provider value={{ 
      searchQuery, 
      setSearchQuery, 
      searchResults, 
      setSearchResults,
      isSearching,
      setIsSearching
    }}>
      {children}
    </SearchContext.Provider>
  );
};

export const useSearch = () => useContext(SearchContext);