import React, {useState, useEffect } from 'react';
import { DataGrid, GridSearchIcon } from '@mui/x-data-grid';
import Box from '@mui/material/Box';
import { Button } from '@mui/material';

export const AdvancedSearch = () => {
    const book_Api_URL = "https://localhost:7294/api/Book";
    const [bookList, setBookList] = useState([]);
    const [selectedRows, setSelectedRows] = useState([]);


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
    {field: 'id', headerName: 'ID Number', width: 100},
    {field: 'title', headerName: 'Title', width: 400},
    {field: 'authorLastName', headerName: 'Author Last Name', width: 130},
    {field: 'authorFirstName', headerName: 'Author First Name', width: 130},
    {field: 'description', headerName: 'Description', width: 300},
    {field: 'isFiction', headerName: 'Fiction/Non Fiction', width: 150},
    {field: 'subGenre', headerName: 'Sub Genre', width: 250},
    {field: 'price', headerName: 'Cost', width: 50},
    {field: "Details",
      renderCell: (cellValues) => {
        return (
          <Button
            variant="contained"
            color="primary"
            onClick={(event) => {
            // handleClick(event, cellValues);
            }}
          >
             View
          </Button>
          );
         }
      }];

   return (
    <Box sx={{ height: 650, width: '80%', marginTop: '1rem', marginLeft: '10%', marginRight: '10%' }}>
      <DataGrid
        rows={bookList}
        columns={columns}
        pageSize={10}
        rowsPerPageOptions={[10]}
        checkboxSelection
        onSelectionModelChange={(ids) => {
          const selectedIDs = new Set(ids);
          const selectedRows = bookList.filter((row) =>
            selectedIDs.has(row.id),
          );

          setSelectedRows(selectedRows);
        }}
        {...bookList}
        components={{
          Toolbar:  GridSearchIcon,
        }}
      />
      <pre style={{ fontSize: 10 }}>
        {JSON.stringify(selectedRows, null, 4)}
      </pre>
    </Box>
  );
}



    

    
