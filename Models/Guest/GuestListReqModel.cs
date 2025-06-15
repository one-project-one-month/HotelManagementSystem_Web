namespace HotelManagementSystem_Web.Models.Guest;

public class GuestListReqModel : BaseResponseModel
{
    public List<GuestReqModel> guestList { get; set; }
}