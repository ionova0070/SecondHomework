using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RentOfCarsLibrary
{
    public class Administrator
    {
        public Administrator()
        {
            _cars = new List<Car>();
            _records = new List<Rent>();
        }

        public void AddNewCar(string model, string colour, int identificationNumber)
        {
            _cars.Add(new Car(model, colour, identificationNumber));
        }

        public string[,] ShowAllCars()
        {
            string[,] allCars = new string[_cars.Count, 3];
            int counter = 0;
            foreach (Car car in _cars)
            {
                allCars[counter, 0] = car.Model;
                allCars[counter, 1] = car.Colour;
                allCars[counter, 2] = car.IdentificationNumber.ToString();

                counter++;
            }

            return allCars;
        }

        public string[,] ShowFreeCarsInTheseDates(DateTime beginDate, DateTime finishDate)
        {
            int countOfFreeCars = 0;
            foreach (Car Car in _cars)
            {
                if (Car.IsFreeTheseDates(beginDate, finishDate))
                {
                    countOfFreeCars++;
                }
            }

            string[,] freeCars = new string[countOfFreeCars, 3];
            int counter = 0;
 
            foreach (Car car in _cars)
            {
                if (car.IsFreeTheseDates(beginDate, finishDate))
                {
                    freeCars[counter, 0] = car.Model;
                    freeCars[counter, 1] = car.Colour;
                    freeCars[counter, 2] = car.IdentificationNumber.ToString();
                    counter++;
                }
            }

            return freeCars;
        }

        public bool isPossibleRentCar(string clientName, int identificationNumberOfCar)
        {
            if (!HaveThisClientRent(clientName) && IsThisCarFree(identificationNumberOfCar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RentCar(string clientName, int identificationNumberOfCar, DateTime beginningDate, DateTime finishingDate)
        {
            _records.Add(new Rent(clientName, identificationNumberOfCar, beginningDate, finishingDate));
            foreach (Car car in _cars)
            {
                if (car.IdentificationNumber == identificationNumberOfCar)
                {
                    car.AddRent(beginningDate, finishingDate);
                }
            }
        }
        
        //Этот методы довести до ума не успела
        /*
        public void SaveRecords()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            foreach (Car car in _cars)
            {
                 _fileWithRecordAboutCars.WriteLine(serializer.Serialize(car));
            }

            foreach (Rent rent in _records)
            {
                _fileWithRecordAboutRents.WriteLine(serializer.Serialize(rent));
            }
        } 
         * 
        public void LoadRecords()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StreamReader readFile = File.OpenText(_wayToFileWithCars);
            string input = null;
            _cars.Clear();
            while ((input = readFile.ReadLine()) != null)
            {
                Car car = serializer.Deserialize<Car>(input);
                AddNewCar(car.Model, car.Colour, car.IdentificationNumber);
            }

            readFile = File.OpenText(_wayToFileWithRecords);
            input = null;
            _records.Clear();
            while ((input = readFile.ReadLine()) != null)
            {
                Rent rent = serializer.Deserialize<Rent>(input);
                _records.Add(rent);
            }

            foreach (Rent rent in _records)
            {
                RentCar(rent.ClientName, rent.IdentificationNumberOfCar, rent.DateOfBeginningOfRent, rent.DateOfReturningCar);
            }
        }
        */

        List<Car> _cars;
        List<Rent> _records;
        StreamWriter _fileWithRecordAboutCars;
        StreamWriter _fileWithRecordAboutRents;
        string _wayToFileWithCars;
        string _wayToFileWithRecords;

        struct Rent
        {
            public string ClientName;
            public int IdentificationNumberOfCar;
            public DateTime DateOfBeginningOfRent;
            public DateTime DateOfReturningCar;

            public Rent(string name, int number, DateTime beginningOfRent, DateTime dateOfReturningCar)
            {
                ClientName = name;
                IdentificationNumberOfCar = number;
                DateOfBeginningOfRent = beginningOfRent;
                DateOfReturningCar = dateOfReturningCar;
            }
        }

        bool HaveThisClientRent(string clientName)
        {
            bool answer = false;
            foreach (Rent rent in _records)
            {
                if (String.Equals(clientName, rent.ClientName))
                {
                    answer = true;
                }
            }

            return answer;
        }

        bool IsThisCarFree(int identificationNumberOfCar)
        {
            bool answer = true;
            DeleteOldRecords();
            foreach (Rent rent in _records)
            {
                if (rent.IdentificationNumberOfCar == identificationNumberOfCar)
                {
                    answer = false;
                }
            }
            return answer;
        }

        void DeleteOldRecords()
        {
            foreach (Rent rent in _records)
            {
                if (rent.DateOfReturningCar < DateTime.Today)
                {
                    _records.Remove(rent);
                }
            }
        }      
    }
}
