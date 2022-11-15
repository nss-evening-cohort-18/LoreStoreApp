import React, { useState } from 'react';
import UserApi from '../../api/userApi';
import './Profile.css';

function Profile({ user }) {
  const [userFirstName, setFirstName] = useState(user.firstName ? user.firstName : null);
  const [userLastName, setLastName] = useState(user.lastName ? user.lastName : null);
  const [userUsername, setUsername] = useState(user.username ? user.username : null);
  const [userAddress1, setUserAddress1] = useState(user.address1 ? user.address1 : null);
  const [userAddress2, setUserAddress2] = useState(user.address2 ? user.address2 : null);
  const [userState, setUserState] = useState(user.state ? user.state : null);
  const [userCity, setUserCity] = useState(user.city ? user.city : null);
  const [userZip, setUserZip] = useState(user.zip ? user.zip : null);
  const [editsMade, setEditsMade] = useState(false);
  const submitEdits = () => {
    const updatedUser = {
      firebaseUserId: user.firebaseUserId,
      email: user.email,
      firstName: userFirstName,
      lastName: userLastName,
      username: userUsername,
      address1: userAddress1,
      address2: userAddress2,
      city: userCity,
      state: userState,
      zip: userZip,
      userTypeId: user.userTypeId,
      userType: {
        name: user.userType.name,
      },
    };
    UserApi.UpdateUser(user.id, updatedUser, user.Aa)
      .then(() => { setEditsMade(false); window.location.reload(); });
  };
  let dateFormat = 'Member since ';
  dateFormat += new Date(user.metadata.creationTime).toDateString();

  return (
    <>
      <div className="content">
        <div className="nameImage">
          <img
            referrerPolicy="no-referrer"
            src={user.photoURL}
            alt={user.displayName}
          />
          <p>Name</p>
          <input className="profileInput" onChange={(e) => { setFirstName(e.target.value); setEditsMade(true); }} value={userFirstName == null ? '' : userFirstName} placeholder={user.firstName ? user.firstName : 'First Name (Type to edit)'} />
          <input className="profileInput" onChange={(e) => { setLastName(e.target.value); setEditsMade(true); }} value={userLastName == null ? '' : userLastName} placeholder={user.lastName ? user.lastName : 'Last Name (Type to edit)'} />
        </div>
        <div className="details">
          <p>Username</p>
          <input className="profileInput" onChange={(e) => { setUsername(e.target.value); setEditsMade(true); }} value={userUsername == null ? '' : userUsername} placeholder={user.username ? user.username : 'Username (Type to edit)'} />
          <input className="profileInput" disabled value={user.email} />
          <input className="profileInput" disabled value={dateFormat} />
          <p>Shipping Address</p>
          <div className="address">
            <input className="profileInput" onChange={(e) => { setUserAddress1(e.target.value); setEditsMade(true); }} value={userAddress1 == null ? '' : userAddress1} placeholder={user.address1 ? user.address1 : 'Address 1 (Type to edit)'} />
            <input className="profileInput" onChange={(e) => { setUserAddress2(e.target.value); setEditsMade(true); }} value={userAddress2 == null ? '' : userAddress2} placeholder={user.address2 ? user.address2 : 'Address 2 (Type to edit)'} />
            <input className="profileInput" onChange={(e) => { setUserCity(e.target.value); setEditsMade(true); }} value={userCity == null ? '' : userCity} placeholder={user.city ? user.city : 'City (Type to edit)'} />
            <input className="profileInput" onChange={(e) => { setUserState(e.target.value); setEditsMade(true); }} value={userState == null ? '' : userState} placeholder={user.state ? user.state : 'State (Type to edit)'} />
            <input className="profileInput" onChange={(e) => { setUserZip(e.target.value); setEditsMade(true); }} value={userZip == null ? '' : userZip} placeholder={user.zip ? user.zip : 'Zip (Type to edit)'} />
          </div>
          <a className="myOrderLink" href="/my-orders" value={user.id}>View My Orders</a>
          <a className="myPaymentLink" href="/my-payment" value={user.id}>View My Payment Method</a>
        </div>
      </div>
      <button className={editsMade ? 'editsButtonShow' : 'editsButtonHide'} type="submit" onClick={() => { submitEdits(); }}>Submit Edits</button>
    </>
  );
}

export default Profile;
