// index for router
import React, { useState, useEffect } from 'react';
import { Route, Switch } from 'react-router-dom';
import Header from '../components/header/Header';
import Authenticated from '../pages/Authenticated';
import Profile from '../pages/profile/Profile';

export default function Routes({ user }) {
  const [filter, setFilter] = useState({ genre: null, subGenre: null, searchString: '' });

  useEffect(() => {
    console.log(filter)
  }, [filter])
  
  return (
    <div>
      <Header user={user} setFilter={setFilter} filter={filter} />
      <Switch>
        <Route exact path="/" component={() => <Authenticated user={user} />} />
        <Route path="/profile" component={() => <Profile user={user} />} />
        <Route path="*" component={() => <Authenticated user={user} />} />
      </Switch>
    </div>
  );
}
