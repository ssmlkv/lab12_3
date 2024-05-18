using lab10;
using System;
using ClassLibrary1;
using Laba12_3;


namespace lab9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyTree<Carriage> tree = null;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Сформировать идеально сбалансированное бинарное дерево");
                Console.WriteLine("2. Распечатать дерево");
                Console.WriteLine("3. Количество листьев");
                Console.WriteLine("4. Удалить дерево из памяти");
                Console.WriteLine("5. Выход");
                Console.Write("\nВыберите пункт меню: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, выберите пункт меню от 1 до 6:");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите размерность дерева: ");
                        int Size;
                        while (!int.TryParse(Console.ReadLine(), out Size) || Size <= 0)
                        {
                            Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число:");
                        }
                        tree = new MyTree<Carriage>(Size);
                        Random rnd = new Random();
                        for (int i = 0; i < Size; i++)
                        {
                            Carriage randomCarriage = new Carriage();
                            randomCarriage.RandomInit();
                            tree.AddPoint(randomCarriage);
                        }
                        Console.WriteLine("Дерево создано.");
                        break;
                    case 2:
                        if (tree == null)
                        {
                            Console.WriteLine("Дерева нет");
                            break;
                        }
                        Console.WriteLine("Дерево:");
                        tree.ShowTree();
                        break;
                    case 3:
                        if (tree == null)
                        {
                            Console.WriteLine("Дерева нет");
                            break;
                        }           
                            Console.WriteLine($"Количество листьев в дереве: {tree.CountLeaves()}");
                        break;  
                    case 4:
                        tree.ClearTree();
                        break;
                    case 5:
                        exit = true;
                        break;
                }
            }
        }
    }
}