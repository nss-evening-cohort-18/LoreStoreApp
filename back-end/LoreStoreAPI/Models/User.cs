using System.ComponentModel.DataAnnotations;

namespace LoreStoreAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(28, MinimumLength = 28)]
        public string FirebaseUserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(28)]
        public string? FirstName { get; set; }

        [MaxLength(28)]
        public string? LastName { get; set; }

        public string? Username { get; set; }   

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }    

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }
    }
}
