import React from 'react';
import { useHistory } from 'react-router-dom/cjs/react-router-dom';
import './NoItems.css';

const NoItems = () => {
    const history = useHistory();
    const onclick = () => {
        history.push('/search')
    };
  return (
    <div className='no-items-container'>
        <div className='no-items'>
        <h3>Your cart is empty</h3>
        <button onClick={onclick}>Continue Shopping</button>
        </div>
    </div>
  )
}

export default NoItems