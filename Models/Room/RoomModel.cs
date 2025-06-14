namespace HotelManagementSystem_Web.Models.Room;

public class RoomModel
{
    public Guid roomId { get; set; }
    public string roomNo { get; set; }
    public bool roomStatus  { get; set; }
    public int guestlimit { get; set; }
    public Guid roomTypeId { get; set; }
    public bool isFeatured  { get; set; }
}