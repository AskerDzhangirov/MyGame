using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PeregruzkaKonstruktorov
{
    public class Player
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Level { get; protected set; }
        public int AttackPower { get; private set; } = 5;
        public int MagicAttackPower { get; private set; } = 5;
        public int RangeAttackPower { get; private set; } = 5;
        public int Health { get; protected set; } 
        private const int HealsPoints = 100;

        public Player() { }
        public Player(string name, string nickname, int level, int health)
        {
            this.Name = name;
            this.NickName = nickname;
            this.Level = level;
            this.Health= health;
           
        }
        public Player(string nickname, int level)
        {
            this.NickName = nickname;
            SetLevel(level);
        }
        
        public void SetName(string name)
        {


            if (!CheckOfString(name) || !CheckOfNumber(name))
            {
                SetName(Console.ReadLine());
            }
            else
            {
                Console.WriteLine($"Ваше имя: {name}");
                this.Name = name;
            }
        }

        private bool CheckOfString(string name)
        {

            if (name.Length == 0 || name.Length <= 3)

            {
                Console.WriteLine("Введены некорректные данные.Попробуйте ввести имя снова.");
                return false;
            }
            else

                return true;

        }

        private bool CheckOfNumber(string name)
        {
            if (int.TryParse(name, out int number))

            {
                Console.WriteLine("Некоректное имя: ");
                return false;
            }
            else

                return true;
        }

        public void SetNickName(string nickname)
        {
            if (!CheckOfStringNickName(nickname) || !CheckOfNumberNickName(nickname))
            {
                SetNickName(Console.ReadLine());
            }
            else
                Console.WriteLine($"Ваш НикНейм: {nickname}");
            this.NickName = nickname;
        }

        private bool CheckOfNumberNickName(string nickname)
        {
            if (int.TryParse(nickname, out int number))
            {
                Console.WriteLine("Введено неверное значение.");
                return false;
            }
            else return true;

        }

        private bool CheckOfStringNickName(string nickname)
        {
            CheckOfNumberNickName(nickname);
            if (nickname.Length == 0 || nickname.Length <= 3)

            {
                Console.WriteLine("Не правильно набрано:");
                return false;
            }
            return true;

        }
        
        public void SetLevel(string level)
        {

            if (!SetNewLevel(level))
           
                SetLevel(Console.ReadLine());
            
            else
                Console.WriteLine($"Ваш возраст: {level}");
               
            

        }
        public virtual void SetLevel(int value)
        {
            this.Level = value;
            Health = value * HealsPoints;
        }

        private bool SetNewLevel(string level)
        {
            

            try
            {
                int value = 0;
                value = int.Parse(level);
                this.Level = value;
                if (value <= 0 || value >= 101)
                {
                    Console.WriteLine("Неверно указано число. ");
                    return false;
                }
                return true;
            }

            catch (FormatException)
            {
                Console.Write("Ошибка. ");
                return false;
            }
           

        }

        public string MyName()
        {
            return Name;
        }
        public string MyNickName()
        {
            return NickName;
        }
        public int MyLevel()
        {
            return Level;
        }
        public virtual string MyFulllName()
        {
            return "\n" +  "Ваш Никнейм: " + NickName + "\n" + "Ваш уровень: " + Level +"\n"+ "Ваше здоровье:"+Health;
        }

        
        public virtual int Attack(Enemy enemy)
        {
            return enemy.TakeDamage(AttackPower);
        }
        public virtual int StrongAttack(Enemy enemy)
        {
            return enemy.TakeDamage(AttackPower * 2);
        }
        public virtual int TakeDamage(int value)
        {
            this.Health = this.Health - value;
            return value;
        }
        public int GetStatus()
        {

            if (Health <= 0)
            {
                Console.WriteLine("Помер");
                return Health;
               
            }
           
            else
            {
                return Health;
            }
        }
        
    }
}
