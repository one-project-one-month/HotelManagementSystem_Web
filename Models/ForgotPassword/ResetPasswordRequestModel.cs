namespace HotelManagementSystem_Web.Models.ForgotPassword;

public class ResetPasswordRequestModel
{
    public string Email { get; set; }
    public string OTP { get; set; }
    public string password { get; set; }
}