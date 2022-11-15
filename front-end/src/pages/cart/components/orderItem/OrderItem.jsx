import React, { useState, useEffect } from 'react';
import './OrderItem.css';
import { FaTrash } from 'react-icons/fa';

const OrderItem = ({ item }) => {
  const [book, setBook] = useState({});
  const onchange = (e) => {
    if (e.target.value > 99) {
      e.target.value = 99;
    }
  };

  const getBook = async (bookId) => {
    const res = await fetch(`https://localhost:7294/api/Book/${bookId}`);
    if (res.status === 200) {
      const res1 = await res.json();
      return res1;
    }
  };

  useEffect(() => {
    const getCurrentBook = async () => {
      const book = await getBook(item.bookId);
      setBook(book[0]);
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
        <FaTrash className="delete-btn" />
      </td>
    </tr>
  );
};

export default OrderItem;
