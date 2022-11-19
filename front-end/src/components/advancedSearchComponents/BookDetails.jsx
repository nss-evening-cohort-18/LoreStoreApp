import React from "react";
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import { styled } from '@mui/material/styles';




const BookDetails = (props) => {
    const selectedBook = props.selectedBook

    const Item = styled(Paper)(({ theme }) => ({
        backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
    }));

    
    return (
        <div style={{ width: '100%', marginRight: '1rem', marginLeft: '1rem', marginTop: '1rem', background: 'WhiteSmoke'}}>
          <div style={{ width: '90%', marginRight: '5%', marginLeft: '5%', marginTop: '2rem' }}>
              {selectedBook.map((props) => 

                  <Box key={props.id}>
                        <Stack spacing={2} >
                            <Item><div style={{float: 'left', fontWeight: 'bold' }}>Title:</div>{props.title}</Item>
                            <Item><div style={{float: 'left', fontWeight: 'bold' }}>Author:</div>{props.authorFirstName} {props.authorLastName}</Item>
                            <Item><div style={{float: 'left', fontWeight: 'bold' }}>Description:</div>{props.description}</Item>
                            <Item><div style={{float: 'left', fontWeight: 'bold' }}>Sub Genre:</div>{props.subGenre}</Item>
                            <div style={{ display: 'flex', flexDirection: 'row' }}>
                                <Item style={{ width: '50%' }}><div style={{float: 'left', fontWeight: 'bold' }}>Price:</div>${props.price}.00</Item>
                                <Item style={{ width: '50%' }}><div style={{float: 'left', fontWeight: 'bold' }}>Date Published:</div>{props.datePublished}</Item>
                            </div>
                            <Item><div style={{float: 'left', fontWeight: 'bold' }}>Currently In Stock:</div>{props.inventoryQuantity}</Item>
                        </Stack>
                    </Box>
              )}
          </div>
      </div>
    )
}

export default BookDetails