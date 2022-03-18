using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;

        public TripService(IRepository _repo)
        {
            repo = _repo;
        }

        public void AddTrip(TripViewModel model)
        {
            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
              // DepartureTime = model.,
                Seats = model.Seats,
                Description = model.Description
            };


            repo.Add<Trip>(trip);
            repo.SaveChanges();
        }
        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripViewModel model)
        {
            var isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.StartPoint == null)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("StartPoint is required"));
            }

            if (model.EndPoint == null)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("EndPoint is required"));
            }

            if (model.DepartureTime == default)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("DepartureTime is not valid"));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats value must be between 2 and 6"));
            }

            if (model.Description == null || model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and must be up to 80 characters"));
            }

            if (model.ImagePath.Length > 2048)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("ImagePath is too long"));
            }        

            return (isValid, errors);
        }
    }
}
