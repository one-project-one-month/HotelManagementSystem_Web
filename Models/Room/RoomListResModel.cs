using HotelManagementSystem_Web.Models.Room.RoomTypeReqModel;

namespace HotelManagementSystem_Web.Models.Room;

public class RoomListResModel : BaseResponseModel
{
    public List<RoomModel> RoomList { get; set; }
}