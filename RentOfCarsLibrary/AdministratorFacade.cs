using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfCarsLibrary
{
    public class AdministratorFacade
    {
        Administrator _administrator;
        public AdministratorFacade()
        {
            _administrator = new Administrator();
        }

        public string[,] ShowAllCars()
        {
            string[,] allCars = _administrator.ShowAllCars();
            return allCars;
        }

        public void AddNewCar(string model, string colour, int identificationNumber)
        {
            _administrator.AddNewCar(model, colour, identificationNumber);
        }
    }
}
