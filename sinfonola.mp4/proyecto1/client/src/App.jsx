import { CartProvider } from './context/CartContext.jsx';
import { SearchProvider } from './context/SearchContext.jsx';
import { BrowserRouter as Router, Routes, Route, useParams } from 'react-router-dom';
import  CartPage  from './pages/Cart/CartPage'
import './App.css'
import Profile from './pages/Profile/Profile.jsx';
import PaymentPage from './pages/Payment/PaymentPage.jsx';
import ProductDetail from './pages/ProductDetail/ProductDetail.jsx';
import Home from './pages/Home/Home.jsx';
import SignIn from './pages/SignIn/SignIn.jsx';
import SignUp from './pages/SignUp/SignUp.jsx';
import SearchResults from './pages/SearchResult/SearchResult.jsx';
//category imports
import Vinyls from './pages/Categories/Formats/Vinyl.jsx';
import Cds from './pages/Categories/Formats/Cds.jsx';
import Cassettes from './pages/Categories/Formats/Cassettes.jsx';
import Rock from './pages/Categories/Genres/Rock.jsx';
import Raggaeton from './pages/Categories/Genres/Reggaeton.jsx';
import Rap from './pages/Categories/Genres/Rap.jsx';
import Pop from './pages/Categories/Genres/Pop.jsx';
import Metal from './pages/Categories/Genres/Metal.jsx';
import Latina from './pages/Categories/Genres/Latina.jsx';
import Jazz from './pages/Categories/Genres/Jazz.jsx';
import Disco from './pages/Categories/Genres/Disco.jsx';
import HipHop from './pages/Categories/Genres/HipHop.jsx';
import Electronica from './pages/Categories/Genres/Electronica.jsx';
import Blues from './pages/Categories/Genres/Blues.jsx';
import Baladas from './pages/Categories/Genres/Balads.jsx';
import CasetesPlayers from './pages/Categories/Players/CassettePlayers.jsx';
import MpPlayers from './pages/Categories/Players/MP3MP4Players.jsx';
import CleanersPage from './pages/Categories/Accesories/Cleaners.jsx';
import CasesPage from './pages/Categories/Accesories/Cases.jsx';
import EarphonesPage from './pages/Categories/Accesories/Earphones.jsx';
import AdaptersPage from './pages/Categories/Accesories/Adapter.jsx';
import NewProductsPage from './pages/Categories/HOT/NewProducts.jsx';
import OffersPage from './pages/Categories/HOT/Offers.jsx';
import TopSellsPage from './pages/Categories/HOT/TopSells.jsx';
import PreSellsPage from './pages/Categories/PreSells.jsx';

function ProductDetailWrapper() {
  const { id } = useParams();
  return <ProductDetail productId={id} />;
}

function App() {
  return (
    <>
    <SearchProvider>
      <CartProvider>
        <Router>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/home" element={<Home />} />
            <Route path="/sign-in" element={<SignIn/>} />
            <Route path="/sign-up" element={<SignUp/>} />
            <Route path="/cart" element={<CartPage />} />
            <Route path="/profile" element={<Profile />} />
            <Route path="/payment" element={<PaymentPage />} />
            <Route path="/:path/product/:id" element={<ProductDetailWrapper />} />
            <Route path="/formats/vinyls" element={<Vinyls />} />
            <Route path="/formats/cds" element={<Cds />} />
            <Route path="/formats/casetes" element={<Cassettes />} />
            <Route path="/genres/rock" element={<Rock />} />
            <Route path="/genres/reggaeton" element={<Raggaeton />} />
            <Route path="/genres/rap" element={<Rap />} />
            <Route path="/genres/pop" element={<Pop />} />
            <Route path="/genres/metal" element={<Metal />} />
            <Route path="/genres/latina" element={<Latina />} />
            <Route path="/genres/jazz" element={<Jazz />} />
            <Route path="/genres/disco" element={<Disco />} />
            <Route path="/genres/hiphop" element={<HipHop />} />
            <Route path="/genres/electronica" element={<Electronica />} />
            <Route path="/genres/blues" element={<Blues />} />
            <Route path="/genres/baladas" element={<Baladas />} />
            <Route path="/players/cassette-players" element={<CasetesPlayers />} />
            <Route path="/players/mp-players" element={<MpPlayers />} />
            <Route path="/accesories/adapters" element={<AdaptersPage />} />
            <Route path="/accesories/cleaners" element={<CleanersPage />} />
            <Route path="/accesories/earphones" element={<EarphonesPage />} />
            <Route path="/accesories/cases" element={<CasesPage />} />
            <Route path="/hot/new-products" element={<NewProductsPage />} />
            <Route path="/hot/offers" element={<OffersPage />} />
            <Route path="/hot/top-sells" element={<TopSellsPage />} />
            <Route path="/pre-sells" element={<PreSellsPage />} />
            <Route path="/search" element={<SearchResults />} />
          </Routes>
        </Router>
      </CartProvider>
    </SearchProvider>
    </>
  )
}

export default App
