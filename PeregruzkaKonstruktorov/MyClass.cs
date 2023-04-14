using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
     class MyClass
    {

        public int x;
        public MyClass()
        {
            x = 0;
        }
        public MyClass(int i)
        {
            Console.WriteLine("В конструкторе MyClass(int).");
            x = i;
        }
        public MyClass(double d)
        {
            Console.WriteLine("В конструкторе MyClass(double). ");
            x = (int)d;

        }
        public MyClass(int i, int j)
        {
            Console.WriteLine("В конструкторе MyClass(int, int). ");
            x = i * j;
        }
    }  
}
