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

            PersonList list1 = new PersonList();
            PersonList list2 = new PersonList();

            // Добавление трёх людей в каждый список
            list1.Add(new Person("Александр", "Склярук", 23, Gender.Male));  
            list1.Add(new Person("Араик", "Шароян", 24, Gender.Male));
            list1.Add(new Person("Андрей", "Доценко", 23, Gender.Male));

            list2.Add(new Person("Николай", "Казначеев", 25, Gender.Male));
            list2.Add(new Person("Роман", "Иванов", 30, Gender.Male));
            list2.Add(new Person("Анастасия", "Петрова", 48, Gender.Female));
            WaitForKey(); 

            // Вывод содержимого каждого списка
            PrintList(list1, "Список 1");
            PrintList(list2, "Список 2");
            WaitForKey();

            // Добавление нового человека в первый список
            Person newPerson = new Person("Валерия", "Андреева", 23, Gender.Female);
            list1.Add(newPerson);
            Console.WriteLine("\nПосле добавления нового человека в первый список:");
            PrintList(list1, "Список 1");
            WaitForKey();

            // Копирование второго человека из первого списка во второй список
            Person personCopy = list1.Get(1);
            list2.Add(personCopy);
            Console.WriteLine($"Скопирован человек: " +
                $"{personCopy.Name} {personCopy.Surname}");
            PrintList(list1, "Список 1 (после копирования)");
            PrintList(list2, "Список 2 (после копирования)");
            WaitForKey();

            // Удаление второго человека из первого списка
            list1.RemoveAt(1);
            Console.WriteLine("Второй человек удален из первого списка.");
            PrintList(list1, "Список 1 (после удаления)");
            PrintList(list2, "Список 2 (после удаления из первого списка)");
            WaitForKey();

            // Отчистка второго списка
            list2.Clear();
            Console.WriteLine("Второй список очищен.");
            PrintList(list2, "Список 2 (после очистки)");
            WaitForKey();

            // Ввод, добавление в список, вывод
            Console.WriteLine("\nДобавим человека вручную в Список 1:");
            Person personFromConsole = ReadFromConsole();
            list1.Add(personFromConsole);
            Console.WriteLine("\nВ Список 1 добавлен человек:");
            PrintPerson(personFromConsole);
            PrintList(list1, "Список 1 после добавления");
            WaitForKey();

            // Создание случайного человека
            Person randomPerson = RandomPerson.GetRandomPerson();
            Console.WriteLine("\nСоздан случайный человек:");
            PrintPerson(randomPerson);
            WaitForKey();
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
        public static Person ReadFromConsole()
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
        }

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
