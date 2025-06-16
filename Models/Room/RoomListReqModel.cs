using HotelManagementSystem_Web.Models.Room.RoomTypeReqModel;

namespace HotelManagementSystem_Web.Models.Room;

public class RoomListReqModel : BaseResponseModel
{
    public List<RoomReqModel> GetRoomList { get; set; }
}