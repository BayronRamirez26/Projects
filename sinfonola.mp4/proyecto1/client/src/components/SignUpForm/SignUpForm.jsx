import React from 'react';
import { useForm } from 'react-hook-form';
import { useNavigate } from 'react-router-dom';
import './SignUpForm.css';

function SignUpForm() {
  const { register, handleSubmit, formState: { errors, isValid } } = useForm({ mode: 'onChange' });
  const navigate = useNavigate();

  const onSubmit = async (data) => {
    const body = {
      email: data.email,
      name: data.full_name,
      phone: data.phone,
      password: data.password,
      cart: []
    };
  
    try {
      const response = await fetch('http://localhost:3001/users/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
      });

      if (response.ok) {
        navigate('/');
      } else {
        alert('Error al registrar usuario');
      }
    } catch (error) {
      console.error('Error al registrar:', error);
    }
  };

  return (
    <div className="sign-up-box">
      <h2 className="sign-up-box-title">Registrarse</h2>
      <form onSubmit={handleSubmit(onSubmit)} className="sign-up-box-form">

        <div className="sign-up-box-group">
          <label>Nombre *</label>
          <input
            type="text"
            className={errors.full_name ? 'sign-up-box-error' : ''}
            {...register('full_name', { required: 'Nombre requerido' })}
          />
          {errors.full_name && <span className="sign-up-box-error-text">{errors.full_name.message}</span>}
        </div>

        <div className="sign-up-box-group">
          <label>Correo electrónico *</label>
          <input
            type="email"
            className={errors.email ? 'sign-up-box-error' : ''}
            {...register('email', {
              required: 'Email requerido',
              pattern: {
                value: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
                message: 'Formato de email inválido'
              }
            })}
          />
          {errors.email && <span className="sign-up-box-error-text">{errors.email.message}</span>}
        </div>
        
        <div className="sign-up-box-group">
          <label>Número telefónico *</label>
          <input
            type="tel"
            className={errors.phone ? 'sign-up-box-error' : ''}
            {...register('phone', {
              required: 'Teléfono requerido',
              pattern: {
                value: /^[0-9]{8}$/,
                message: 'Debe tener 8 dígitos'
              }
            })}
          />
          {errors.phone && <span className="sign-up-box-error-text">{errors.phone.message}</span>}
        </div>
        
        <div className="sign-up-box-group">
          <label>Contraseña *</label>
          <input
            type="password"
            className={errors.password ? 'sign-up-box-error' : ''}
            {...register('password', {
              required: 'Contraseña requerida',
              pattern: {
                value: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$/,
                message: 'Mínimo 8 caracteres, mayúscula, minúscula, número y símbolo'
              }
            })}
          />
          {errors.password && <span className="sign-up-box-error-text">{errors.password.message}</span>}
        </div>

        <button
          type="submit"
          disabled={!isValid}
          className={`sign-up-box-btn ${isValid ? 'active' : ''}`}
        >
          Registrarse
        </button>

        <div className="auth-links">
          <p>¿Ya tienes una cuenta? <a href="/sign-in">Inicia sesión</a></p>
        </div>
      </form>
    </div>
  );
};

export default SignUpForm;