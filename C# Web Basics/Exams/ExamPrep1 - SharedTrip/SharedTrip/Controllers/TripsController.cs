using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private ITripService tripService;
        public TripsController(Request request,
            ITripService _tripService
            ) : base(request)
        {
            tripService = _tripService;
        }

        public Response All() => View();

        [Authorize]
        public Response Add() => View();
        public Response Info() => View();

        [HttpPost]
        [Authorize]
        public Response Add(TripViewModel model)
        {
            var (isValid, errors) = tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            tripService.AddTrip(model);

            return Redirect("/");
        }
    }
}
