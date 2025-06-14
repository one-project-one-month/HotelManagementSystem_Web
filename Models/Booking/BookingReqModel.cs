using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem_Web.Models.Booking
{
    public class BookingReqModel
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Nrc { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;
        public List<Guid> Rooms { get; set; } = new();

        public int? GuestCount { get; set; }

        public DateOnly? CheckInTime { get; set; }

        public DateOnly? CheckOutTime { get; set; }

        public decimal? DepositAmount { get; set; }

        public string? BookingStatus { get; set; }

        public decimal? TotalAmount { get; set; }
        public string? PaymentType { get; set; }
    }
}