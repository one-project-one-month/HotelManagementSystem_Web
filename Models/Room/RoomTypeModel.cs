namespace HotelManagementSystem_Web.Models.Room
{
    public class RoomTypeModel
    {
        public string RoomTypeName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? RoomImg { get; set; }

        public string? RoomImgMimeType { get; set; }
    }
}
