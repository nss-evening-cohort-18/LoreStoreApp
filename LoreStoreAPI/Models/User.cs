﻿namespace LoreStoreAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }   

        public string Address1 { get; set; }

        public string Address2 { get; set; }    

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public bool IsAdmin  { get; set; }
    }
}
