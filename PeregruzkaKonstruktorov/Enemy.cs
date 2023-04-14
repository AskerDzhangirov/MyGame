using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{

    public class Enemy
    {

        public Enemy()
        {

        }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int AttackPower { get; private set; } = 10;


        private const int lightMobs = 10;

        public Enemy(string name, int level, int health)
        {
            Name = name;
            SetLevel(level);
            Health = health;

        }
        public Enemy(string name, int level)
        {
            Name = name;
            SetLevel(level);

        }
        public void SetName(string name)

        {
            if (!ChekOfName(name))
                SetName(Console.ReadLine());
            else
                Console.WriteLine($"Имя врага: {name}");
            this.Name = name;

        }

        private bool ChekOfName(string name)
        {
            if (name.Length < 0 || name.Length <= 3 || int.TryParse(name, out int number))
            {
                Console.WriteLine("xyeta");
                return false;
            }
            else
            {
                return true;
            }


        }


        public void SetLevel(string level)
        {

            if (!CheckOfLevel(level))

                SetLevel(Console.ReadLine());

            else
                Console.WriteLine($"Уровень врага: {level}");

        }

        public void SetLevel(int value)
        {
            this.Level = value;
            Health = value * lightMobs;

        }

        public int GetLevel()
        {
            return this.Level;
        }

        public string GetName()
        {
            return this.Name;

        }

        private bool CheckOfLevel(string level)
        {
            try
            {
                int value = int.Parse(level);
                this.Level = value;
                Health = value * lightMobs;
                if (value <= 0 || value >= 101)
                {
                    Console.WriteLine("Неверно указано значение.");
                    return false;
                }
                else return true;

            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка. ");
            }
            return false;
        }
        public int GetStatus()
        {
            if (this.Health <= 0)
            {
                Console.WriteLine($"Wolf Мертв. ");
                return this.Health;
            }

            else
            {
                return this.Health;

            }


        }
        public int TakeDamage(int value)
        {
            this.Health = this.Health - value;
            return value;
        }
        public int Attack(Player player)
        {
            return player.TakeDamage(AttackPower);
        }
        public int StrongAttack(Player player)
        {
            return player.TakeDamage(AttackPower * 2);
        }
        //public int StepByStep()
        //{
        //    int step;
        //    for (step = 0; step <= 3; step++)
        //        if (step == 3)
        //        {
        //            Console.WriteLine("Волк настиг вас.");

        //        }
        //    else if (step != 3)
        //            Console.WriteLine("Волк делает шаг.");
        //    return step;











    }
}


            
            
            
           
            
 

    








//}
//public void SetHealth(string health)
//{
//    if (!CheckOfHealth(health))
//        SetHealth(Console.ReadLine());
//    else

//        Console.WriteLine($"Здоровье врага: {health}");
//}

//public void SetHealth(int value)
//{
//    this.Health = value;
//}

//private bool CheckOfHealth(string health)
//{

//    try
//    {
//       int value = int.Parse(health);
//       this.Health = value;
//        if (value <= 0 || value >= 500)
//        {
//            Console.WriteLine("Неверно указано значение.");
//            return false;
//        }
//        else return true;

//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Ошибка. ");
//    }
//        //    return false;

//        }


