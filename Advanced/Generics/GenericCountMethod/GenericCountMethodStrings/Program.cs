using System;
using System.Collections.Generic;

namespace GenericCountMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            //Box<string> data = new Box<string>();
            //
            //for (int i = 0; i < numberOfElements; i++)
            //{
            //    string element = Console.ReadLine();
            //
            //    data.Add(element);
            //}
            //
            //string elementToCompareWith = Console.ReadLine();
            //
            //Console.WriteLine(data.FilterTGreatherThanParameter(elementToCompareWith));

           Box<double> data = new Box<double>();
           
           for (int i = 0; i < numberOfElements; i++)
           {
               data.Add(double.Parse(Console.ReadLine()));
           }
           
           double parameter = double.Parse(Console.ReadLine());
           Console.WriteLine(data.FilterTGreatherThanParameter(parameter));
        }             
    }
}
