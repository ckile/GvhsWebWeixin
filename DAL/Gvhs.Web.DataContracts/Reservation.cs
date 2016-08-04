using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gvhs.Web.DataContracts
{
    public class EReservation : IEntity
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string ReservationCode { get; set; }

        public int Status { get; set; }

        public bool PaymentFlag { get; set; }

        public int GuestId { get; set; }

        public EGuest Guest { get; set; }

        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime Arrival { get; set; }

        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime Departure { get; set; }

        public int Adult { get; set; }

        public decimal Rate { get; set; }

        public int RoomTypeId { get; set; }

        public ERoomType RoomType { get; set; }

        public string RoomCode { get; set; }

        public string Remark { get; set; }
        
    }
}
