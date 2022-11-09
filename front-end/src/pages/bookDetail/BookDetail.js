import React, { useEffect, useState } from 'react';

export const BookDetail = () => {
    //TODO: provide initial state for book detail
    //const [bookDetail, setBook] = useState([])

    //TODO: get book detail information from API and update state
    useEffect(
        () => {
            fetch(`https://localhost:7294/api/Book/${bookDetail.id}`)
                .then(response => response.json())
                .then((bookArray) => {
                    setBook(bookArray)
                })
    },
    []
    )

    const handleAddToCartButtonClick = () => {
        event.preventDefault()
        /*
        TODO: Perform the PUT fetch() call here to update the cart.
        */
    }
    return (
    <div>
        <h1>Book Details Page</h1>
        {/*TODO: insert book cover image*/}
        <h2>Book Title</h2>
        <p>AuthorFirstName AuthorLastName</p>
        <p>Price $</p>
        <button>Add to Cart</button>
        <h3>Description</h3>
        <p>Insert book description here</p>
        <p>Quantity Available:</p>
        <p>Publication Date:</p>
        <p>Genres:</p>       
    </div>
    )
}