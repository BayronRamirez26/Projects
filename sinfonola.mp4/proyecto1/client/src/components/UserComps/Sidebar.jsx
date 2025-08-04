import React from 'react';
import './Sidebar.css';

export default function Sidebar({ onProfile, onOrders, onFavorites, onCupons, onLogout }) {
  return (
    <aside className="sidebar">
      <button className="sidebar-button" onClick={onProfile}>
        Tu Perfil</button>
      <button className="sidebar-button" onClick={onOrders}>
        Tus Órdenes</button>
      <button className="sidebar-button" onClick={onFavorites}>
        Favoritos</button>
      <button className="sidebar-button" onClick={onCupons}>
        Cupones</button>
      <button className="sidebar-button log-out-button" onClick={onLogout}>
        Cerrar sesión</button>
    </aside>
  );
}
