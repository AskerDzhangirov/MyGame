using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PeregruzkaKonstruktorov
{
    public class Warrior : Player
    {
        private const int HealsPoints = 200;
        public int Rage { get; private set; } = 50;
        public int Protection { get; private set; } = 5;




        public Warrior(string nickname, int level, int rage, int protection) : base(nickname, level) 
        {
            Rage = rage;
            Protection = protection;
        }
        public Warrior(string nickname, int level) : base(nickname, level) 
        {
            SetLevel(level);
            SetRage(level);
            SetProtection(level);
            SetNickName(nickname);
        }
        

        public override void SetLevel(int value)
        {
            this.Level = value;
            Health = value * HealsPoints;
        }
        public void SetRage(int value)
        {
            this.Level = value;
            Rage = value * Rage;
        }
        public void SetProtection(int value) 
        {
            this.Level = value;
            Protection = value * Protection;
       
        }
        public override string MyFulllName()
        {
            return "\n" + "Ваш Никнейм: " + NickName + "\n" + "Ваш уровень: " + Level + "\n" + "Ваше здоровье:" + Health+ "\n" + "Ваша ярость:" + Rage+ "\n" + "Ваша защита:" + Protection;

        }
        public override int TakeDamage(int value)
        {
            this.Health = this.Health + Protection - value;
            return value;
        }
        public override int Attack(Enemy enemy)
        {
            if (this.Rage < 5)
            {
                Console.WriteLine("Недостаточно ярости.");
                Console.WriteLine("Подсказка: Чтобы восстановить ярость в размере 5 единиц, нужно пропустить ход.");
                return Rage;

            }
            else
            {
                this.Rage = Rage - 10;
                return enemy.TakeDamage(AttackPower);
            }
           


        }
        public override int StrongAttack(Enemy enemy)
        {
                       
            if (this.Rage < 10)
            {
                Console.WriteLine("Недостаточно ярости.");
                Console.WriteLine("Подсказка: Чтобы восстановить ярость в размере 5 единиц, нужно пропустить ход.");
                return Rage;

            }
            else
            {
                this.Rage = Rage - 10;
                return enemy.TakeDamage(AttackPower * 2);
            }


            // чтобы восстановить ярость в размере 5 единиц, нужно пропустить ход.
        }
        public int RageRecovery()
        {   if (this.Rage < 50)
            {
                this.Rage = Rage + 5;
                return Rage; 
            }

            else
            {
                Console.WriteLine("Вам не требуется отдых для восстановления Ярости.");
                return Rage; 
            }
        }

    }
}
