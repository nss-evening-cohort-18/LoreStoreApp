import React, { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';
import { useHistory, useParams } from 'react-router-dom/cjs/react-router-dom.min';
import OrderDetailBookInfo from '../../components/myOrderDetails/OrderDetailBookInfo';
import './OrderDetails.css';

function OrderDetails({ user }) {
  const [orderDetails, setOrderDetails] = useState([]);
  const [orderTotal, setOrderTotal] = useState(0);
  const { orderId } = useParams();
  const history = useHistory();

  useEffect(
    () => {
        fetch(`https://localhost:7294/api/OrderDetail/OrderId/${orderId}`, {
            headers: {
              'Content-Type': 'application/json',
              Authorization: `Bearer ${user.Aa}`,
            },
          })
          .then((res) => res.json())
          .then(
            (data) => { 
                setOrderDetails(data); 
                let total = 0;
                for (const item of data) {
                    const itemTotal = item.quantity * item.unitPrice
                    total += itemTotal;
                }
                setOrderTotal(total);
            }
          );
    }, [])

  return (
    <div className='content'>
        <div className="orderInformation">
            <h1 className="orderTitle">Order Number: {orderId}</h1> 
            <div className="shippingAndPayment">
                <div>
                    <h3>Shipping Information</h3>
                    <p>{user.address1}</p>
                    <p>{user.address2}</p>
                    <p>{user.city}</p>
                    <p>{user.state}</p>
                    <p>{user.zip}</p>
                </div>
                <div>
                    <h3>Payment Details</h3>
                    <p>{orderDetails.paymentMethodId}</p>
                </div>
            </div>
        </div>
        <Table>
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Details</th>
                </tr>
            </thead>
            <tbody>
                {
                    orderDetails.map((detail => {
                        return (
                            <tr key={detail.id}>
                                <OrderDetailBookInfo bookId={detail.bookId} order={detail} />
                            </tr>
                        );
                    }))
                }
                <tr>
                    <td><b>Total: ${orderTotal}</b></td>
                </tr>
            </tbody>
        </Table>
        <button className="goBack" onClick={() => { history.push("/myOrders"); }}>Go back</button>     
    </div>
  )
}

export default OrderDetails;
