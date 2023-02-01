using System;
using System.Collections.Generic;
using System.Text;

namespace Vegetables
{
    class Box
    {
        private int size;
        private int price;

        // Свойство Price.
        public int Price
        {
            get
            {
                return price;

            }
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new Exception();
            }
        }
        // Свойство Size.
        public int Size
        {
            get
            {
                return size;

            }
        }
        /// <summary>
        /// Конструктор в классе Box.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="price"></param>
        public Box(int size, int price)
        {
            if (size <= 0 || price <= 0)
                throw new Exception();
            this.size = size;
            this.price = price;
        }

        /// <summary>
        /// Печать характеристик коробки.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Size: {Size}; Price: {Price}");
        }
    }
}
