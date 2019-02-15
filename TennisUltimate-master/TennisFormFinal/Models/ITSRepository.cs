using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisFormFinal.Models
{
    public interface ITSRepository
    {
        IQueryable<TennisReservation> Reservations { get; }
        void AddReservation(TennisReservation reservation);
        void Delete(TennisReservation reservation);
    }

}
