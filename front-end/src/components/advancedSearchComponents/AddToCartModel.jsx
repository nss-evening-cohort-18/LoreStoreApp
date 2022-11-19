import React, { useState } from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 800,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

export default function AddToCartModal(props) {
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const selectedBook = props.selectedBook

  

  const handleAddToCart = async (id, price) => {
    fetch(`https://localhost:7294/api/OrderDetail`, {
      method: 'POST',
      headers: {'Content-type': 'application/json'},
      body: JSON.stringify({
            "id": 0,
            "orderId": 1,  //still need to get orderId
            "bookId": id,
            "quantity": 1,
            "unitPrice": price
      }),
    }).then(response => console.log(response.status))
      .catch(err => console.warn(err));
  }


  return (
    <div>
      <Button variant="outlined" style={{ marginTop:'1rem', marginBottom: '1rem' }} onClick={handleOpen}>Add To Cart</Button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        
        <Box sx={style} key={props.id}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
            Confirm Add To Cart
          </Typography>
          {selectedBook.map((props) =>
                    <ul key={props.id}>
                        <li>AUTHOR: {props.authorFirstName} {props.authorLastName}</li>
                        <li>TITLE: {props.title}</li>
                        <li>PRICE: ${props.price}.00</li>
                        <Button onClick={(e) => {handleAddToCart(props.id, props.price); handleClose()}} variant="outlined" style={{float: 'right'}}>Add</Button>
                    </ul>
                    
          )}
        </Box>
      </Modal>
    </div>
  );
}
              
             
        
