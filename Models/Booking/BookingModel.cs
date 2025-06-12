namespace HotelManagementSystem_Web.Models.Booking;

public class BookingModel
{
    public string? UserName { get; set; }
    public string? GuestNamme { get; set; } 
    public string GuestNrc { get; set; } = null!;

    public string GuestPhoneNo { get; set; } = null!;
    
    public List<string> RoomNo { get; set; } = new();
    public int? GuestCount { get; set; }
    public DateOnly? CheckIn_Time { get; set; }

    public DateOnly? CheckOut_Time { get; set; }

    public decimal? Deposit_Amount { get; set; }

    public string? BookingStatus { get; set; }

    public decimal? TotalAmount { get; set; }
    public string? PaymentType { get; set; }

    public Guid BookingId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? GuestId { get; set; }   

    public DateTime? CreatedAt { get; set; }
        
}