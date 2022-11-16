import React from 'react';
import { Button } from 'react-bootstrap';
import { signIn } from '../../utils/auth';
import logo from './LoreStoreLogo.png';
import './Login.css';

export default function Login() {
  return (
    <div className="container login-container" style={{ textAlign: "center" }}>
      <div className="logo">
        <img src={logo} alt="" />
      </div>
      <div>
        <Button variant="outline-dark" onClick={signIn}>Enter</Button>
      </div>
    </div>
   
  );
}