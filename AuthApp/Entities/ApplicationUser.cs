using System.ComponentModel.DataAnnotations;

namespace AuthApp.Entities
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}