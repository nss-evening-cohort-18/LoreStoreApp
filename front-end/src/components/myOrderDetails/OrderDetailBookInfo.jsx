import React, { useEffect } from 'react';
import { useState } from 'react';
import BookDetailModal from './BookDetailModal';

function OrderDetailBookInfo({ bookId, order }) {
  const [bookTitle, setBookTitle] = useState();
  const [showModal, setShowModal] = useState(false);

  useEffect(
    () => {
        fetch(`https://localhost:7294/api/Book/${bookId}`)
        .then((res) => res.json())
        .then((data) => { setBookTitle(data.title); })
    }, [bookId])
  return (
    <>
      <td>{bookTitle}</td>
      <td>{order.quantity}</td>
      <td>{order.unitPrice}</td>
      <td><button onClick={() => { setShowModal(true);}}>View Details</button></td>
      <BookDetailModal show={showModal} bookIdKey={bookId} setShowModal={setShowModal} />
    </>
  );
}

export default OrderDetailBookInfo;
