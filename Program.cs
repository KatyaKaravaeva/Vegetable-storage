using System;
using System.Collections.Generic;
using System.IO;

namespace Vegetables
{

    class Program
    {
        /// <summary>
        /// Метод, который отвечает за проверку корректности введеных значений (при выборе действий).
        /// </summary>
        /// <returns>число</returns>
        public static int WhatDoYouWant()
        {
            int n;
            do
            {
                Console.WriteLine("хотите добавить контейнер - нажмите 1");
                Console.WriteLine("хотите удалить контейнер - нажмите 0");
            } while (!int.TryParse(Console.ReadLine(), out n) || (n < 0) || (n > 1));
            return n;
        }
        /// <summary>
        /// Метод, отвечающий за проверку корректности введенного числа.
        /// </summary>
        /// <param name="massage">сообщение</param>
        /// <returns>корректное число</returns>
        public static int Check(string massage)
        {
            int n;
            do
            {
                Console.WriteLine(massage);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        /// <summary>
        /// В методе реализован дополнительный функционал.
        /// Ввиду того, что заполнять большое количество параметров для каждого ящика довольно проблематично,
        /// то реализован ввод с генирацией чисел (критерии генирации задает пользователь).
        /// </summary>
        /// <param name="wh"></param>
        public static void AdditionalFunctionality(Warehouse wh)
        {
            Random rnd = new Random();
            int number = Check("Введите количество помещаемых в контейнер ящиков: ");
            List<Box> newBox = new List<Box>();
            // Реализация дополнительного функционала. 
            //Пользователю предлагается выбрать ввод параметров ящика.При выборе заполнением случайными числами вводятся границы.
            int howToWrite;
            do
            {
                Console.WriteLine("Вы хотите ввести вручную (нажмите 1) массy ящика и его цену или сгенерировать(нажмите 2)");
            } while (!int.TryParse(Console.ReadLine(), out howToWrite) || (howToWrite > 2) || (howToWrite < 1));
            if (howToWrite == 1)
            {
                for (int k = 0; k < number; k++)
                {
                    int sizeBox = Check("Введите массy ящика (в килограммах) ");
                    int priceBox = Check("Введите цену за килограмм");
                    newBox.Add(new Box(sizeBox, priceBox));
                }
                wh.AddContainer(new Container(number, newBox));
            }
            else
            {
                int min = Check("Введите минимальную границу для генерации чисел(масса ящика): ");
                int max = Check("Введите максимальную границу для для генерации чисел(масса ящика): ");
                do
                {
                    if (min > max)
                    {
                        min = Check("Введите минимальную границу для генерации чисел(масса ящика): ");
                        max = Check("Введите максимальную границу для генерации чисел(масса ящика): ");
                    }
                } while (min > max);
                int minPrice = Check("Введите минимальную границу для генерации чисел(цена за килограмм): ");
                int maxPrice = Check("Введите максимальную границу для для генерации чисел(цена за килограмм): ");
                do
                {
                    if (minPrice > maxPrice)
                    {
                        minPrice = Check("Введите минимальную границу для генерации чисел(цена за килограмм): ");
                        maxPrice = Check("Введите максимальную границу для генерации чисел(цена за килограмм): ");
                    }
                } while (minPrice > maxPrice);

                for (int k = 0; k < number; k++)
                {
                    int sizeBox = rnd.Next(min, max);
                    int priceBox = rnd.Next(minPrice, maxPrice);
                    newBox.Add(new Box(sizeBox, priceBox));
                }
                wh.AddContainer(new Container(number, newBox));
               
            }
        }

        /// <summary>
        /// Метод вызывается, если пользователь хочет вводить данные с консоли.
        /// </summary>
        public static void Way1()
        {
            Random rnd = new Random();
            int capacity = Check("Введите максимальное количество контейнеров для склада: ");
            int price = Check("Введите цену хранения за контейнер");
            Warehouse wh = Warehouse.GetInstance(capacity, price);
            int amountOfCommands = Check("Введите количество команд");
            for (int i = 0; i < amountOfCommands; i++)
            {
                // Просим пользователя выбрать действие.
                int command = WhatDoYouWant();
                if (command == 1)
                {
                    // Реализация дополнительного функционала.
                    AdditionalFunctionality(wh);
                }
                else if (wh.Containers.Count == 0)
                {
                    Console.WriteLine("У вас еще нет контейнеров, поэтому вы ничего не можете удалить.");
                }
                else if (command == 0 && wh.Containers.Count != 0)
                {
                    wh.Print();
                    int n = -1;
                    do
                    {
                        Console.WriteLine("введите номер контейнера ");
                    } while (!int.TryParse(Console.ReadLine(), out n) || (n < 0) || (n > wh.Containers.Count - 1));
                    wh.RemoveContainer(n);
                }
            }
            Console.WriteLine("Ocтавшиеся, после ваших действий, контейнеры: ");
            if (wh.Containers.Count == 0)
                Console.WriteLine("Контейнеров не осталось :(");
            else
                wh.Print();
        }
        /// <summary>
        /// Вывод информации о том, что файл создался автоматически.
        /// </summary>
        public static void AboutWarehouse()
        {
            Console.WriteLine(@"Так как файл ""Warehouse"" еще не был создан, поэтому он был заполнен по умолчанию в => bin=> Debug  ");
           
        }
        /// <summary>
        /// Вывод информации о том, что файл создался автоматически.
        /// </summary>
        public static void AboutCommands()
        {
            Console.WriteLine(@"Так как файл ""Commands"" еще не был создан, поэтому он был заполнен по умолчанию в => bin=> Debug  ");
           
        }
        /// <summary>
        /// Вывод информации о том, что файл создался автоматически.
        /// </summary>
        public static void AboutContainers()
        {
            Console.WriteLine(@"Так как файл ""Containers"" еще не был создан, поэтому он был заполнен по умолчанию в => bin=> Debug  ");
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************************");
            
        }
        /// <summary>
        /// Вывод информации о том, как заполнять файлы.
        /// </summary>
        public static void GeneralInfimation()
        {
            Console.WriteLine("Вам предлагается считать все из файлов, которые находятся в файле с решением.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"В файле ""Warehouse"": ");
            Console.ResetColor();
            Console.WriteLine("Вам нужно будет ввести с новой строки два числа. ");
            Console.WriteLine("Первое - максимальное количество контейнеров для склада, второе - цену хранения за контейнер (все в целых числах)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"В файле """"Commands"""": ");
            Console.ResetColor();
            Console.WriteLine("Вам с новой строки нужно вводить числа. Первое число - количество команд, которое вам потом необходимо применить. Далее вводите либо 1 либо 0(тоже с новой строки)");
            Console.WriteLine("Команда 1 означает, что вы хотите добавить контейнер, 0 - удалить.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"В файле ""Containers"": ");
            Console.ResetColor();
            Console.WriteLine("Вводите информацию об одном контейнере в строчку через пробел");
            Console.WriteLine("В строке должно быть количество ящиков,далее масса и цена для каждого");
            Console.WriteLine("Либо если у вас в другом файле выбрана команда 0(удаление контейнера)," +
                " то на строке должно быть только одно число(номер контейнера, который вы хотите удалить)");
            Console.WriteLine();
            Console.WriteLine("************************************************************************************************************");

        }

        static void Main()
        {

            int flag = 1;
            while (flag == 1)
            {
                int way;
                do
                {
                    Console.WriteLine("Хотите ввести все параметры через консоль - нажмите 1");
                    Console.WriteLine("Хотите все считать из файлов - нажмите 2");
                } while (!int.TryParse(Console.ReadLine(), out way) || (way > 2) || (way < 1));
                if (way == 1)
                {
                    Way1();
                }
                else if (way == 2)
                {
                    GeneralInfimation();
                    if (!File.Exists("Warehouse.txt"))
                    {
                        File.WriteAllText("Warehouse.txt", "2\n2");
                        AboutWarehouse();
                    }
                    string[] warh = File.ReadAllLines("Warehouse.txt");
                    int[] warhint = new int[warh.Length];
                    for (int i = 0; i < warh.Length; i++)
                    {
                        if (!int.TryParse(warh[i], out warhint[i]))
                        {
                            Console.WriteLine(@"Неверно заполнен файл ""Warehouse"" , пожалуйста, попробуйте еще раз");
                            goto m;

                        }
                    }
                    if (warh.Length != 2)
                    {
                        Console.WriteLine("Неверно заполнен файл, пожалуйста, попробуйте еще раз,должно быть только 2 числа в файле ");
                        goto m;
                    }
                    int capacity = warhint[0];
                    int price = warhint[1];
                    Console.WriteLine();
                    if (!File.Exists("Commands.txt"))
                    {
                        Console.WriteLine();
                        File.WriteAllText("Commands.txt", "3\n1\n0\n1");
                        AboutCommands();
                    }
                    string[] commands = File.ReadAllLines("Commands.txt");
                    int[] commandsint = new int[commands.Length - 1];
                    if (commands[0] != (commands.Length - 1).ToString())
                    {
                        Console.WriteLine(@"Неверно заполнен файл ""Commands"" , пожалуйста, попробуйте еще раз");
                        Console.WriteLine(@"В файле ""Commands"" количество команд (первое число в файле) не совпадает с числом введеных далее действий (1 и 0)");
                        goto m;
                    }
                    int count = 0;
                    for (int i = 1; i < commands.Length; i++)
                    {
                        int.TryParse(commands[i], out commandsint[i - 1]);
                        if (commandsint[i - 1] == 0 || commandsint[i - 1] == 1)
                            count++;
                    }
                    if (commands[0] != count.ToString())
                    {
                        Console.WriteLine(@"Неверно заполнен файл ""Commands"" , пожалуйста, попробуйте еще раз");
                        goto m;
                    }
                    int amountOfCommands;
                    if (!int.TryParse(commands[0], out amountOfCommands))
                    {
                        Console.WriteLine(@"Неверно заполнен файл ""Commands"" , пожалуйста, попробуйте еще раз");
                        goto m;
                    }

                    if (!File.Exists("Containers.txt"))
                    {
                        Console.WriteLine();
                        File.WriteAllText("Containers.txt", "2 23 204 20 203\n0\n1 23 450");
                        AboutContainers();
                    }
                    string[] containers = File.ReadAllLines("Containers.txt");
                    if (commands[0] != containers.Length.ToString())
                    {
                        Console.WriteLine("Число команд (1-ое число в файле Commands.txt должно совпадать с количеством строк в файле Containers.txt");
                        Console.WriteLine("Перепроверьте корректность введеных значений в файл");
                        goto m;
                    }

                    Random rnd = new Random();
                    Warehouse wh = Warehouse.GetInstance(capacity, price);
                    for (int i = 0; i < amountOfCommands; i++)
                    {
                        int command = commandsint[i];
                        if (command == 1)
                        {
                            string[] containerinf = containers[i].Split(' ');

                            int[] information = new int[containerinf.Length];
                            for (int j = 0; j < containerinf.Length; j++)
                            {
                                if (!int.TryParse(containerinf[j], out information[j]))
                                {
                                    Console.WriteLine(@"Проверьте, пожалуйста, ввод в файле ""Containers""");
                                    goto m;
                                }
                            }

                            int number = information[0];
                            int checkfile = information[0] * 2 + 1;
                            if (checkfile != containerinf.Length)
                            {
                                Console.WriteLine(@"Неверный ввод данных в файл ""Containers"" ");
                                goto m;
                            }
                            List<Box> newBox = new List<Box>();
                            for (int k = 0, m = 1; k < number; k++)
                            {
                                int sizeBox = information[m++];
                                int priceBox = information[m++];
                                newBox.Add(new Box(sizeBox, priceBox));
                            }
                            wh.AddContainer(new Container(number, newBox));

                        }
                        else if (wh.Containers.Count == 0)
                        {
                            Console.WriteLine("У вас еще нет контейнеров, поэтому вы ничего не можете удалить.");
                        }
                        else if (command == 0 && wh.Containers.Count != 0)
                        {

                            int n;
                            int.TryParse(containers[i], out n);
                            if (n > wh.Containers.Count)
                            {
                                Console.WriteLine("Введенный номер некорректен. Он превышвет количество существующих контейнеров.(В файле Containers.txt)");
                                goto m;
                            }

                            else
                                wh.RemoveContainer(n);
                        }

                    }

                    Console.WriteLine("Ocтавшиеся  контейнеры: ");
                    if (wh.Containers.Count == 0)
                        Console.WriteLine("Контейнеров не осталось :(");
                    else
                        wh.Print();

                }
            m:
                {
                    Console.WriteLine("");
                }
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ecли хотите продолжить введите 1,чтобы выйти - 0 ");
                    Console.ResetColor();
                } while (!int.TryParse(Console.ReadLine(), out flag) || (flag > 1) || (flag < 0));
                Console.Clear();
            }

        }
    }
}
