import React, { useState } from 'react';
import { useCart } from '../../context/CartContext.jsx';
import { useNavigate } from 'react-router-dom';
import './LoginForm.css';

const LoginForm = () => {
  const [email, setEmail] = useState('');
  const { handleLogin } = useCart();
  const [password, setPassword] = useState('');
  const [errors, setErrors] = useState({
    email: '',
    password: '',
    credentials: false
  });

  const validateEmail = (email) => {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
  };

  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    let isValid = true;
    const newErrors = {
      email: '',
      password: '',
      credentials: false
    };

    // Validación correo
    if (!email.trim()) {
      newErrors.email = 'Este campo es obligatorio';
      isValid = false;
    } else if (!validateEmail(email)) {
      newErrors.email = 'Correo inválido';
      isValid = false;
    }

    // Validación contraseña
    if (!password.trim()) {
      newErrors.password = 'Este campo es obligatorio';
      isValid = false;
    }

    setErrors(newErrors);

    if (!isValid) return;

    const body = {
      email: email,
      password: password
    };

    try {
      const response = await fetch('http://localhost:3001/users/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
      });

      if (response.ok) {
        const { token, user } = await response.json();
        await handleLogin(token, user);
        navigate('/');
      } else {
        setErrors({
          ...newErrors,
          credentials: true,
          password: 'Credenciales invalidas.'
        });
      }
    } catch (error) {
      console.error('Error al iniciar sesión:', error);
    }
  };

  return (
    <div className="login-box">
      <h2 className="login-box-title">Iniciar sesión</h2>
      <form className="login-box-form" onSubmit={handleSubmit}>
        <input type="hidden" name="login_source" value="comet_headerless_login" />
        <input type="hidden" name="next" value="" />
        <input type="hidden" name="shared_prefs_data" value="" />

        <div className="login-box-group">
          <label htmlFor="email">Correo</label>
          <input
            id="email"
            name="email"
            type="text"
            value={email}
            onChange={(e) => {
              setEmail(e.target.value);
              if (errors.email || errors.credentials) {
                setErrors({ ...errors, email: '', credentials: false });
              }
            }}
            className={errors.email || errors.credentials ? 'login-box-error' : ''}
          />
          {errors.email && <span className="login-box-error-text">{errors.email}</span>}
        </div>

        <div className="login-box-group">
          <label htmlFor="password">Contraseña</label>
          <input
            id="password"
            name="password"
            type="password"
            value={password}
            onChange={(e) => {
              setPassword(e.target.value);
              if (errors.password || errors.credentials) {
                setErrors({ ...errors, password: '', credentials: false });
              }
            }}
            className={errors.password || errors.credentials ? 'login-box-error' : ''}
          />
          {errors.password && <span className="login-box-error-text">{errors.password}</span>}
        </div>

        <button type="submit" className="login-box-btn">
          Iniciar sesión
        </button>

        <div className="login-box-links">
          <a href="/recover">¿Olvidaste tu contraseña?</a>
          <a href="/sign-up" className="login-box-link-register">
            Crear cuenta
          </a>
        </div>
      </form>
    </div>
  );
};


export default LoginForm;