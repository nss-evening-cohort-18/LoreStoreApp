import React, { useState, useEffect } from 'react';
import './Cart.css';
import CartView from './views/cartView/CartView';
import NoItems from './views/noItems/NoItems';

const Cart = ({ user }) => {
  const [order, setOrder] = useState({});
  const [orderItems, setOrderItems] = useState([]);

  const getActiveOrder = async (uid, token) => {
    const res = await fetch(`https://localhost:7294/api/Order/UserId/${uid}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    });
    const res1 = await res.json();
    return res1.find((order) => !order.isComplete);
  };

  const getOrderItems = async (orderId, token) => {
    const res = await fetch(
      `https://localhost:7294/api/OrderDetail/OrderId/${orderId}`,
      {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
      },
    );
    if (res.status !== 200) {
      return [];
    }
    const res1 = await res.json();
    return res1;
  };

  useEffect(() => {
    const setActiveOrder = async () => {
      const activeOrder = await getActiveOrder(1, user.Aa);
      const orderItems = await getOrderItems(activeOrder.id , user.Aa);
      setOrder(activeOrder);
      setOrderItems(orderItems);
    };
    setActiveOrder().catch(console.error);
  }, [user]);

  return (
    <div className='container'>
      <h1>Shopping Cart</h1>
      {orderItems.length > 0 ? <CartView orderItems={orderItems} setOrderItems={setOrderItems} order={order} user={user} /> : <NoItems />}
    </div>
  );
};

export default Cart;
