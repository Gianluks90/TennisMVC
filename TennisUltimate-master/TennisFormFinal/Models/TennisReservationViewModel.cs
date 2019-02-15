using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisFormFinal.Models
{
    public class TennisReservationViewModel
    {
        public IEnumerable<TennisReservation> reservations { get; set; }
        public PageInfo PageInfo { get; set; }
       
        public TennisReservationViewModel()
        {
            PageInfo = new PageInfo();
        }




    }

    public class PageInfo
    {
        public string FilterField { get; set; }
        public DateTime FilterDate { get; set; }
    }


}

