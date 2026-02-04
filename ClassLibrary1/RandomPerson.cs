using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс случайного человек
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Создаёт и возвращает новый экземпляр класса Person со случайными данными.
        /// </summary>
        /// <returns>Новый объект Person.</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = { "Александр", "Дмитрий", "Иван", "Сергей",
                                   "Андрей", "Максим", "Егор", "Артём" };
            string[] femaleNames = { "Ангелина", "Елена", "Мария", "Татьяна",
                                     "Наталья", "Ольга", "Дарья", "Полина" };

            string[] surnamesMale = { "Склярук", "Смирнов", "Кузнецов",
                                      "Попов", "Волков", "Соколов",
                                      "Лебедев", "Морозов" };
            string[] surnamesFemale = { "Савосто", "Смирнова", "Кузнецова",
                                        "Попова", "Волкова", "Соколова",
                                        "Лебедева", "Морозова" };

            var gender = random.Next(2) == 0
                ? Gender.Male
                : Gender.Female;

            int age = random.Next(0, Person.MaxAge + 1);

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            return new Person(name, surname, age, gender);
        }
    }
}
