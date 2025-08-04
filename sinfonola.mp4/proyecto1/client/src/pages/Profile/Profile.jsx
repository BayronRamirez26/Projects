import React, { useState } from 'react';
import Sidebar from '../../components/UserComps/Sidebar';
import Footer from "../../components/Footer/Footer.jsx";
import Header from "../../components/Header/Header.jsx";
import OrdersClient from "../../components/UserComps/OrdersClient.jsx";
import './Profile.css';

const Profile = () => {
  const [screen, setScreen] = useState('editProfile');
  const [name, setName] = useState('');
  const [city, setCity] = useState('San José');
  const [phone, setPhone] = useState('');
  const [zipCode, setZipCode] = useState('37682');
  const [email, setEmail] = useState('');
  const [address, setAddress] = useState('San Pedro frente a la UCR');
  const [photo, setPhoto] = useState('../../../../public/profileImage.png');
  const [errors, setErrors] = useState({
    name: '',
    city: '',
    phone: '',
    zipCode: '',
    email: '',
    address: ''
  });
  

  const registeredEmails = ['ERJ07@gmail.com', 'sudo@gmail.com'];

  const ordersClient = [
    [123, 36000, 1, 4011486, 787550],
    [124, 81000, 2, 1577905, 500541, 2263356, 2696355, 500541, 1577905],
    [125, 27000, 2, 417977, 2696355],
  ];

  const validateEmail = (email) => {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
  };

  const validatePhone = (phone) => {
    // Remove all non-digit characters before validation
    const digitsOnly = phone.replace(/\D/g, '');
    return digitsOnly.length === 8;
  };

  const handleNameChange = (e) => {
    setName(e.target.value);
    if (errors.name) setErrors({...errors, name: ''});
  };

  const handleCityChange = (e) => {
    setCity(e.target.value);
    if (errors.city) setErrors({...errors, city: ''});
  };

  const handlePhoneChange = (e) => {
    setPhone(e.target.value);
    if (errors.phone) setErrors({...errors, phone: ''});
  };

  const handleZipCodeChange = (e) => {
    setZipCode(e.target.value);
    if (errors.zipCode) setErrors({...errors, zipCode: ''});
  };

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
    if (errors.email) setErrors({...errors, email: ''});
  };

  const handleAddressChange = (e) => {
    setAddress(e.target.value);
    if (errors.address) setErrors({...errors, address: ''});
  };

  const handleFileChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => setPhoto(reader.result);
      reader.readAsDataURL(file);
    }
  };

  const handleSave = () => {
    const newErrors = {
      name: '',
      city: '',
      phone: '',
      zipCode: '',
      email: '',
      address: ''
    };

    let isValid = true;

    // Name validation
    if (!name.trim()) {
      newErrors.name = 'El nombre es obligatorio';
      isValid = false;
    }

    // City validation
    if (!city.trim()) {
      newErrors.city = 'La ciudad es obligatoria';
      isValid = false;
    }

    // Phone validation
    if (!phone.trim()) {
      newErrors.phone = 'El teléfono es obligatorio';
      isValid = false;
    } else if (!validatePhone(phone)) {
      newErrors.phone = 'El teléfono debe tener 8 dígitos';
      isValid = false;
    }

    // Zip code validation
    if (!zipCode.trim()) {
      newErrors.zipCode = 'El código postal es obligatorio';
      isValid = false;
    }

    // Email validation
    if (!email.trim()) {
      newErrors.email = 'El correo es obligatorio';
      isValid = false;
    } else if (!validateEmail(email)) {
      newErrors.email = 'Correo electrónico inválido';
      isValid = false;
    } else if (registeredEmails.includes(email)) { 
      newErrors.email = 'Este correo ya está registrado';
      isValid = false;
    }

    // Address validation
    if (!address.trim()) {
      newErrors.address = 'La dirección es obligatoria';
      isValid = false;
    }

    setErrors(newErrors);

    if (isValid) {
      alert(`Perfil actualizado: ${name}`);
      // aca se manda al servidor cuando tengamos base
    }
  };

  // Obtener el token del localStorage
  const token = localStorage.getItem("token");

  // Consulta al backend para obtener los datos del usuario
  const fetchUserData = async () => {
    try {
      const res = await fetch(`http://localhost:3001/users/getInfo`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      if (res.ok) {
        const data = await res.json();
        // Actualizar los estados con los datos recibidos
        setName(data.name || "");
        setPhone(data.phone || "");
        setEmail(data.email || "");
      }
    } catch (err) {
      console.error("Error fetching user data", err);
    }
  };

  React.useEffect(() => {
    fetchUserData();
     
  }, []);

  return (
    <div className="profile-page" style={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
      <Header />

      <div style={{ display: 'flex', flex: 1 }}>
        <Sidebar
          onProfile={() => setScreen('editProfile')}
          onOrders={() => setScreen('orders')}
          onFavorites={() => setScreen('favorites')}
          onCupons={() => setScreen('cupons')}
          onLogout={() => {
            localStorage.removeItem('token');
            window.location.href = '/';
          }}
        />

        <main className="profile-content" style={{ flex: 1, padding: '1rem' }}>
          {screen === 'editProfile' && (
            <div className="profile-card">
              <div className="photo-upload">
                <input
                  id="file-upload"
                  type="file"
                  accept="image/*"
                  onChange={handleFileChange}
                  style={{ display: 'none' }}
                />
                <label htmlFor="file-upload">
                  {photo ? (
                    <img src={photo} alt="profile" className="photo-preview" />
                  ) : (
                    <div className="photo-preview-placeholder">Subir Foto</div>
                  )}
                </label>
              </div>

              <div className="edit-input" style={{ 
                display: 'flex', 
                flexWrap: 'wrap', 
                gap: '1rem' 
              }}>

                <div style={{ flex: '1 1 45%' }}>
                  <h5 className="UpText">
                    Nombre
                  </h5>
                  <input
                    type="text"
                    value={name}
                    onChange={handleNameChange}
                    placeholder="Ingresa tu nombre"
                    style={{ width: '100%' }}
                    className={errors.name ? 'edit-input-error' : ''}
                  />
                  {errors.name && <span className="edit-input-error-text">{errors.name}</span>}
                </div>

                <div style={{ flex: '1 1 45%' }}>
                  <h5 className="UpText">
                    Ciudad
                  </h5>
                  <input
                    type="text"
                    value={city}
                    onChange={handleCityChange}
                    placeholder="Ingresa tu ciudad"
                    style={{ width: '100%' }}
                    className={errors.city ? 'edit-input-error' : ''}
                  />
                  {errors.city && <span className="edit-input-error-text">{errors.city}</span>}
                </div>

                <div style={{ flex: '1 1 45%' }}>
                  <h5 className="UpText">
                    Telefono
                  </h5>
                  <input
                    type="text"
                    value={phone}
                    onChange={handlePhoneChange}
                    placeholder="Ingresa tu teléfono"
                    style={{ width: '100%' }}
                    className={errors.phone ? 'edit-input-error' : ''}
                  />
                  {errors.phone && <span className="edit-input-error-text">{errors.phone}</span>}
                </div>

                <div style={{ flex: '1 1 45%' }}>
                  <h5 className="UpText">
                    Código Postal
                  </h5>
                  <input
                    type="text"
                    value={zipCode}
                    onChange={handleZipCodeChange}
                    placeholder="Ingresa tu zip"
                    style={{ width: '100%' }}
                    className={errors.zipCode ? 'edit-input-error' : ''}
                  />
                  {errors.zipCode && <span className="edit-input-error-text">{errors.zipCode}</span>}
                </div>

                <div style={{ flex: '1 1 45%' }}>
                  <h5 className="UpText">
                    Correo
                  </h5>
                  <input
                    type="text"
                    value={email}
                    onChange={handleEmailChange}
                    placeholder="Ingresa tu correo"
                    style={{ width: '100%' }}
                    className={errors.email ? 'edit-input-error' : ''}
                  />
                  {errors.email && <span className="edit-input-error-text">{errors.email}</span>}
                </div>

                <div style={{ flex: '1 1 45%' }}>
                  <h5 className="UpText">
                    Dirección
                  </h5>
                  <input
                    type="text"
                    value={address}
                    onChange={handleAddressChange}
                    placeholder="Ingresa tu dirección"
                    style={{ width: '100%' }}
                    className={errors.address ? 'edit-input-error' : ''}
                  />
                  {errors.address && <span className="edit-input-error-text">{errors.address}</span>}
                </div>
              </div>

              <button className="save-button" onClick={handleSave}>Guardar</button>
            </div>
          )}
          {screen === 'orders' && (
            <OrdersClient orders={ordersClient} />
          )}

          {screen === 'favorites' && (
            <p>No hay productos en tu wishlist.</p>
          )}

          {screen === 'cupons' && (
            <p>No tienes cupones disponibles.</p>
          )}
        </main>
      </div>

      <Footer />
    </div>
  );
};

export default Profile;