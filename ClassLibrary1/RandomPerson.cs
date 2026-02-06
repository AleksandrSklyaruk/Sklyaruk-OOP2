using System;

namespace Model
{
    /// <summary>
    /// Класс для генерации случайных персон
    /// </summary>
    public class RandomPerson
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Генерирует случайного взрослого человека
        /// </summary>
        public static Adult GetRandomAdult()
        {
            // Русские имена
            string[] maleNames = { "Александр", "Дмитрий", "Иван", "Сергей", "Максим", "Андрей", "Егор", "Артём" };
            string[] femaleNames = { "Мария", "Анна", "Елена", "Ольга", "Татьяна", "Наталья", "Дарья", "Полина" };

            // Фамилии для мужчин и женщин (отдельные массивы!)
            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Соколов", "Лебедев", "Морозов", "Волков" };
            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", "Попова", "Соколова", "Лебедева", "Морозова", "Волкова" };

            string[] workPlaces = { "ТПУ", "Сбербанк", "Яндекс", "Газпром", "РЖД", "" }; // пустая строка = безработный

            // Случайный пол
            Gender gender = _random.Next(2) == 0 ? Gender.Male : Gender.Female;

            // Случайное имя в зависимости от пола
            string name = gender == Gender.Male
                ? maleNames[_random.Next(maleNames.Length)]
                : femaleNames[_random.Next(femaleNames.Length)];

            // Случайная фамилия в зависимости от пола (отдельные массивы!)
            string surname = gender == Gender.Male
                ? surnamesMale[_random.Next(surnamesMale.Length)]
                : surnamesFemale[_random.Next(surnamesFemale.Length)];

            // Случайный возраст (взрослый: 18-121)
            int age = _random.Next(18, 121);

            // Случайные паспортные данные
            int passportSeria = _random.Next(Adult.MinPassportSeria, Adult.MaxPassportSeria + 1);
            int passportNumber = _random.Next(Adult.MinPassportNumber, Adult.MaxPassportNumber + 1);

            // Семейное положение
            MaritalStatus maritalStatus = _random.Next(2) == 0
                ? MaritalStatus.Married
                : MaritalStatus.Single;

            // Место работы (иногда пустое = безработный)
            string workPlace = workPlaces[_random.Next(workPlaces.Length)];

            // Партнёр (только если женат/замужем, без рекурсии)
            Adult partner = null;
            if (maritalStatus == MaritalStatus.Married && _random.Next(2) == 0)
            {
                // Создаём партнёра противоположного пола
                Gender partnerGender = gender == Gender.Male ? Gender.Female : Gender.Male;
                string partnerName = partnerGender == Gender.Male
                    ? maleNames[_random.Next(maleNames.Length)]
                    : femaleNames[_random.Next(femaleNames.Length)];

                // Фамилия партнёра тоже зависит от его пола
                string partnerSurname = partnerGender == Gender.Male
                    ? surnamesMale[_random.Next(surnamesMale.Length)]
                    : surnamesFemale[_random.Next(surnamesFemale.Length)];

                partner = new Adult(
                    partnerName,
                    partnerSurname,
                    _random.Next(18, 121),
                    partnerGender,
                    _random.Next(Adult.MinPassportSeria, Adult.MaxPassportSeria + 1),
                    _random.Next(Adult.MinPassportNumber, Adult.MaxPassportNumber + 1),
                    MaritalStatus.Married,
                    "",
                    null // без рекурсии!
                );
            }

            // Возвращаем случайного взрослого
            return new Adult( name, surname, age, gender, passportSeria, 
                passportNumber, maritalStatus, workPlace, partner );
        }

        /// <summary>
        /// Вспомогательный метод для генерации случайного родителя
        /// </summary>
        /// <param name="isFather">true — отец, false — мать</param>
        private static Adult GetRandomParent(bool isFather)
        {
            // 50% шанс отсутствия родителя
            if (_random.Next(2) == 0)
            {
                return null;
            }

            // Имена и фамилии для родителей
            string[] maleNames = { "Александр", "Дмитрий", "Иван", "Сергей", "Максим" };
            string[] femaleNames = { "Мария", "Анна", "Елена", "Ольга", "Татьяна" };
            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Соколов" };
            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", "Попова", "Соколова" };

            Gender parentGender = isFather ? Gender.Male : Gender.Female;
            string name = parentGender == Gender.Male
                ? maleNames[_random.Next(maleNames.Length)]
                : femaleNames[_random.Next(femaleNames.Length)];

            string surname = parentGender == Gender.Male
                ? surnamesMale[_random.Next(surnamesMale.Length)]
                : surnamesFemale[_random.Next(surnamesFemale.Length)];

            int age = _random.Next(25, 55); // родители обычно старше 25 лет

            return new Adult( name, surname, age, parentGender,
                _random.Next(Adult.MinPassportSeria, Adult.MaxPassportSeria + 1),
                _random.Next(Adult.MinPassportNumber, Adult.MaxPassportNumber + 1),
                MaritalStatus.Married,
                _random.Next(2) == 0 ? "Работа" : "",
                null // без рекурсии!
            );
        }

        /// <summary>
        /// Генерирует случайного ребёнка
        /// </summary>
        public static Child GetRandomChild()
        {
            // Русские имена для детей
            string[] maleNames = { "Михаил", "Артём", "Никита", "Даниил", "Матвей", "Илья", "Тимофей" };
            string[] femaleNames = { "София", "Алиса", "Виктория", "Полина", "Варвара", "Анна", "Мария" };

            // Фамилии для детей (берутся от родителей, но для базового случая тоже нужны)
            string[] surnamesMale = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Соколов" };
            string[] surnamesFemale = { "Иванова", "Смирнова", "Кузнецова", "Попова", "Соколова" };

            string[] schools = { "Школа №15", "Гимназия №2", "Лицей №7", "Школа №32", "" }; // пустая строка = не учится

            // Случайный пол
            Gender gender = _random.Next(2) == 0 ? Gender.Male : Gender.Female;

            // Случайное имя
            string name = gender == Gender.Male
                ? maleNames[_random.Next(maleNames.Length)]
                : femaleNames[_random.Next(femaleNames.Length)];

            // Случайная фамилия (временно, потом заменим на фамилию родителя)
            string surname = gender == Gender.Male
                ? surnamesMale[_random.Next(surnamesMale.Length)]
                : surnamesFemale[_random.Next(surnamesFemale.Length)];

            // Случайный возраст (ребёнок: 0-17)
            int age = _random.Next(0, 18);

            // Родители (иногда есть, иногда нет)
            Adult father = GetRandomParent(true);   // true = отец
            Adult mother = GetRandomParent(false);  // false = мать

            // Если есть отец — берём его фамилию (мужскую версию)
            if (father != null)
            {
                surname = father.Surname;
            }
            // Иначе если есть мать — берём её фамилию (женскую версию)
            else if (mother != null)
            {
                surname = mother.Surname;
            }

            // Случайная школа/сад
            string school = schools[_random.Next(schools.Length)];

            // Возвращаем случайного ребёнка
            return new Child( name, surname, gender, age, father, mother, school);
        }
    }
}
