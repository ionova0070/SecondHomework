using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOfCarsLibrary
{
    public class Car
    {
        public string Model { get; private set; }
        public string Colour { get; private set; }
        public int IdentificationNumber { get; private set; }

        public Car(string model, string colour, int identificationNumber)
        {
            Model = model;
            Colour = colour;
            IdentificationNumber = identificationNumber;
            _numberOfRents = 0;
            _rents = new List<Data>();
        }

        public bool IsFreeTheseDates(DateTime dateBegin, DateTime dateFinish)
        {
            DeleteOldRecords();

            int indexOfLastCheckOut = GetIndexOfRecordFromLastCheckOut();
            int index = 0;
            bool answer = true;

            foreach (Data data in _rents)
            {
                if (index >= indexOfLastCheckOut)
                {
                    answer = answer && IsntConflictOfDates(dateBegin, dateFinish, data.BeginningDate, data.FinishingDate);
                }
                index++;
            }

            if ((indexOfLastCheckOut!=-1)&&(dateBegin<=_rents[indexOfLastCheckOut].FinishingDate))
            {
                answer = false;
            }

            return answer;
        }

        public void AddRent(DateTime dateBegin, DateTime dateFinish)
        {
            _rents.Add(new Data(dateBegin, dateFinish, true));

            if (_numberOfRents < 9)
            {
                _numberOfRents++;
            }
            else
            {
                DateTime beginOfCheckOut = _rents.Last<Data>().FinishingDate.AddDays(1);
                AddCheckOut(beginOfCheckOut);
                _numberOfRents = 0;
            }

            _rents.Sort(delegate(Data data1, Data data2) { return data1.BeginningDate.CompareTo(data2.BeginningDate); });
        }



        int _numberOfRents;
        List<Data> _rents;

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

        bool IsntConflictOfDates(DateTime beginDate1, DateTime finishDate1, DateTime beginDate2, DateTime finishDate2)
        {
            bool isFirstDatesEarlier;
            bool isFirstDatesLater;
            
            if (finishDate1<beginDate2)
            {
                isFirstDatesEarlier = true;
            }
            else
            {
                isFirstDatesEarlier = false;
            }

            if (beginDate1>finishDate2)
            {
                isFirstDatesLater = true;
            }
            else
            {
                isFirstDatesLater = false;
            }

            return isFirstDatesEarlier || isFirstDatesLater;
        }

        int GetIndexOfRecordFromLastCheckOut()
        {
            int indexOfRecord = -1;
            int index = 0;
            foreach (Data data in _rents)
            {                
                if (!data.IsRent)
                {
                    indexOfRecord = index;
                }
                index++;
            }
            return indexOfRecord;
        }

        void AddCheckOut(DateTime dateBegin)
        {
            DateTime dateFinish = new DateTime();
            dateFinish = dateBegin.AddDays(6);
            _rents.Add(new Data(dateBegin, dateFinish, false));
        }

        void DeleteOldRecords()
        {
            DateTime currentDate = DateTime.Today;
            foreach (Data data in _rents)
            {
                if (data.FinishingDate<currentDate)
                {
                    _rents.Remove(data);
                }
            }
        }
    }
}
