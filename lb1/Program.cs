using Model;
using System;
using System.Reflection;

namespace lb1
{
    /// <summary>
    /// Класс основной части программы
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Создание списков
        /// </summary>
        /// <param name="args">аргумент</param>
        public static void Main(string[] args)
        {
            // Создаём взрослого с партнёром
            Adult adult1 = new Adult("Мария", "Петрова", 28, Gender.Female,
                4321, 654321, MaritalStatus.Single, "Сбербанк", null);

            Adult adult2 = new Adult("Иван", "Иванов", 30, Gender.Male,
                1234, 567890, MaritalStatus.Married, "ТГУ", adult1);

            // Создаём ребёнка
            Child child = new Child("Анна", "Иванова", Gender.Female, 8,
                adult2, adult1, "Школа №15");

            // Выводим информацию — метод НЕ выводит сам, только возвращает строку!
            Console.WriteLine("=== Взрослый ===");
            Console.WriteLine(adult2.GetInfo());  // ← только получение строки

            Console.WriteLine("\n=== Ребёнок ===");
            Console.WriteLine(child.GetInfo());

        }

        /// <summary>
        /// Метод для вывода списка людей на консоль с указанным заголовком
        /// </summary>
        /// <param name="list">Список для вывода</param>
        /// <param name="listName">Заголовок списка</param>
        private static void PrintList(PersonList list, string listName)
        {
            Console.WriteLine($"\n{listName}:");
            for (int i = 0; i < list.Count; i++)
            {
                PrintPerson(list.Get(i));
            }
        }

        /// <summary>
        /// Метод для вывода информации об одном человеке
        /// </summary>
        /// <param name="person">Объект Person для вывода</param>
        private static void PrintPerson(Person person)
        {
            string genderStr = person.Gender 
                == Gender.Male ? "Мужской" : "Женский";
            Console.WriteLine($"{person.Name} {person.Surname}," +
                $" возраст: {person.Age}, пол: {genderStr}");
        }

        /// <summary>
        /// Метод для паузы между пунктами программы
        /// </summary>
        private static void WaitForKey()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        /// <summary>
        /// Ввод пользователя с консоли.
        /// </summary>
        /// <returns>возвращает объект класса Person</returns>
        /// <exception cref="Exception">создание при неверном вводе</exception>
        /*public static Person ReadFromConsole()
        {
            var person = new Person();

            var actionDictionary = new Dictionary<string, Action>()
            {
                {
                    "имя",
                    new Action(() =>
                    {
                        person.Name = Console.ReadLine();
                    })
                },
                {
                    "фамилию",
                    new Action(() =>
                    {
                        person.Surname = Console.ReadLine();
                        })
                },
                {
                    "возраст",
                    new Action(() =>
                    {
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            person.Age = age;
                        }
                        else
                        {
                            throw new Exception("Введённая строка " +
                                "не может быть преобразована в число");
                        }
                    })
                },
                {
                    "пол (1 — Мужчина, 2 — Женщина)",
                    new Action(() =>
                    {
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                            {
                                person.Gender = Gender.Male;
                                break;
                            }
                            case "2":
                            {
                                person.Gender = Gender.Female;
                                break;
                            }
                            default:
                            {
                                throw new Exception("Некорректный ввод" +
                                    " Введите 1 или 2.");
                            }

                        }
                    })
                }
            };

            foreach (var actionHandler in actionDictionary)
            {
                ActionHandler(actionHandler.Value, actionHandler.Key);
            }

            return person;
        }*/

        /// <summary>
        /// При возникновении исключения выводит сообщение и повторяет ввод.
        /// </summary>
        /// <param name="action">Действие, ввод и присваивание</param>
        /// <param name="fieldName">Название поля</param>
        private static void ActionHandler(Action action, string fieldName)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {fieldName}: ");
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($" Ошибка: {exception.Message}" +
                        $" Попробуйте снова.");
                }
            }
        }
    }
}
