@{
    public class Room
        {
    public int RoomId { get; set; }
    public string Room_No { get; set; } = string.Empty;
    public int RoomTypeId { get; set; }
    public string RoomStatus { get; set; } = string.Empty;
    public string Img_URL { get; set; } = string.Empty;
    public int Guest_Limit { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
        }

}