// index for router
import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Authenticated from '../pages/Authenticated';
import { BookDetail } from '../pages/bookDetail/BookDetail';

export default function Routes({ user }) {
  return (
    <div>
      <Switch>
        <Route exact path="/" component={() => <Authenticated user={user} />} />
        <Route path="/bookdetails" component={() => <BookDetail />} />
        <Route path="*" component={() => <Authenticated user={user} />} />
      </Switch>
    </div>
  );
}
