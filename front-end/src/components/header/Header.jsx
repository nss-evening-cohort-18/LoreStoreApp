import React from 'react';
import './Header.css';
import Logo from '../../assets/logo.png';
import { Link, useHistory } from 'react-router-dom/cjs/react-router-dom.min';
import { FaSearch, FaShoppingCart } from 'react-icons/fa';
import { signOut } from '../../utils/auth';

const Header = ({ user, setFilter, filter }) => {
  let history = useHistory();
  const onChange = (e) => {
    setFilter((prev) => {
      return { ...prev, searchString: e.target.value };
    });
  };
  const onClick = (genre) => {
    setFilter((prev) => {
      return { ...prev, genre };
    });
    if (history.location.pathname !== '/search') history.push('/search');
  };
  const onCartClick = () => {
    if (history.location.pathname !== '/cart') history.push('/cart');
  };
  const onKeyDown = (e) => {
    const elem = document.querySelector('.searchInput');
    if (elem === document.activeElement && e.key === 'Enter') {
      // Add function to run the filtered search here
      console.log(e);
      if (history.location.pathname !== '/search') history.push('/search');
    }
  };
  return (
    <header>
      <div className="content">
        <div className="header-left header-item">
          <div className="img-container">
            <img src={Logo} alt="The Lore Store Logo" />
          </div>

          <div className="search">
            <div className="search-bar">
              <FaSearch className="mag-glass" />
              <input
                type="text"
                placeholder="Search..."
                value={filter.searchString}
                onChange={onChange}
                onKeyDown={onKeyDown}
                className="searchInput"
              />
            </div>
            <div className="genre-list">
              <ul>
                <li className="genre" onClick={() => onClick('fiction')}>
                  Fiction
                </li>
                <li className="genre" onClick={() => onClick('non-fiction')}>
                  Non-Fiction
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div className="header-right header-item">
          <div className="cart" onClick={onCartClick}>
            <FaShoppingCart className="shopping-cart" />
          </div>

          <div className="user-photo dropdown">
            <img src={user.photoURL} alt="User Profile" />
            <ul className="dropdown-content">
              <Link to="/profile" style={{ textDecoration: 'none' }}>
                <li>Profile</li>
              </Link>
              <li onClick={signOut}>Sign Out</li>
            </ul>
          </div>
        </div>
      </div>
    </header>
  );
};

export default Header;
