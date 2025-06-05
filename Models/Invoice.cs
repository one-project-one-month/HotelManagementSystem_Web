namespace HotelManagementSystem_Web.Models;

public class Invoice
{
    public Guid InvoiceId { get; set; }
    public string InvoiceCode { get; set; } = string.Empty;
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public decimal Deposite { get; set; }
    public decimal? ExtraCharges { get; set; }
    public decimal TotalAmount { get; set; }
    public string? PaymentType { get; set; }
    public GuestInfo? Guest { get; set; }
}

public class GuestInfo
{
    public string Nrc { get; set; } = string.Empty;
    public string PhoneNo { get; set; } = string.Empty;
}