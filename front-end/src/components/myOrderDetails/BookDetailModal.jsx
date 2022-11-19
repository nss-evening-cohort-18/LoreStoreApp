import React from 'react';
import { useState, useEffect } from 'react';
import { Modal } from 'react-bootstrap';
import './BookDetailModal.css';


function BookDetailModal({ show, bookIdKey, setShowModal }) {
  const [book, setBook] = useState();

  useEffect(() => {
    fetch(`https://localhost:7294/api/Book/${bookIdKey}`)
      .then((res) => res.json())
      .then((data) => {
        setBook(data);
      });
  }, [bookIdKey]);

  if (show) {
    return (
        <Modal
            show
            size="lg"
            centered
            className="modal__delete"
        >
        <Modal.Header className="modal__header" closeButton></Modal.Header>
            <Modal.Body className="modal__body">
                <h2 className="book_title">{book.title}</h2>
                <p className="book_author">
                {book.authorFirstName ? book.authorFirstName : ''}{' '}
                {book.authorLastName ? book.authorLastName : ''}
                </p>
                <p className="book_price">Price ${book.price}</p>
                <h3 className="book_description_header">Description</h3>
                <p className="book_description">{book.description}</p>
                <h3 className="book_details">Product Details</h3>
                <p className="book_price">Price ${book.price}</p> {/* Need to modify price so that it displays decimals, even if it's an even number, e.g. $81.00 instead of $81 */}
                <p className="book_quantity">
                Quantity Available: {book.inventoryQuantity}
                </p>
                <p className="book_publication_date">
                Publication Date: {book.datePublished} {/* Need to modify the date so that it's presented mm/dd/yyyy */}
                </p>
                <p className="book_genres">Genres: {book.subGenre}</p>
                <button className="btn__btn-primary" onClick={() => { setShowModal(false); }}>Close</button>
            </Modal.Body>
        </Modal>
    );
  } else {
    return (<></>)
  }
}

export default BookDetailModal;
