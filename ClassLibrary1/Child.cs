using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Child : PersonBase
    {
        /// <summary>
        /// Отец
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Мама
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Школа.
        /// </summary>
        private string _school;

        /// <summary>
        /// Минимальный возраст ребенка
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Максимальный возвраст ребенка
        /// </summary>
        private const int MaxAge = 17;

        public Child(string name, string surname,
            Gender gender, int age, Adult father, Adult mother,
            string school) : base(name, surname, age, gender)
        {
            Father = father;
            Mother = mother;
            School = school;
        }

        /// <summary>
        /// Отец ребенка
        /// </summary>
        public Adult Father
        {
            get { return _father; }
            set { _father = value;}
        }

        /// <summary>
        /// Мама ребенка
        /// </summary>
        public Adult Mother
        {
            get { return _mother; }
            set { _mother = value; }
        }

        /// <summary>
        /// Школа
        /// </summary>
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }

        /// <summary>
        /// Метод возвращает строковое описание ребёнка
        /// </summary>
        public override string GetInfo()
        {
            string baseInfo = $" {Surname} {Name}\n Возраст: {Age}\n" +
                $" Пол: {(Gender == Gender.Male ? "мужской" : "женский")}\n";
            string fatherInfo = Father != null
                ? $" Отец: {Father.Surname} {Father.Name}\n"
                : " Отец: не указан\n";
            string motherInfo = Mother != null
                ? $" Мать: {Mother.Surname} {Mother.Name}\n"
                : " Мать: не указана\n";
            string schoolInfo = string.IsNullOrWhiteSpace(School)
                ? " Учебное заведение: не указано\n"
                : $" Учебное заведение: {School}\n";
            return $"{baseInfo}{fatherInfo}{motherInfo}{schoolInfo}";
        }

        /// <summary>
        /// Проверка возраста ребенка
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <exception cref="Exception">Возраст должен соостветствовать 
        /// возрасту ребенка</exception>
        protected override void CheckAge(int age)
        {
            if ((age < MinAge) || (age > MaxAge))
            {
                throw new Exception($"Возраст ребенка должен быть" +
                    $" в пределах от {MinAge} до {MaxAge}");
            }
        }

        /// <summary>
        /// Специальны метод для ребёнка
        /// </summary>
        /// <returns></returns>
        public string GetGame()
        {
            string[] games = { "Red Alert 2", "Postal 2", 
                "Heroes III", "GTA 4", "Mafia" };
            var random = new Random();
            string game = games[random.Next(games.Length)];
            return $"Это ребёнок, и он любит играть в {game}";
        }
    }
}
