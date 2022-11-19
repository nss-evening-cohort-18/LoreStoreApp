import React, { useState, useEffect } from 'react';
import './OrderItem.css';
import { FaTrash } from 'react-icons/fa';

const OrderItem = ({ item, setOrderItems, setUpdatedCart, user }) => {
  const [book, setBook] = useState({});
  const onchange = (e) => {
    if (e.target.value > book.inventoryQuantity) {
      e.target.value = book.inventoryQuantity;
    } else if (e.target.value.length < 1) {
      e.target.value = 0;
    }
    setUpdatedCart(prev => {
      const prevItems = [...prev];
      const itemToUpdate = prevItems.find(orderDetail => item.id === orderDetail.id);
      if(itemToUpdate) {
        const index = prevItems.findIndex(orderItem => orderItem.id === itemToUpdate.id);
        itemToUpdate.quantity = parseInt(e.target.value);
        prevItems.splice(index, 1, itemToUpdate);
        return prevItems;
      } else {
        prevItems.push({...item, quantity: e.target.value});
        return prevItems;
      }
    });
  };

  const getBook = async (bookId) => {
    const res = await fetch(`https://localhost:7294/api/Book/${bookId}`);
    if (res.status === 200) {
      const res1 = await res.json();
      return res1;
    }
  };

  const removeFromCart = async () => {
    const res = await fetch(`https://localhost:7294/api/OrderDetail/${item.id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${user.Aa}`,
      }
    });
    if(res.status === 200){
      setOrderItems(prev => prev.filter(orderItem => orderItem.id !== item.id));
    }
  };

  useEffect(() => {
    const getCurrentBook = async () => {
      const book = await getBook(item.bookId);
      setBook(book);
    };
    getCurrentBook();
  }, [item]);
  return (
    <tr className="order-item">
      <td className="book-info">
        <div className='author-and-book'>
            <p className='book'>{book.title}</p>
            {book.authorFirstName || book.authorLastName ? <p className='author'>{book.authorLastName}, {book.authorFirstName}</p> : null}
        </div>
      </td>
      <td className="quantity">
        <input
          type="number"
          placeholder={item.quantity}
          min="0"
          max="99"
          onChange={onchange}
        />
      </td>
      <td className="price">${item.unitPrice}</td>
      <td>
        <FaTrash className="delete-btn" onClick={removeFromCart}/>
      </td>
    </tr>
  );
};

export default OrderItem;
