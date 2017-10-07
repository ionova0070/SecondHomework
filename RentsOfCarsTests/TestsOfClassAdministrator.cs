using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentOfCarsLibrary;

namespace RentsOfCarsTests
{
    [TestClass]
    public class TestsOfClassAdministrator
    {
        [TestMethod]
        public void ShowAllCars_ReturnRightResult()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Opel", "Black", 1);
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);
            administrator.AddNewCar("Audi", "Black", 4);
            string[,] expectedMassive = {{"Opel", "Black", "1"}, 
                                 {"Ford", "White", "2"}, 
                                 {"Ford", "Blue", "3"},
                                 {"Audi", "Black", "4"}};
            string[,] actualMassive = administrator.ShowAllCars();
            bool expected = true;
            bool actual = true;

            for (int i = 0; i < expectedMassive.GetLength(0); i++)
            {
                for (int j=0; j<expectedMassive.GetLength(1); j++)
                {
                    actual = actual && String.Equals(expectedMassive[i, j], actualMassive[i, j]);
                }
            }
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowFreeCar_AllCarsFree_ReturnAllCars()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Opel", "Black", 1);
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);
            administrator.AddNewCar("Audi", "Black", 4);
            string[,] expectedMassive = {{"Opel", "Black", "1"}, 
                                 {"Ford", "White", "2"}, 
                                 {"Ford", "Blue", "3"},
                                 {"Audi", "Black", "4"}};

            string[,] actualMassive = administrator.ShowFreeCarsInTheseDates(new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));

            bool expected = true;
            bool actual = true;

            for (int i = 0; i < expectedMassive.GetLength(0); i++)
            {
                for (int j = 0; j < expectedMassive.GetLength(1); j++)
                {
                    actual = actual && String.Equals(expectedMassive[i, j], actualMassive[i, j]);
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowFreeCar_TwoCarsFree_ReturnTwoCars()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Opel", "Black", 1);
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);
            administrator.AddNewCar("Audi", "Black", 4);

            administrator.RentCar("", 2, new DateTime(2017, 10, 8), new DateTime(2017, 10, 9));
            administrator.RentCar("", 3, new DateTime(2017, 10, 7), new DateTime(2017, 10, 9));
            string[,] expectedMassive = {{"Opel", "Black", "1"},
                                 {"Audi", "Black", "4"}};

            string[,] actualMassive = administrator.ShowFreeCarsInTheseDates(new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));

            bool expected = true;
            bool actual = true;

            for (int i = 0; i < expectedMassive.GetLength(0); i++)
            {
                for (int j = 0; j < expectedMassive.GetLength(1); j++)
                {
                    actual = actual && String.Equals(expectedMassive[i, j], actualMassive[i, j]);
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShowFreeCar_NoCarsFree_ReturnEmptyMassive()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);

            administrator.RentCar("", 2, new DateTime(2017, 10, 8), new DateTime(2017, 10, 9));
            administrator.RentCar("", 3, new DateTime(2017, 10, 7), new DateTime(2017, 10, 9));
            string[,] expectedMassive = { };

            string[,] actualMassive = administrator.ShowFreeCarsInTheseDates(new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));

            bool expected = true;
            bool actual = true;

            for (int i = 0; i < expectedMassive.GetLength(0); i++)
            {
                for (int j = 0; j < expectedMassive.GetLength(1); j++)
                {
                    actual = actual && String.Equals(expectedMassive[i, j], actualMassive[i, j]);
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPossibleRentCar_GetRightRecords_ReturnTrue()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);
            bool expected = true;

            bool actual = administrator.isPossibleRentCar("Client", 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPossibleRentCar_GetClientWithRent_ReturnFalse()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);
            administrator.RentCar("Client", 3, new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));
            bool expected = false;

            bool actual = administrator.isPossibleRentCar("Client", 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPossibleRentCar_GetNotFreeCar_ReturnFalse()
        {
            Administrator administrator = new Administrator();
            administrator.AddNewCar("Ford", "White", 2);
            administrator.AddNewCar("Ford", "Blue", 3);
            administrator.RentCar("Client", 3, new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));
            bool expected = false;

            bool actual = administrator.isPossibleRentCar("Client2", 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
