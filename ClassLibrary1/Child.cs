using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Child : Person
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

        public Child(string name, string surname,
            Gender gender, int age, Adult father, Adult mother,
            string school) : base(name, surname, age, gender)
        {
            Father = father;
            Mother = mother;
            School = school;
            _maxAge = 17;
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
        /// Возвращает строковое описание ребёнка
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
    }
}
