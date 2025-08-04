import { createContext, useContext, useState, useEffect } from 'react';

const CartContext = createContext();

export const CartProvider = ({ children }) => {
  const [isLoading, setIsLoading] = useState(true);
  const [cartItems, setCartItems] = useState([]);
  const [discount, setDiscount] = useState(0);
  const [discountCode, setDiscountCode] = useState('');
  const [currentUser, setCurrentUser] = useState(null);

  // Cargar carrito al iniciar
  useEffect(() => {
    const loadCartData = async () => {
      setIsLoading(true);
      const token = localStorage.getItem('token');
      const localCart = JSON.parse(localStorage.getItem('localCart') || '[]');

      try {
        if (token) {
          // Verificar token y cargar usuario
          const userResponse = await fetch('http://localhost:3001/users/getInfo', {
            headers: { 'Authorization': `Bearer ${token}` }
          });

          if (!userResponse.ok) throw new Error('Error al cargar usuario');

          const userData = await userResponse.json();
          setCurrentUser(userData);

          // Cargar carrito del backend
          const cartResponse = await fetch('http://localhost:3001/users/cart', {
            headers: { 'Authorization': `Bearer ${token}` }
          });

          const serverCart = cartResponse.ok ? await cartResponse.json() : [];

          // Sincronizar si hay carrito local
          if (localCart.length > 0) {
            const syncResponse = await fetch('http://localhost:3001/users/cart/sync', {
              method: 'POST',
              headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
              },
              body: JSON.stringify({ cart: localCart })
            });

            const mergedCart = syncResponse.ok ? await syncResponse.json() : serverCart;
            setCartItems(mergedCart);
            localStorage.removeItem('localCart');
          } else {
            setCartItems(serverCart);
          }
        } else {
          setCartItems(localCart);
        }
      } catch (error) {
        console.error('Error loading cart:', error);
        setCartItems(localCart);
      } finally {
        setIsLoading(false);
      }
    };

    loadCartData();
  }, []);

  // Función para guardar cambios
  const saveCart = (newCart) => {
    const token = localStorage.getItem('token');

    // Actualizar estado local primero
    if (token) {
      // Guardar en backend
      fetch('http://localhost:3001/users/cart', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({ cart: newCart })
      }).catch(error => {
        console.error('Error al guardar carrito:', error);
        localStorage.setItem('localCart', JSON.stringify(newCart));
      });
    } else {
      // Guardar en localStorage para usuarios no autenticados
      localStorage.setItem('localCart', JSON.stringify(newCart));
    }
  };

  // Función para login
  const handleLogin = async (token, userData) => {
    try {
      // 1. Guardar token
      localStorage.setItem('token', token);
      const localCart = JSON.parse(localStorage.getItem('localCart') || '[]');

      const serverResponse = await fetch('http://localhost:3001/users/cart', {
        headers: {
          'Authorization': `Bearer ${token}`,
          'Content-Type': 'application/json'
        }
      });

      if (!serverResponse.ok) {
        throw new Error(`HTTP error! status: ${serverResponse.status}`);
      }

      // Verificar que la respuesta tenga contenido
      const responseText = await serverResponse.text();
      const serverCart = responseText ? JSON.parse(responseText) : [];

      // 3. Sincronizar solo si hay items locales
      let finalCart = serverCart;
      if (localCart.length > 0) {
        const syncResponse = await fetch('http://localhost:3001/users/cart/sync', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
          },
          body: JSON.stringify({ cart: localCart })
        });

        if (!syncResponse.ok) {
          throw new Error(`Sync failed! status: ${syncResponse.status}`);
        }

        const syncText = await syncResponse.text();
        finalCart = syncText ? JSON.parse(syncText) : serverCart;
        localStorage.removeItem('localCart');
      }

      // 4. Actualizar estados
      setCurrentUser({
        ...userData,
        cart: finalCart
      });
      setCartItems(finalCart);

    } catch (error) {
      console.error('Login error:', error);
      // Restaurar carrito local si falla
      const localCart = JSON.parse(localStorage.getItem('localCart') || '[]');
      setCartItems(localCart);
    }
  };

  // Función para logout
  const handleLogout = () => {
    localStorage.removeItem('token');
    setCurrentUser(null);
  };


  // Añadir producto al carrito
  const addToCart = (product) => {
    setCartItems(prevItems => {
      const existingItem = prevItems.find(item => item.id === product.id);
      let newItems;

      if (existingItem) {
        newItems = prevItems.map(item =>
          item.id === product.id
            ? { ...item, quantity: item.quantity + product.quantity }
            : item
        );
      } else {
        newItems = [...prevItems, product];
      }
      saveCart(newItems);
      return newItems;
    });
  };
  // Eliminar producto
  const removeFromCart = (productId) => {
    setCartItems(prevItems => {
      const newItems = prevItems.filter(item => item.id !== productId);
      saveCart(newItems); // Pasa el nuevo carrito
      return newItems;
    });
  };

  // Actualizar cantidad
  const updateQuantity = (productId, newQuantity) => {
    if (newQuantity <= 0) {
      removeFromCart(productId);
      return;
    }
    setCartItems(prevItems =>
      prevItems.map(item =>
        item.id === productId ? { ...item, quantity: newQuantity } : item
      )
    );
    saveCart();
  };


  // Aplicar cupón 
  const applyCoupon = (code) => {
    const upperCode = code.toUpperCase();

    if (validCoupons[upperCode]) {
      setDiscount(validCoupons[upperCode]);
      setDiscountCode(upperCode);
      return { success: true, discount: validCoupons[upperCode] };
    } else {
      setDiscount(0);
      setDiscountCode('');
      return { success: false, error: 'Cupón no válido' };
    }
  };


  const clearCoupon = () => {
    setDiscount(0);
    setDiscountCode('');
  };

  const clearCart = () => {
    setCartItems([]);
    saveCart([]);
  };
  const subtotal = cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
  const discountedAmount = subtotal * (discount / 100);
  const total = subtotal - discountedAmount;

  return (
    <CartContext.Provider
      value={{
        cartItems,
        addToCart,
        removeFromCart,
        updateQuantity: (id, quantity) => {
          if (quantity <= 0) {
            removeFromCart(id);
            return;
          }
          setCartItems(prev => {
            const newCart = prev.map(item =>
              item.id === id ? { ...item, quantity } : item
            );
            return newCart;
          });
        },
        clearCart: () => setCartItems([]),
        applyCoupon,
        clearCoupon,
        subtotal,
        discount,
        discountCode,
        discountedAmount,
        total,
        itemCount: cartItems.reduce((total, item) => total + item.quantity, 0),
        handleLogin,
        handleLogout,
        currentUser,
        isLoading
      }}
    >
      {children}
    </CartContext.Provider>
  );
};

export const useCart = () => {
  const context = useContext(CartContext);
  if (!context) {
    throw new Error('useCart debe usarse dentro de un CartProvider');
  }
  return context;
};