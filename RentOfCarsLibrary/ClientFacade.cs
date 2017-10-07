using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfCarsLibrary
{
    public class ClientFacade
    {
        Administrator _administrator;

        public ClientFacade(Administrator administrator)
        {
            _administrator = administrator;
        }

        public string[,] ShowFreeCarsInTheseDates(DateTime beginningDate, DateTime finishingDate)
        {
            string[,] freeCars = _administrator.ShowFreeCarsInTheseDates(beginningDate, finishingDate);
            return freeCars;
        }

        public void RentCar(string clientName, int identificationNumberOfCar, DateTime beginningDate, DateTime finishingDate)
        {
            if (_administrator.isPossibleRentCar(clientName, identificationNumberOfCar))
            {
                _administrator.RentCar(clientName, identificationNumberOfCar, beginningDate, finishingDate);
            }
        }
    }
}
