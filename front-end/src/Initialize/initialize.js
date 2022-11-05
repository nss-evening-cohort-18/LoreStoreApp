import React from 'react';
import Loading from '../components/Loading';
import Login from '../pages/login/Login';
import Routes from '../routes/routes';
import { useAuth } from '../utils/context/authContext';

function Initialize() {
  const { user, userLoading } = useAuth();

  // if user state is null, then show loader
  if (userLoading) {
    return <Loading />;
  }

  return <>{user ? <Routes user={user} /> : <Login />}</>;
}

export default Initialize;
