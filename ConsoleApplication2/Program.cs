using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentOfCarsLibrary;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            AdministratorFacade admin = new AdministratorFacade(@"C:\", @"C:\");
            admin.AddNewCar("Opel", "Black", 1);
            admin.AddNewCar("Ford", "White", 2);
            ClientFacade client = new ClientFacade();
            client.RentCar("Alena", 1, new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));
            client.RentCar("Ivan", 1, new DateTime(2017, 10, 12), new DateTime(2017, 10, 20));
            client.RentCar("Lena", 2, new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));
            admin.SaveRecords();
        }
    }
}
