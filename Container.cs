using System;
using System.Collections.Generic;
using System.Text;

namespace Vegetables
{
    /// <summary>
    /// Класс Container, отвечает за содержимое контейнера.
    /// </summary>
    class Container
    {
        static Random rnd = new Random();
        int predel;
        private int number;
        int limit = 0;
        List<Box> boxes = new List<Box>();

        /// <summary>
        /// Формируем контейнер, используя конструктор.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="boxes"></param>
        public Container(int number, List<Box> boxes)
        {
            predel = rnd.Next(500, 1001);
            int count = 0;
            for (int i = 0; i < boxes.Count; i++)
            {
                if (count + boxes[i].Size <= predel && this.boxes.Count < number )
                {
                    this.boxes.Add(new Box(boxes[i].Size, boxes[i].Price));
                    count += boxes[i].Size;
                }
                
            }
            this.number = this.boxes.Count;
        }
        // Свойство Number.
        public int Number
        {
            get
            {
                return number;
            }
        }
        // Свойство TotalPrice.
        public int TotalPrice
        {
            get
            {
                int sum = 0;
                foreach (var box in Boxes)
                {
                    sum += box.Price * box.Size;
                }

                return sum;
            }
        }
        /// <summary>
        /// Добавление коробок в контейнер.
        /// </summary>
        /// <param name="box">коробка</param>
        public void AddBoxes(Box box)
        {
            limit += box.Size;
            if (limit <= predel)
                boxes.Add(new Box(box.Size, box.Price));
            else
            {
                Console.WriteLine("Ящик не добавился");
                box.Print();
            }

        }

        public List<Box> Boxes
        {
            get
            {
                return boxes;
            }

        }
        /// <summary>
        /// Печать коробок.
        /// </summary>
        public void Print()
        {
            foreach (var box in Boxes)
            {
                box.Print();
            }
        }

    }

}
