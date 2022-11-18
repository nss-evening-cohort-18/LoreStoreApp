import React, {useState, useEffect } from 'react';
import { DataGrid, GridToolbar } from '@mui/x-data-grid';
import TextField from "@mui/material/TextField";
import BookDetails from '../../components/advancedSearchComponents/BookDetails';
import Box from '@mui/material/Box';
import AddToCartModal from '../../components/advancedSearchComponents/AddToCartModel';

export const AdvancedSearch = () => {
    const book_Api_URL = "https://localhost:7294/api/Book";
    const [bookList, setBookList] = useState([]);
    const [selectedBook, setSelectedBook] = useState([]);

    useEffect(() => {
    fetch(book_Api_URL)
      .then((res) => {
        return res.json();
      })
      .then((data) => {
        setBookList(data);
      });
  }, []);


  const columns = [
    {field: 'title', headerName: 'Title', width: 450},
    {field: 'authorLastName', headerName: 'Last Name', width: 150},
    {field: 'authorFirstName', headerName: 'First Name', width: 150},
    {field: 'isFiction', headerName: 'Fiction/Non Fiction', width: 150},
    {field: 'price', headerName: 'Cost', width: 100},

    ];


    return (
    <>
    <div style={{display: 'flex', flexDirection: 'row'}}>
      <div style={{ width: '100%', marginRight: '1rem', marginLeft: '1rem', marginTop: '1rem'}}>
        <Box sx={{ height: 600}}>
          <DataGrid
            rows={bookList}
            columns={columns}
            pageSize={10}
            rowsPerPageOptions={[10]}
            onSelectionModelChange={(ids) => {
              const selectedIDs = new Set(ids);
              const selectedBook = bookList.filter((row) =>
                selectedIDs.has(row.id),
              );

              setSelectedBook(selectedBook);
            }}
            {...bookList}
            components={{
              Toolbar:  GridToolbar,
                        
            }}
          />
        </Box>
      </div>
      <BookDetails selectedBook={selectedBook} />
    </div> 
    <div style={{float: 'right', marginRight: '1rem', marginBotton: '2rem'}}>
      <AddToCartModal selectedBook={selectedBook} />
    </div>
  </>
  );
}



    

    
