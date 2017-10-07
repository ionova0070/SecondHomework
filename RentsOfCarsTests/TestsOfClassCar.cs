using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentOfCarsLibrary;

namespace RentsOfCarsTests
{
    [TestClass]
    public class TestsOfClassCar
    {
        struct Data
        {
            public DateTime BeginningDate;
            public DateTime FinishingDate;
            public bool IsRent;
            public Data(DateTime beginningDate, DateTime finishingDate, bool isRent)
            {
                BeginningDate = beginningDate;
                FinishingDate = finishingDate;
                IsRent = isRent;
            }
        }

        [TestMethod]
        public void IsFreeTheseDates_GetFreeDates_ReturnTrue()
        {
            Car testingCar = new Car("", "", 0);
            testingCar.AddRent(new DateTime(2017, 10, 7), new DateTime(2017, 10, 13));
            testingCar.AddRent(new DateTime(2017, 11, 8), new DateTime(2017, 11, 10));
            testingCar.AddRent(new DateTime(2017, 11, 17), new DateTime(2017, 11, 23));
            testingCar.AddRent(new DateTime(2017, 11, 24), new DateTime(2017, 11, 25));
            testingCar.AddRent(new DateTime(2017, 11, 30), new DateTime(2017, 12, 1));
            DateTime beginningDate = new DateTime(2017, 12, 2);
            DateTime finishingDate = new DateTime(2017, 12, 22);
            bool expected = true;

            bool actual = testingCar.IsFreeTheseDates(beginningDate, finishingDate);

            Assert.AreEqual(expected, actual);            
        }

        [TestMethod]
        public void IsFreeTheseDates_GetWrongDates_ReturnFalse()
        {
            Car testingCar = new Car("", "", 0);
            testingCar.AddRent(new DateTime(2017, 10, 7), new DateTime(2017, 10, 13));
            testingCar.AddRent(new DateTime(2017, 11, 8), new DateTime(2017, 11, 10));
            testingCar.AddRent(new DateTime(2017, 11, 17), new DateTime(2017, 11, 23));
            testingCar.AddRent(new DateTime(2017, 11, 24), new DateTime(2017, 11, 25));
            testingCar.AddRent(new DateTime(2017, 11, 30), new DateTime(2017, 12, 1));
            DateTime beginningDate = new DateTime(2017, 10, 8);
            DateTime finishingDate = new DateTime(2017, 12, 22);
            bool expected = false;

            bool actual = testingCar.IsFreeTheseDates(beginningDate, finishingDate);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFreeTheseDates_RecordsAreEmpty_ReturnTrue()
        {
            Car testingCar = new Car("", "", 0);
            bool expected = true;

            bool actual = testingCar.IsFreeTheseDates(new DateTime(2017, 10, 7), new DateTime(2017, 10, 10));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRentTens_GetOrder_ReturnFalse_IfTheseDatesOfCheckOutFree()
        {
            Car testingCar = new Car("", "", 0);
            testingCar.AddRent(new DateTime(2017, 10, 7), new DateTime(2017, 10, 13));
            testingCar.AddRent(new DateTime(2017, 11, 8), new DateTime(2017, 11, 10));
            testingCar.AddRent(new DateTime(2017, 11, 17), new DateTime(2017, 11, 23));
            testingCar.AddRent(new DateTime(2017, 11, 24), new DateTime(2017, 11, 25));
            testingCar.AddRent(new DateTime(2017, 11, 30), new DateTime(2017, 12, 1));
            testingCar.AddRent(new DateTime(2018, 1, 7), new DateTime(2018, 1, 13));
            testingCar.AddRent(new DateTime(2018, 1, 8), new DateTime(2018, 1, 10));
            testingCar.AddRent(new DateTime(2018, 1, 17), new DateTime(2018, 1, 23));
            testingCar.AddRent(new DateTime(2018, 2, 24), new DateTime(2018, 2, 25));
            testingCar.AddRent(new DateTime(2018, 3, 30), new DateTime(2018, 4, 1));
            bool expected = false;

            bool actual = testingCar.IsFreeTheseDates(new DateTime(2018, 4, 3), new DateTime(2018, 4, 8));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRentTens_GetOrder_ReturnTrue_IfDatesAfterCheckOutFree()
        {
            Car testingCar = new Car("", "", 0);
            testingCar.AddRent(new DateTime(2017, 10, 7), new DateTime(2017, 10, 13));
            testingCar.AddRent(new DateTime(2017, 11, 8), new DateTime(2017, 11, 10));
            testingCar.AddRent(new DateTime(2017, 11, 17), new DateTime(2017, 11, 23));
            testingCar.AddRent(new DateTime(2017, 11, 24), new DateTime(2017, 11, 25));
            testingCar.AddRent(new DateTime(2017, 11, 30), new DateTime(2017, 12, 1));
            testingCar.AddRent(new DateTime(2018, 1, 7), new DateTime(2018, 1, 13));
            testingCar.AddRent(new DateTime(2018, 1, 8), new DateTime(2018, 1, 10));
            testingCar.AddRent(new DateTime(2018, 1, 17), new DateTime(2018, 1, 23));
            testingCar.AddRent(new DateTime(2018, 2, 24), new DateTime(2018, 2, 25));
            testingCar.AddRent(new DateTime(2018, 3, 30), new DateTime(2018, 4, 1));
            bool expected = true;

            bool actual = testingCar.IsFreeTheseDates(new DateTime(2019, 4, 12), new DateTime(2019, 4, 21));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTwentyTwoRent_GetOrder_ReturnTrue_IfDatesAfterSecondCheckOutFree()
        {
            Car testingCar = new Car("", "", 0);
            testingCar.AddRent(new DateTime(2017, 10, 7), new DateTime(2017, 10, 13));
            testingCar.AddRent(new DateTime(2017, 11, 8), new DateTime(2017, 11, 10));
            testingCar.AddRent(new DateTime(2017, 11, 17), new DateTime(2017, 11, 23));
            testingCar.AddRent(new DateTime(2017, 11, 24), new DateTime(2017, 11, 25));
            testingCar.AddRent(new DateTime(2017, 11, 30), new DateTime(2017, 12, 1));
            testingCar.AddRent(new DateTime(2018, 1, 7), new DateTime(2018, 1, 13));
            testingCar.AddRent(new DateTime(2018, 1, 8), new DateTime(2018, 1, 10));
            testingCar.AddRent(new DateTime(2018, 1, 17), new DateTime(2018, 1, 23));
            testingCar.AddRent(new DateTime(2018, 2, 24), new DateTime(2018, 2, 25));
            testingCar.AddRent(new DateTime(2018, 3, 30), new DateTime(2018, 4, 1));

            testingCar.AddRent(new DateTime(2018, 5, 7), new DateTime(2018, 5, 10));
            testingCar.AddRent(new DateTime(2018, 5, 12), new DateTime(2018, 5, 13));
            testingCar.AddRent(new DateTime(2018, 5, 14), new DateTime(2018, 5, 17));
            testingCar.AddRent(new DateTime(2018, 5, 24), new DateTime(2018, 5, 25));
            testingCar.AddRent(new DateTime(2018, 6, 1), new DateTime(2018, 6, 5));
            testingCar.AddRent(new DateTime(2018, 6, 7), new DateTime(2018, 6, 13));
            testingCar.AddRent(new DateTime(2018, 7, 8), new DateTime(2018, 7, 10));
            testingCar.AddRent(new DateTime(2018, 7, 17), new DateTime(2018, 7, 23));
            testingCar.AddRent(new DateTime(2018, 7, 24), new DateTime(2018, 7, 25));
            testingCar.AddRent(new DateTime(2018, 7, 30), new DateTime(2018, 8, 1));

            testingCar.AddRent(new DateTime(2018, 8, 9), new DateTime(2018, 8, 10));
            testingCar.AddRent(new DateTime(2018, 8, 12), new DateTime(2018, 8, 14));
            bool expected = true;

            bool actual = testingCar.IsFreeTheseDates(new DateTime(2019, 4, 12), new DateTime(2019, 4, 21));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryRentBetweenTwoRecordsBeforeCheckOut_GetOrder_ReturnTrue_IfDatesAfterSecondCheckOutFree()
        {
            Car testingCar = new Car("", "", 0);
            testingCar.AddRent(new DateTime(2017, 10, 7), new DateTime(2017, 10, 13));
            testingCar.AddRent(new DateTime(2017, 11, 8), new DateTime(2017, 11, 10));
            testingCar.AddRent(new DateTime(2017, 11, 17), new DateTime(2017, 11, 23));
            testingCar.AddRent(new DateTime(2017, 11, 24), new DateTime(2017, 11, 25));
            testingCar.AddRent(new DateTime(2017, 11, 30), new DateTime(2017, 12, 1));
            testingCar.AddRent(new DateTime(2018, 1, 7), new DateTime(2018, 1, 13));
            testingCar.AddRent(new DateTime(2018, 1, 8), new DateTime(2018, 1, 10));
            testingCar.AddRent(new DateTime(2018, 1, 17), new DateTime(2018, 1, 23));
            testingCar.AddRent(new DateTime(2018, 2, 24), new DateTime(2018, 2, 25));
            testingCar.AddRent(new DateTime(2018, 3, 30), new DateTime(2018, 4, 1));

            testingCar.AddRent(new DateTime(2018, 5, 7), new DateTime(2018, 5, 10));
            testingCar.AddRent(new DateTime(2018, 5, 12), new DateTime(2018, 5, 13));
            testingCar.AddRent(new DateTime(2018, 5, 14), new DateTime(2018, 5, 17));
            testingCar.AddRent(new DateTime(2018, 5, 24), new DateTime(2018, 5, 25));
            bool expected = false;

            bool actual = testingCar.IsFreeTheseDates(new DateTime(2018, 1, 12), new DateTime(2018, 1, 15));

            Assert.AreEqual(expected, actual);
        }
    }
}
