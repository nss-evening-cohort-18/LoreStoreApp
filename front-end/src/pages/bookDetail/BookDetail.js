import React, { useEffect, useState } from 'react';
import {
  useParams,
  useHistory,
} from 'react-router-dom/cjs/react-router-dom.min';
import { Container, Row, Col } from 'react-bootstrap';
import { Button } from 'bootstrap';
import './BookDetail.css';

export const BookDetail = () => {
  const [book, setBook] = useState({}); //initial state variable for current book object
  const { bookId } = useParams(); //variable storing the route parameter

  //const history = useHistory();

  //TODO: get book detail information from API and update state when the value of bookId changes
  useEffect(() => {
    console.log(bookId);
    fetch(`https://localhost:7294/api/Book/${bookId}`, {
      method: 'GET',
    })
      .then((res) => res.json())
      .then((data) => {
        setBook(data);
      });
  }, [bookId]);

  //TODO: how do we want to handle the add to cart button?
  // const handleAddToCartButtonClick = (e, id) => {
  //     e.stopPropogation();
  //     return history.push(`/cart/${id}`);
  // };

  return (
    <>
      <Container className="book">
        <Row>
          <Col>
            {/*TODO: insert book cover image*/}
            <img
              src={book.photoUrl}
              alt="book cover"
              className="book_cover_image"
            />
          </Col>
          <Col>
            <h2 className="book_title">{book.title}</h2>
            <p className="book_author">
              {book.authorFirstName ? book.authorFirstName : ''}{' '}
              {book.authorLastName ? book.authorLastName : ''}
            </p>
            <p className="book_price">Price ${book.price}</p>
            <button className="book_addToCart_button">Add to Cart</button>
            <h3 className="book_description_header">Description</h3>
            <p className="book_description">{book.description}</p>
            <h3 className="book_details">Product Details</h3>
            <p className="book_price">Price ${book.price}</p>
            <p className="book_quantity">
              Quantity Available: {book.inventoryQuantity}
            </p>
            <p className="book_publication_date">
              Publication Date: {book.datePublished}
            </p>
            <p className="book_genres">Genres: {book.subGenre}</p>
          </Col>
        </Row>
      </Container>
    </>
  );
};
