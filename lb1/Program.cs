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
            Console.ReadKey();

            // Выводим описание всех людей через полиморфизм
            Console.WriteLine("\nСписок всех людей:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\n----------Человек #{i + 1}----------");
                Console.WriteLine(list.Get(i).GetInfo());
            }
            Console.ReadKey();


            //Определяем тип 4-го человека (индекс 3) и вызываем специфичный метод
            Console.WriteLine("\nОпределение типа 4-го человека в списке:");
            Person person4 = list.Get(3);

            if (person4 is Adult adult4)
            {
                Console.WriteLine("Четвёртый человек — взрослый (Adult)");
                Console.WriteLine($"Имя: {adult4.Name}, " +
                    $"Фамилия: {adult4.Surname}, возраст: {adult4.Age}");

                // Демонстрация специфичного метода/поля для Adult
                if (adult4.Partner != null)
                {
                    Console.WriteLine($"Партнёр: {adult4.Partner.Name} " +
                        $"{adult4.Partner.Surname}");
                }
                else
                {
                    Console.WriteLine("Партнёр: отсутствует");
                }

                Console.WriteLine($"Место работы: " +
                    $"{(string.IsNullOrWhiteSpace(adult4.WorkPlace) 
                    ? "Безработный" 
                    : adult4.WorkPlace)}");
            }
            else if (person4 is Child child4)
            {
                Console.WriteLine("Четвёртый человек — ребёнок (Child)");
                Console.WriteLine($"Имя: {child4.Name}, " +
                    $"Фамилия: {child4.Surname}, возраст: {child4.Age}");

                // Демонстрация специфичного метода/поля для Child
                if (child4.Father != null)
                {
                    Console.WriteLine($"   Отец: {child4.Father.Name} " +
                        $"{child4.Father.Surname}");
                }
                else
                {
                    Console.WriteLine("Отец: не указан");
                }

                if (child4.Mother != null)
                {
                    Console.WriteLine($"Мать: {child4.Mother.Name} " +
                        $"{child4.Mother.Surname}");
                }
                else
                {
                    Console.WriteLine("Мать: не указана");
                }

                Console.WriteLine($"Школа: " +
                    $"{(string.IsNullOrWhiteSpace(child4.School) 
                    ? "не учится" 
                    : child4.School)}");
            }
            Console.ReadKey();
        }
    }
}
