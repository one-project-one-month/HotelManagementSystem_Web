using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem_Web.Models.Room.RoomTypeReqModel
{
    public class RoomReqModel
    {
        public string? RoomNo { get; set; }

        public string? RoomStatus { get; set; }

        public int? GuestLimit { get; set; }

        public Guid RoomTypeId { get; set; }

        public bool IsFeatured { get; set; }
    }
    
}
