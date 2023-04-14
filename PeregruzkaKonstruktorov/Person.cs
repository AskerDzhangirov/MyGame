using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public Person() { }
        public Person(string FirstName,string LastName,int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Age = Age;
        }
        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        
        public void SetFirstName(string FirstName)
        {
            if (CheckOfNumber(FirstName) &&  CheckStringComplex(FirstName))
            {
                this.FirstName = FirstName;
            }
            Console.WriteLine($"FirstName correct: {this.FirstName}");
        }

        private bool CheckStringComplex(string FirstName)
        {
            if (FirstName.Length == 0)
            {
                Console.WriteLine(" хуета ");
                Console.WriteLine("Repeat input FirstName: ");
                SetFirstName(Console.ReadLine());

            }
            if (FirstName.IndexOf(" ") != -1)
            {
                Console.WriteLine("Пробел найден");
                Console.WriteLine("Repeat input FirstName: ");
                SetFirstName(Console.ReadLine());
            }
            if (FirstName.Length <= 3)
            {
                Console.WriteLine($"{FirstName} Мало букв в имени");
                Console.WriteLine("Repeat input FirstName: ");
                SetFirstName(Console.ReadLine());
            }
            return true;
        }

        private bool CheckOfNumber(string FirstName)
        {
            if (int.TryParse(FirstName, out int number))
            {
                Console.WriteLine("Некоректное имя");
                Console.WriteLine("Repeat input FirstName: ");
                SetFirstName(Console.ReadLine());
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
