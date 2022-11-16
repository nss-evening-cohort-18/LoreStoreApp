import React, { useEffect, useState } from 'react';
import {
  useParams,
  useHistory,
} from 'react-router-dom/cjs/react-router-dom.min';
import { Container, Row, Col } from 'react-bootstrap';
import { Button } from 'bootstrap';
import './Shipping.css';
import { InputText } from '../atoms/InputText';

export const Shipping = () => {

    
  //Fetch User

  const userUpdateButton = (evt) => {
    evt.prevendDefault();
    //construct a new object to replace the existing one in the API
    const updatedUser = {};
    //Perform the PUT request to replace the user
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
                onChange={updateZipCode}
                placeholder={'Zipcode'}
                value={zipcode}
              />
            </Col>
          </Row>
        </Container>
      </form>
      <Button
        type="submit"
        className="btn__btn-primary"
        onClick={userUpdateButton}
      >
        Save and Continue
      </Button>
    </>
  );
};
