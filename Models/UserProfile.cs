namespace HotelManagementSystem_Web.Models
{   
    public class UserProfile
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }       
        public string? Password { get; set; }      
        public string? ProfileImg { get; set; }      
        public string? ProfileImgMimeType { get; set; }
        public Gender Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string Address { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
