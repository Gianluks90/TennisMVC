using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisFormFinal.Models
{
    public class Repository:ITSRepository
    {
        private TRDBContext context;
        public Repository(TRDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<TennisReservation> Reservations => context.TReservations;

        public void AddReservation(TennisReservation reservation)
        {
            context.TReservations.Add(reservation);
            context.SaveChanges();
        }

        public void Delete(TennisReservation reservation)
        {
            context.TReservations.Remove(reservation);
            context.SaveChanges();
        }
    }
}
