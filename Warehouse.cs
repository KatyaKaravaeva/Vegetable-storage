using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Vegetables
{
    /// <summary>
    /// Класс, который представляет собою склад, где хранятся контейнеры.
    /// </summary>
    class Warehouse
    {
        Random rnd = new Random();
        private List<Container> containers;
        private static Warehouse instance;
        int capacity;
        int price;
        int last = -1;
        // Формируем склад с помощью конструктора.
        private Warehouse(int capacity, int price)
        {
            Containers = new List<Container>();
            this.capacity = capacity;
            this.price = price;
        }
        // Находим общую стоимость контейнеров.
        public int TotalPrice
        {
            get
            {
                int sum = 0;
                foreach (var container in Containers)
                {
                    sum += container.TotalPrice;
                }

                return sum;
            }
        }

        public static Warehouse GetInstance(int capacity, int price)
        {
            if (instance == null) instance = new Warehouse(capacity, price);
            return instance;
        }

        public List<Container> Containers
        {
            get => containers;
            set => containers = value;
        }
      /// <summary>
      /// Добавляем контейнер на склад.
      /// </summary>
      /// <param name="container">контейнер</param>
        public void AddContainer(Container container)
        {
            double power = (0.5) * rnd.NextDouble();
            if (container.TotalPrice * (1 - power) <= price)
            {
                Console.WriteLine("Контейнер не рентабельный");
            }
            else 
            {
                if (containers.Count == capacity)
                {
                    last = (last + 1) % capacity;
                    containers[last] = new Container(container.Number, container.Boxes);
                }
                else
                {
                    containers.Add(new Container(container.Number, container.Boxes));
                }
            }

        }
        /// <summary>
        /// Удаляем контейнер со склада.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveContainer(int id)
        {
            if (id < Containers.Count)
                Containers.RemoveAt(id);
            else
                Console.WriteLine("Такого контейнера нет");
        }
        /// <summary>
        /// Вывод на экран контейнеров.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Containers.Count; i++)
            {
                Console.WriteLine($"number of container: {i}");
                containers[i].Print();
            }
            
        }
    }
}
