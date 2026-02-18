using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс списка с людьми
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса с пустым списком
        /// </summary>
        private List<PersonBase> _persons;

        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public PersonList()
        {
            _persons = new List<PersonBase>();
        }

        /// <summary>
        /// Добавить нового человека в список
        /// </summary>
        public void Add(PersonBase person)
        {
            _persons.Add(person);
        }

        /// <summary>
        /// Вернуть человека из списка по его индексу
        /// </summary>
        public PersonBase Get(int index)
        {
            ValidateIndex(index);
            return _persons[index];
        }

        /// <summary>
        /// Вернуть количество людей в списке
        /// </summary>
        public int Count
        {
            get { return _persons.Count; }
        }

        /// <summary>
        /// Метод проверяющий корректность индекса
        /// </summary>
        /// <param name="index">индекс</param>
        /// <exception cref="ArgumentOutOfRangeException">возникает когда 
        /// индекс вне диапазона</exception>
        public void ValidateIndex(int index)
        {
           if (index < 0 || index >= _persons.Count)
           {
               throw new ArgumentOutOfRangeException("Индекс вне диапазона");
           }
        }
    }
}
