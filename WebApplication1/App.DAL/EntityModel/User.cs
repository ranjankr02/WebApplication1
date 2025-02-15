namespace WebApplication1.App.DAL.EntityModel
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }

        [MaxLength(100)]
        public string? Firstname { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [MaxLength(100)]
        public string? Gender { get; set; }
    }

}
