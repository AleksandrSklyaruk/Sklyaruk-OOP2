using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model 
{
    public class Adult : Person
    {
        /// <summary>
        /// Серия паспорта
        /// </summary>
        private int _passportSeria;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Семейное положение
        /// </summary>
        private MaritalStatus _maritalStatus;
        
        /// <summary>
        /// Место работы
        /// </summary>
        private string _workPlace;

        public Adult(string name, string surname, int age, Gender gender, 
            int passportSeria, int passportNumber, MaritalStatus maritalStatus, string workPlace) : 
            base(name, surname, age, gender) 
        {
            PassportSeria = passportSeria;
            PassportNumber = passportNumber;
            MaritalStatus = maritalStatus;
            WorkPlace = workPlace;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Adult() { }

        /// <summary>
        /// Минимальная серия паспорта
        /// </summary>
        public const int MinPassportSeria = 1000;

        /// <summary>
        /// Максимальная серия паспорта
        /// </summary>
        public const int MaxPassportSeria = 9999;
        
        /// <summary>
        /// Минимальный номер паспорта
        /// </summary>
        public const int MinPassportNumber = 100000;

        /// <summary>
        /// Максимальный номер паспорта
        /// </summary>
        public const int MaxPassportNumber = 999999;

        /// <summary>
        /// Свойство позволяет получить или установить серию паспорта
        /// </summary>
        public int PassportSeria
        {
            get { return _passportSeria; }
            set
            {
                if (string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    throw new Exception("Введите номер серии!");
                }

                if (value < MinPassportSeria || value > MaxPassportSeria)
                {
                    throw new Exception($"{nameof(PassportSeria)} должен быть в дипазоне" +
                        $" от {MinPassportSeria} до {MaxPassportSeria}");
                }
                _passportSeria = value;
            }
        }

        /// <summary>
        /// Свойство позволяет получить или установить номер паспорта
        /// </summary>
        public int PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                if (string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    throw new Exception("Введите номер паспорта!");
                }

                if (value < MinPassportNumber || value > MaxPassportNumber)
                {
                    throw new Exception($"{nameof(PassportNumber)} должен быть в дипазоне" +
                        $" от {MinPassportNumber} до {MaxPassportNumber}");
                }
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Свойство позволяет получить или установить семейное положение 
        /// </summary>
        public MaritalStatus MaritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }

        /// <summary>
        /// Ввод места работы
        /// </summary>
        public string WorkPlace
        {
            get { return _workPlace; }
            set { _workPlace = value; }
        }
    }

}
