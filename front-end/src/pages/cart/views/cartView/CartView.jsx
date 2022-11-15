import React from 'react';
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min';
import OrderItem from '../../components/orderItem/OrderItem';
import './CartView.css';

const CartView = ({ orderItems, setOrderItems, order, user }) => {
  const history = useHistory();
  const emptyCart = async () => {
    const res = await fetch(`https://localhost:7294/api/OrderDetail/OrderId/${order.id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${user.Aa}`,
      }
    });
    if(res.status === 200){
      setOrderItems([]);
    }
  };

  const continueShopping = () => {
    history.push('/search');
  };

  const updateCart = () => {};

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
            <OrderItem item={item} key={item.id} />
          ))}
        </tbody>
      </table>
      <div className="button-container">
        <div className="left-buttons button-group">
          <button onClick={emptyCart}>Empty Cart</button>
          <button onClick={continueShopping}>Continue Shopping</button>
        </div>
        <div className="right-buttons button-group">
          <button onClick={updateCart} >Update Cart</button>
          <button onClick={checkout}>Checkout</button>
        </div>
      </div>
    </>
  );
};

export default CartView;
