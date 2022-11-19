import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom/cjs/react-router-dom.min';
import './MyOrders.css'

function MyOrders({ user }) {
  const [orderList, setOrderList] = useState([]);
  const history = useHistory();

  useEffect(
    () => {
        fetch(`https://localhost:7294/api/Order/UserId/1`, {
            headers: {
              'Content-Type': 'application/json',
              Authorization: `Bearer ${user.Aa}`,
            },
          })
          .then((res) => res.json())
          .then((data) => { setOrderList(data); });
        
    }, [user]
  );
  return (
    <>
        <h1 className="myOrdersTitle">My orders</h1>
        <div className="content">
        <div className="orderList">
            {
                orderList.map((order) => {
                    const [date,] = order.orderDate.split("T");
                    return (
                    <div className="orderItem" key={order.id}>
                        <p><b>Order Number:</b> {order.id}</p>
                        <p><b>Payment Method:</b> {order.paymentMethodId}</p>
                        <p><b>Total:</b> {order.total}</p>
                        <p><b>Date:</b> {date}</p>
                        <button value={order.id} onClick={(e) => {history.push(`myOrders/${e.target.value}`)}}>View Details</button>
                    </div>
                    );
                })
            }
        </div>
        <button onClick={() => { history.push("/profile"); }}>Go back</button>
        </div>
    </>
  );
}

export default MyOrders;
