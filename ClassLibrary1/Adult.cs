using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model 
{
    public class Adult : PersonBase
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

        /// <summary>
        /// Партнёр
        /// </summary>
        private Adult _partner;

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
        /// Минимальный возраст взрослого человека
        /// </summary>
        private const int MinAge = 18;

        /// <summary>
        /// Максимальный возраст взрослого человека
        /// </summary>
        private const int MaxAge = 123;

        /// <summary>
        /// Конструктор класса с параметрами
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportSeria">Серия паспорта</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <param name="maritalStatus">Семейное положение</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="partner">Партнёр</param>
        public Adult(string name, string surname, int age, Gender gender,
            int passportSeria, int passportNumber, MaritalStatus maritalStatus,
            string workPlace, Adult partner = null) :
            base(name, surname, age, gender)
        {
            PassportSeria = passportSeria;
            PassportNumber = passportNumber;
            MaritalStatus = maritalStatus;
            WorkPlace = workPlace;
            Partner = partner;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Adult() { }

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
                    throw new Exception("Введите серию паспорта!");
                }

                if (value < MinPassportSeria || value > MaxPassportSeria)
                {
                    throw new Exception($"{nameof(PassportSeria)}" +
                        $"должен быть в дипазоне от " +
                        $"{MinPassportSeria} до {MaxPassportSeria}");
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
                    throw new Exception($"{nameof(PassportNumber)} " +
                        $"должен быть в дипазоне от " +
                        $"{MinPassportNumber} до {MaxPassportNumber}");
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
        /// Свойство позволяет получить или установить партнёра 
        /// </summary>
        public Adult Partner
        {
            get { return _partner; }
            set { _partner = value; }
        }

        /// <summary>
        /// Ввод места работы
        /// </summary>
        public string WorkPlace
        {
            get { return _workPlace; }
            set { _workPlace = value; }
        }

        /// <summary>
        /// Метод возвращает строковое описание взрослого человека
        /// </summary>
        public override string GetInfo()
        {
            string baseInfo = $" {Surname} {Name}\n Возраст: {Age}\n" +
                $" Пол: {(Gender == Gender.Male ? "мужской" : "женский")}\n";
            string passportInfo = $" Паспорт: серия {PassportSeria} " +
                $"номер {PassportNumber}\n";
            string maritalInfo;
            if (MaritalStatus == MaritalStatus.Married && Partner != null)
            {
                maritalInfo = $" Состоит в браке с: " +
                    $"{Partner.Surname} {Partner.Name}\n";
            }
            else
            {
                maritalInfo = " Не состоит в браке\n";
            }
            string workInfo = string.IsNullOrWhiteSpace(WorkPlace)
                ? " Место работы: Безработный(ая)"
                : $" Место работы: {WorkPlace}";
            return $"{baseInfo}{passportInfo}{maritalInfo}{workInfo}";
        }

        /// <summary>
        /// Проверка человека на взрослость
        /// </summary>
        /// <param name="age">Возраст человека</param>
        /// <exception cref="Exception">Возраст должен быть 
        /// в определнном диапозоне</exception>
        protected override void CheckAge(int age)
        {
            if ((age < MinAge) || (age > MaxAge))
            {
                throw new Exception($"Возраст взрослого человека " +
                    $"от {MinAge} до {MaxAge}");
            }
        }

        /// <summary>
        /// Специальны метод для взрослого человека
        /// </summary>
        /// <returns></returns>
        public string GetCar()
        {
            string[] cars = { "Lada", "Moskvich", "UAZ", "Volga", "Aurus" };
            var random = new Random();
            string car = cars[random.Next(cars.Length)];
            return $"Это взрослый человек, и он ездит на {car}";
        }
    }

}
