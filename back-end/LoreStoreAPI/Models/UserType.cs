using System.ComponentModel.DataAnnotations;

namespace LoreStoreAPI.Models
{
    public class UserType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
