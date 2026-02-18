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
            PersonList list = new PersonList();
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                if (random.Next(2) == 0)
                {
                    list.Add(RandomPerson.GetRandomAdult());
                    Console.WriteLine($"{i + 1} Добавлен взрослый");
                }
                else
                {
                    list.Add(RandomPerson.GetRandomChild());
                    Console.WriteLine($"{i + 1} Добавлен ребёнок");
                }
            }

            WaitKey();

            Console.WriteLine("\nСписок всех людей:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\n----------Человек #{i + 1}----------");
                Console.WriteLine(list.Get(i).GetInfo());
            }

            WaitKey();

            Console.WriteLine("\nОпределение типа 4-го человека:\n");

            var person = list.Get(3);

            switch (person)
            {
                case Adult personAdult:
                    {
                        Console.WriteLine(personAdult.GetCar());
                        break;
                    }
                case Child personChild:
                    {
                        Console.WriteLine(personChild.GetGame());
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            WaitKey();
        }

        /// <summary>
        /// Метод для ожидания действий пользователя
        /// </summary>
        private static void WaitKey()
        {
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }

}
