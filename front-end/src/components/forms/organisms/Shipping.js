import React, { useEffect, useState } from 'react';
import {
  useParams,
  useHistory,
} from 'react-router-dom/cjs/react-router-dom.min';
import { Container, Row, Col } from 'react-bootstrap';
import { Button } from 'bootstrap';
import './Shipping.css';
import { InputText } from '../atoms/InputText';
import UserApi from '../../../api/userApi';

export const Shipping = ({ user }) => {
  const { orderId } = useParams(); //variable storing the route parameter
  const [firstName, updateFirstName] = useState('');
  const [lastName, updateLastName] = useState('');
  const [userUsername, setUsername] = useState(
    user.username ? user.username : null,
  );
  const [streetAddress1, updateStreetAddress1] = useState('');
  const [streetAddress2, updateStreetAddress2] = useState('');
  const [city, updateCity] = useState('');
  const [state, updateState] = useState('');
  const [zip, updateZip] = useState('');

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
        updateFirstName(orderViewModel.firstName);
        updateLastName(orderViewModel.lastName);
        updateStreetAddress1(orderViewModel.address1);
        updateStreetAddress2(orderViewModel.address2);
        updateCity(orderViewModel.city);
        updateState(orderViewModel.state);
        updateZip(orderViewModel.zip);
      });
  }, []);

  const shippingUpdateButton = (evt) => {
    evt.preventDefault();
    //construct a new object to replace the existing one in the API
    const updatedUser = {
      firebaseUserId: user.firebaseUserId,
      email: user.email,
      firstName: firstName,
      lastName: lastName,
      username: userUsername,
      address1: streetAddress1,
      address2: streetAddress1,
      city: city,
      state: state,
      zip: zip,
      userTypeId: user.userTypeId,
      userType: {
        name: user.userType.name,
      },
    };
    //Perform the PUT request to replace the user
    UserApi.UpdateUser(user.id, updatedUser, user.Aa).then(() => {
      history.push(`/checkout/${orderId}`);
    });
  };

  return (
    <>
      <form className="shippingForm">
        <h2 className="shippingForm__title">Shipping</h2>
        <Container>
          <Row>
            <Col>
              <InputText
                label={'First Name'}
                onChange={updateFirstName}
                placeholder={'John'}
                value={firstName}
              />
            </Col>
            <Col>
              <InputText
                label={'Last Name'}
                onChange={updateLastName}
                placeholder={'Smith'}
                value={lastName}
              />
            </Col>
          </Row>
          <Row>
            <Col>
              <InputText
                label={'Street Address 1'}
                onChange={updateStreetAddress1}
                placeholder={'Street Address 1'}
                value={streetAddress1}
              />
            </Col>
          </Row>
          <Row>
            <Col>
              <InputText
                label={'Street Address 2'}
                onChange={updateStreetAddress2}
                placeholder={'Company, C/O, Apt, Suite, Unit'}
                value={streetAddress2}
              />
            </Col>
          </Row>
          <Row>
            <Col>
              <InputText
                label={'City'}
                onChange={updateCity}
                placeholder={'City'}
                value={city}
              />
            </Col>
            <Col>
              <InputText
                label={'State'}
                onChange={updateState}
                placeholder={'State'}
                value={state}
              />
            </Col>
            <Col>
              <InputText
                label={'Zipcode'}
                onChange={updateZip}
                placeholder={'Zipcode'}
                value={zip}
              />
            </Col>
          </Row>
        </Container>
      </form>
      <Button
        type="submit"
        className="btn__btn-primary"
        onClick={shippingUpdateButton}
      >
        Save and Continue
      </Button>
    </>
  );
};
