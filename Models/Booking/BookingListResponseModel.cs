namespace HotelManagementSystem_Web.Models.Booking;

public class BookingListResponseModel
{
        public List<BookingModel> Bookings { get; set; }
        public string RespCode { get; set; }
        public string RespDescription { get; set; }
}