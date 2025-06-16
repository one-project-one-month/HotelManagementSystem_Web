using HotelManagementSystem_Web.Models.Room.RoomTypeReqModel;

namespace HotelManagementSystem_Web.Models.Room;

public class RoomTypeListResModel : BaseResponseModel
{
    public List<RoomTypeModel> RoomTypeList { get; set; } = null!;
  
}