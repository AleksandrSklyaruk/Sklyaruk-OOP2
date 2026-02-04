using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    /// <summary>
    /// Хранение и обработка данных о человеке
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Создаёт человека
        /// </summary>
        /// <param name="Name">Имя человека</param>
        /// <param name="Surname">Фамилия человека</param>
        /// <param name="Age">Количество лет</param>
        /// <param name="Gender">Пол человека</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Получение и валидация имени.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = Validate(value, "Имя");
                EnsureLanguage();
            }
        }

        /// <summary>
        /// Получение и валидация фамилии.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = Validate(value, "Фамилия");
                EnsureLanguage();
            }
        }

        /// <summary>
        /// Минимальный возраст человека
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        public const int MaxAge = 123;

        /// <summary>
        /// Проверка корректности ввода возраста
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    throw new Exception("Введите возраст!");
                }

                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception($"{nameof(Age)} должен быть в дипазоне" +
                        $" от {MinAge} до {MaxAge}");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Свойство Gender позволяет получить или установить пол человека.
        /// </summary>
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /// <summary>
        /// Проверка строки, содержащей только кириллические символы
        /// </summary>
        private const string RussianPattern = @"^[а-яА-ЯёЁ]+(?:-[а-яА-ЯёЁ]+)?$";

        /// <summary>
        /// Проверка строки, содержащей только латинские символы
        /// </summary>
        private const string LatinPattern = @"^[a-zA-Z]+(?:-[a-zA-Z]+)?$";

        /// <summary>
        /// Проверяет корректность входной строки по заданным правилам
        /// </summary>
        /// <param name="value">Проверяемая строка</param>
        /// <param name="fieldName">Название поля</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">при неверном вводе</exception>
        private static string Validate(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    $"{fieldName} не может быть пустым " +
                    $"или состоять только из пробелов.");
            }

            bool isRussian = Regex.IsMatch(value, RussianPattern);
            bool isLatin = Regex.IsMatch(value, LatinPattern);

            if (!isRussian && !isLatin)
            {
                throw new ArgumentException(
                    $"{fieldName} может содержать только русские буквы" +
                    $" ИЛИ только английские буквы. " +
                    $"Двойное имя/фамилия допускается через дефис.");
            }

            var textInfo =
                System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(value.ToLowerInvariant());
        }

        /// <summary>
        /// Проверка совпадаения языка имени и фамилии, если оба установлены
        /// </summary>
        /// <exception cref="InvalidOperationException">Если язык имени
        /// и фамилии не совпадают и оба поля установлены.</exception>
        private void EnsureLanguage()
        {
            if (!string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname))
            {
                bool nameIsRussian = Regex.IsMatch(_name, RussianPattern);
                bool surnameIsRussian = Regex.IsMatch(_surname, RussianPattern);

                if (nameIsRussian != surnameIsRussian)
                {
                    throw new InvalidOperationException(
                        "Язык имени и фамилии не совпадает. " +
                        "Имя и фамилия должны быть на одном языке.");
                }
            }
        }

        /// <summary>
        /// Создание нового экземпляра класса Person по умолчанию.
        /// </summary>
        public Person() { }
    }
}
