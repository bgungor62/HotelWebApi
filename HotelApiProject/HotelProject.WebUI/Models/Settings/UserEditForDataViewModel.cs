namespace HotelProject.WebUI.Models.Settings
{
    public class UserEditForDataViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
