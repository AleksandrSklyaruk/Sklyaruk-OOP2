using System;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    /// <summary>
    /// Класс случайной персоны
    /// </summary>
    public class RandomPerson
    {
        /// <summary>
        /// Генерирует случайного взрослого человека
        /// </summary>
        public static Adult GetRandomAdult(Gender gender)
        {
            Random random = new Random();

            string[] maleNames = { "Александр", "Дмитрий", "Иван", "Сергей", 
                "Максим", "Андрей", "Егор", "Артём" };
            string[] femaleNames = { "Мария", "Анна", "Елена", "Ольга", 
                "Татьяна", "Наталья", "Дарья", "Полина" };

            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов", 
                "Попов", "Соколов", "Лебедев", "Морозов", "Волков" };
            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", 
                "Попова", "Соколова", "Лебедева", "Морозова", "Волкова" };

            string[] workPlaces = { "СО ЕЭС", "Сбербанк", "Яндекс", "Газпром", 
                "РЖД", "" };

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            int age = random.Next(18, 123 + 1);

            int passportSeria = random.Next(Adult.MinPassportSeria, 
                Adult.MaxPassportSeria + 1);
            int passportNumber = random.Next(Adult.MinPassportNumber, 
                Adult.MaxPassportNumber + 1);

            MaritalStatus maritalStatus = random.Next(2) == 0
                ? MaritalStatus.Married
                : MaritalStatus.Single;

            string workPlace = workPlaces[random.Next(workPlaces.Length)];

            Adult partner = null;
            if (maritalStatus == MaritalStatus.Married)
            {
                Gender partnerGender = gender == Gender.Male 
                    ? Gender.Female 
                    : Gender.Male;

                string partnerName = partnerGender == Gender.Male
                    ? maleNames[random.Next(maleNames.Length)]
                    : femaleNames[random.Next(femaleNames.Length)];

                string partnerSurname = partnerGender == Gender.Male
                    ? RemoveLastSimvol(surname)
                    : surname + "а";

                partner = new Adult( partnerName, partnerSurname, 
                    random.Next(18, 123 + 1), partnerGender, 
                    random.Next(Adult.MinPassportSeria, 
                    Adult.MaxPassportSeria + 1), 
                    random.Next(Adult.MinPassportNumber, 
                    Adult.MaxPassportNumber + 1), 
                    MaritalStatus.Married, "", null
                );
            }

            return new Adult( name, surname, age, gender, passportSeria, 
                passportNumber, maritalStatus, workPlace, partner );
        }

        /// <summary>
        /// Генерирует случайного взрослого человека (любой пол)
        /// </summary>
        public static Adult GetRandomAdult()
        {
            Random random = new Random();
            Gender gender = random.Next(2) == 0 ? Gender.Male : Gender.Female;
            return GetRandomAdult(gender);
        }

        /// <summary>
        /// Генерирует случайного ребёнка
        /// </summary>
        public static Child GetRandomChild()
        {
            Random random = new Random();

            string[] maleNames = { "Михаил", "Артём", "Никита", 
                "Даниил", "Матвей", "Илья", "Тимофей" };
            string[] femaleNames = { "София", "Алиса", "Виктория", 
                "Полина", "Варвара", "Анна", "Мария" };

            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов", 
                "Попов", "Соколов" };
            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", 
                "Попова", "Соколова" };

            string[] schools = { "Школа №15", "Гимназия №2", "Лицей №7", 
                "Школа №32", "" };

            Gender gender = random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female;

            string name = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string surname = gender == Gender.Male
                ? surnamesMale[random.Next(surnamesMale.Length)]
                : surnamesFemale[random.Next(surnamesFemale.Length)];

            int age = random.Next(0, 18);

            Adult father = null;
            Adult mother = null;

            if (random.Next(2) == 0)
            {
                father = GetRandomAdult(Gender.Male);
            }

            if (random.Next(2) == 0)
            {
                mother = GetRandomAdult(Gender.Female);
            }

            if (father != null && mother != null) 
            {
                mother.Surname = father.Surname + "а";
            }

            if (father != null)
            {
                if (gender == Gender.Female)
                {
                    surname = father.Surname + "а";
                }
                else
                {
                    surname = father.Surname;
                }
            }
            else if (mother != null)
            {
                if (gender == Gender.Male)
                {
                    surname = RemoveLastSimvol(mother.Surname);
                }
                else
                {
                    surname = mother.Surname;
                }
            }

            string school = schools[random.Next(schools.Length)];

            return new Child( name, surname, gender, 
                age, father, mother, school );
        }
        /// <summary>
        /// Метод удаляет последний символ слова
        /// </summary>
        /// <param name="word">фамилия</param>
        /// <returns></returns>
        protected static string RemoveLastSimvol(string word)
        {
            string correctWord = "";
            for (int i = 0; i < word.Length - 1; i++)
            {
                correctWord = correctWord + word[i];
            }
            return correctWord;
        }
    }
}