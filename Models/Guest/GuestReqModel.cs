using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem_Web.Models.Guest
{
    public class GuestReqModel
    {
        public Guid GuestId { get; set; }

        public Guid? UserId { get; set; }

        public string Nrc { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public string Name { get; set; } = null!;

        public string? Email { get; set; }
    }
}