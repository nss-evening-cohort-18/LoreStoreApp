const OrderApi = {
    GetOrdersByUser: (uid, token) => {
    fetch(`https://localhost:7294/api/Order/UserId/${uid}`, {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => res.json())
      .then(
        (data) => {
            console.log(data);
            return data;
        });
    }  
};
  export default OrderApi;
  
  