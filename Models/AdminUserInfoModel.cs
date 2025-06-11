namespace HotelManagementSystem_Web.Models
{
    public class AdminUserInfoModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class GetAllUserInfoResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<AdminUserInfoModel> Data { get; set; }
    }
}
