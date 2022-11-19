import React, { useEffect, useState } from 'react';
import {
  useParams,
  useHistory,
} from 'react-router-dom/cjs/react-router-dom.min';
import { Container, Row, Col } from 'react-bootstrap';
import { Button } from 'bootstrap';
import './Shipping.css';

export const Payment = ({ user }) => {
  const { orderId } = useParams(); //variable storing the route parameter
  const [firstName, updateFirstName] = useState('');
  const [lastName, updateLastName] = useState('');
  const [cardNumber, updateCardNumber] = useState('');
  const [expirationMonth, updateExpirationMonth] = useState('');
  const [expirationYear, updateExpirationYear] = useState('');
  const [cvv, updateCvv] = useState('');

  const history = useHistory();

  //Fetch orderViewModel
  useEffect(() => {
    fetch(
      `https://localhost:7294/api/Order/GetOrderCheckoutViewByOrderId/${orderId}`,
      {
        method: 'GET',
      },
    )
      .then((res) => res.json())
      .then((orderViewModel) => {
        updateCardNumber(orderViewModel.cardNumber);
        updateExpirationMonth(orderViewModel.expirationMonth);
        updateExpirationYear(orderViewModel.expirationYear);
        updateCvv(orderViewModel.cvv);
      });
  }, []);

  const paymentMethodUpdateButton = (evt) => {
    evt.preventDefault();
    //construct a new object to replace the existing one in the API
    const updatedPaymentMethod = {
      userId: user.Id,
      firstName: firstName,
      lastName: lastName,
      cardNumber: cardNumber,
      expirationMonth: expirationMonth,
      expirationYear: expirationYear,
      cvv: cvv,
    };
    //Perform the PUT request to replace the paymentMethod
    fetch(`https://localhost:7294/api/PaymentMethod/${id}`, {
      method: 'PUT',
      haders: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${user.Aa}`,
      },
      body: JSON.stringify(updatedPaymentMethod),
    }).then(() => {
      history.push(`/checkout/${orderId}`);
    });
  };

  return (
    <>
      <form className="paymentForm">
        <h2 className="paymentForm__title">Payment</h2>
        <Container>
          <Row>
            <Col>
              <InputText
                label={'Card number'}
                onChange={updateCardNumber}
                placeholder={'Card number'}
                value={cardNumber}
              />
            </Col>
            <Col>
              <InputText
                label={'Expiration Month'}
                onChange={updateExpirationMonth}
                placeholder={'MM'}
                value={expirationMonth}
              />
            </Col>
            <Col>
              <InputText
                label={'Expiration Year'}
                onChange={updateExpirationYear}
                placeholder={'YY'}
                value={expirationYear}
              />
            </Col>
            <Col>
              <InputText
                label={'CVV'}
                onChange={updateCvv}
                placeholder={'CVV'}
                value={cvv}
              />
            </Col>
          </Row>
        </Container>
      </form>
      <Button
        type="submit"
        className="btn__btn-primary"
        onClick={paymentMethodUpdateButton}
      >
        Confirm Payment Method
      </Button>
    </>
  );
};
