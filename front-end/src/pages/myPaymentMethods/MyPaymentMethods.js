import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min';
import './MyPaymentMethods.css'

function MyPaymentMethods({ user }) {
  const [paymentMethod, setPaymentMethod] = useState(null);
  const [cardFirstName, setCardFirstName] = useState("");
  const [cardLastName, setCardLastName] = useState("");
  const [cardNumber, setCardNumber] = useState("");
  const [cardExpirationYear, setCardExpirationYear] = useState("");
  const [cardExpirationMonth, setCardExpirationMonth] = useState("");
  const [cardCvv, setCardCvv] = useState("");
  const [editsMade, setEditsMade] = useState(false);
  const history = useHistory();

  const deletePaymentMethod = (id) => {
    fetch(`https://localhost:7294/api/PaymentMethod/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${user.Aa}`,
        },
    })
    .then(() => { window.location.reload(); }, [])
  }

  const addPaymentMethod = () => {
    const newPaymentMethod = {
        userId: user.id,
        firstName : cardFirstName,
        lastName: cardLastName,
        cardNumber: cardNumber,
        expirationYear: cardExpirationYear,
        expirationMonth: cardExpirationMonth,
        cvv: cardCvv
    }
    fetch(`https://localhost:7294/api/PaymentMethod`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${user.Aa}`
        },
        body: JSON.stringify(newPaymentMethod),
    })
    .then(() => { window.location.reload(); })
  }

  const updatePaymentMethod = (id) => {
    const updatedPaymentMethod = {
        userId: user.id,
        firstName : cardFirstName,
        lastName: cardLastName,
        cardNumber: cardNumber,
        expirationYear: cardExpirationYear,
        expirationMonth: cardExpirationMonth,
        cvv: cardCvv
    }
    fetch(`https://localhost:7294/api/PaymentMethod/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${user.Aa}`
        },
        body: JSON.stringify(updatedPaymentMethod),
    })
    .then(() => { window.location.reload(); })
  }

  useEffect(
    () => {
        fetch(`https://localhost:7294/api/PaymentMethod/userId/${user.id}`, {
            headers: {
              'Content-Type': 'application/json',
              Authorization: `Bearer ${user.Aa}`,
            },
          })
        .then((res) => res.json())
        .then(
            (data) => { 
                setPaymentMethod(data.status === 404 ? null : data); 
                setCardFirstName(data.firstName);
                setCardLastName(data.lastName);
                setCardNumber(data.cardNumber);
                setCardExpirationYear(data.expirationYear);
                setCardExpirationMonth(data.expirationMonth);
                setCardCvv(data.cvv);
            }
        );
    }, []
  )
  return (
    <>
        <h1 className="paymentMethodsTitle">My Payment Methods</h1>
        <div className="content">
        <div className="cardContainer">
            <div className="biographicalInfo">
                <p><b>First Name:</b></p>
                <input required className="paymentInput" value={cardFirstName} onChange={(e) => { setCardFirstName(e.target.value); setEditsMade(true); }} placeholder={cardFirstName != null ? cardFirstName : "First Name (type to edit)"} />
                <p><b>Last Name:</b></p>
                <input required className="paymentInput" value={cardLastName} onChange={(e) => { setCardLastName(e.target.value); setEditsMade(true); }} placeholder={cardLastName != null ? cardLastName : "Last Name (type to edit)"} />
                <p><b>Card Number:</b></p>
                <input required className="paymentInput" value={cardNumber} onChange={(e) => { setCardNumber(e.target.value); setEditsMade(true); }} placeholder={cardNumber != null ? cardNumber: "Card Number (type to edit)"} />
            </div>
            <div className="monthYearContainer">
                <p><b>Expiration</b></p>
                <input required className="paymentInput" value={cardExpirationMonth} onChange={(e) => { setCardExpirationMonth(e.target.value); setEditsMade(true); }} placeholder={cardExpirationMonth != null ? cardExpirationMonth: "mm"} />
                <input required className="paymentInput" value={cardExpirationYear} onChange={(e) => { setCardExpirationYear(e.target.value); setEditsMade(true); }} placeholder={cardExpirationYear != null ? cardExpirationYear: "yy"} />
            </div>
            <p><b>CVV: </b></p>
            <div className="cvvContainer">
                <input required className="paymentInput" value={cardCvv} onChange={(e) => { setCardCvv(e.target.value)}} placeholder={cardCvv != null ? cardCvv: "Card Number (type to edit)"} />
            </div>
            <div className="paymentButtonsContainer">
                <button onClick={() => { history.push("/profile"); }}>Go back</button>
                {paymentMethod != null ? <button value={paymentMethod.id} onClick={(e) => { deletePaymentMethod(e.target.value); }}>Delete Payment Method</button> : ``}
                {editsMade && paymentMethod != null ? <button value={paymentMethod.id} onClick={(e) => { updatePaymentMethod(e.target.value) }}>Submit Edits</button> : <button hidden onClick={() => { history.push("/profile"); }}>Submit Edits</button>}
                {editsMade && paymentMethod == null ? <button onClick={() => { addPaymentMethod(); }}>Add Payment Method</button> : ``}
            </div>
        </div>
        </div>
    </>
  )
}

export default MyPaymentMethods;
