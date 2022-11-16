import React from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min';
import OrderItem from '../../components/orderItem/OrderItem';
import './CartView.css';

const CartView = ({ orderItems, setOrderItems, order, user }) => {
  const [updatedCart, setUpdatedCart] = useState([]);
  const [total, setTotal] = useState(0);
  const history = useHistory();

  useEffect(() => {
    let price = 0;
    orderItems.forEach((item) => {
      price += item.quantity * item.unitPrice;
    });
    setTotal(price.toFixed(2));
  }, [orderItems, updatedCart]);

  const emptyCart = async () => {
    const res = await fetch(
      `https://localhost:7294/api/OrderDetail/OrderId/${order.id}`,
      {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${user.Aa}`,
        },
      },
    );
    if (res.status === 200) {
      setOrderItems([]);
    }
  };

  const continueShopping = () => {
    history.push('/search');
  };

  const updateCart = async () => {
    if (updatedCart.length > 0) {
      await Promise.all(
        updatedCart.map(async (cartItem) => {
          await fetch(`https://localhost:7294/api/OrderDetail/${cartItem.id}`, {
            method: 'PUT',
            headers: {
              'Content-Type': 'application/json',
              Authorization: `Bearer ${user.Aa}`,
            },
            body: JSON.stringify(cartItem),
          });
        }),
      );

      const updatedState = [...orderItems];
      updatedCart.forEach(item => {
        updatedState.forEach((item2, index) => {
          if(item.id === item2.id) {
            updatedState[index].quantity = item.quantity;
          }
        })
      })
      setOrderItems(updatedState);

      setUpdatedCart([]);
    }
  };

  const checkout = () => {
    history.push('/checkout');
  };

  return (
    <>
      <table>
        <colgroup>
          <col style={{ width: '70%' }} />
          <col style={{ width: '10%' }} />
          <col style={{ width: '10%' }} />
          <col style={{ width: '10%' }} />
        </colgroup>
        <thead>
          <tr>
            <th>Item</th>
            <th>Qty</th>
            <th>Price</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {orderItems.map((item) => (
            <OrderItem
              item={item}
              key={item.id}
              setOrderItems={setOrderItems}
              setUpdatedCart={setUpdatedCart}
              user={user}
            />
          ))}
        </tbody>
      </table>
      <div className="button-container">
        <div className="left-buttons button-group">
          <button onClick={emptyCart}>Empty Cart</button>
          <button onClick={continueShopping}>Continue Shopping</button>
        </div>
        <div className="right-buttons button-group">
          <button onClick={updateCart}>Update Cart</button>
          <button onClick={checkout}>Checkout</button>
          <p>${total}</p>
        </div>
      </div>
    </>
  );
};

export default CartView;
