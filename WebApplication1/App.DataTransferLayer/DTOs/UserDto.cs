namespace WebApplication1.App.DataTransferLayer.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public  string FirstName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
