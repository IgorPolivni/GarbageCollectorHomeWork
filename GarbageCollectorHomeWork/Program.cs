using System;
using System.Collections.Generic;
using System.Reflection;

namespace GarbageCollectorHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Car car = new Car()
            {
                Model = "BMW X5",
                Year = 2015
            };

            string[] GetSet = new string[] { "get_", "set_" };

            //Задание 1
            Type console = typeof(Console);
            List<string> methods = new List<string>();
            Console.WriteLine("\n----Методы класса Console----\n");
            foreach (MethodInfo method in console.GetMethods())
            {
                string getOrSetPart = method.Name.Substring(0, 4);
                if (getOrSetPart != GetSet[0] && getOrSetPart != GetSet[1] &&  !methods.Contains(method.Name) )
                {
                    Console.WriteLine($"{method.Name}");
                    methods.Add(method.Name);
                }
            }
            Console.ReadLine();

            //Задание 2
            Type carType = car.GetType();
            Console.WriteLine($"Class: {carType.Name}");
            foreach (PropertyInfo property in carType.GetProperties())
            {
                var method = carType.GetMethod($"{GetSet[0]}{property.Name}");
                Console.WriteLine($"{property.Name} = {method.Invoke(car, new object[0])}");
            }
            Console.ReadLine();
            Console.Clear();



            //Практическая работа
            //Задание 1
            Type type = typeof(String);
            MethodInfo substringMethod = type.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine("Введите индекс начала: ");
            int lengthOfStr = new int(), indexFrom = new int();
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out indexFrom) || indexFrom < 0)
                {
                    Console.WriteLine("Ошибка!!!");
                    Console.Clear();
                }
                break;
            }
            while (true)
            {
                Console.Write("Введите длину: ");
                if (int.TryParse(Console.ReadLine(), out lengthOfStr) && lengthOfStr + indexFrom <= str.Length && lengthOfStr >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка!!!");
                    Console.Clear();
                }
            }

            Console.WriteLine($"Результат: { substringMethod.Invoke(str, new object[] { indexFrom, lengthOfStr })}");

            Console.ReadLine();

            //Задание 2
            Type listType = typeof(List<>);
            foreach (ConstructorInfo constructor in listType.GetConstructors())
            {
                if (constructor.IsPublic)
                    Console.Write("Public");
                else if ((constructor.IsPrivate))
                    Console.Write("Private");
                if (constructor.IsStatic)
                    Console.Write(" Static ");
                Console.Write($"{constructor.Name} (");
                foreach (var parametr in constructor.GetParameters())
                {
                    Console.Write($" {parametr.ParameterType} {parametr.Name} ");
                }
                Console.Write(")\n");

            }
        }
    }
}
