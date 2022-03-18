using SharedTrip.Data.Common;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        public void AddTrip(TripViewModel model);
        (bool isValid,IEnumerable<ErrorViewModel> errors) ValidateModel(TripViewModel model);
    }
}
