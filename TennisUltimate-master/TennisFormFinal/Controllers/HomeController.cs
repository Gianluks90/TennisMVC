using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TennisFormFinal.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TennisFormFinal.Controllers
{
    public class HomeController : Controller
    {
        
        private ITSRepository repository;

        public HomeController(ITSRepository repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ReservationForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ReservationForm(TennisReservation reservation)
        {
            if (ModelState.IsValid)
            {
                repository.AddReservation(reservation);
                return View("BellaStoria");
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        [HttpGet]
        public ViewResult DisplayList()
        {
           
            return View(new TennisReservationViewModel { reservations = repository.Reservations });
        }
        [HttpPost]
        public ViewResult DisplayList(TennisReservationViewModel model)
        {
                IEnumerable<TennisReservation> filtered = repository.Reservations;

                if (!String.IsNullOrEmpty(model.PageInfo.FilterField))
                {
                    filtered = filtered.Where(r => r.Court.Name == model.PageInfo.FilterField);
                }
                if(model.PageInfo.FilterDate != null && model.PageInfo.FilterDate.Year!=1)
                {
                    filtered = filtered.Where(r => r.ReservationTime.ToShortDateString() == model.PageInfo.FilterDate.ToShortDateString());
                }
                return View(new TennisReservationViewModel { reservations = filtered });
        }

        //public ViewResult Delete(int id)
        //{
        //    repository.Delete(repository.Reservations.ToList()[id-1]);

        //    return View("DisplayList",new TennisReservationViewModel() { reservations=repository.Reservations});
        //}

    }
}
