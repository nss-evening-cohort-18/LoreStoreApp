import React from 'react';
import { Button } from 'react-bootstrap';
import { signIn } from '../../utils/auth';
import logo from './LoreStoreLogo.png';

export default function Login() {
  return (
    <div className="container" style={{ textAlign: "center", height: 600, width: 600 }}>
      <div className="logo">
        <img src={logo} alt="" />
      </div>
      <div>
        <Button variant="outline-dark" onClick={signIn}>Enter</Button>
      </div>
    </div>
   
  );
}