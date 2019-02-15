

using System;

using System.ComponentModel.DataAnnotations;

namespace TennisFormFinal.Models
{



    public class TennisReservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }

        [DateRange]
        public DateTime ReservationTime { get; set; }
        public String MatchType { get; set; }
    }

    

    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute()
          : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.Now.AddYears(2).ToShortDateString()) { }
    }

}
