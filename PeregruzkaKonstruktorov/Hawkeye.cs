using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class Hawkeye : Player
    {
        public  int Evasion { get; private set; } 
        public int Energy { get; private set; } = 100;
        
        public Hawkeye(string nickname, int level, int evasion, int energy) : base(nickname, level) 
        {
            Evasion = evasion;
            Energy = energy;
        }

        public Hawkeye(string nickname, int level) : base(nickname, level)
        {
            SetEnergy(level);
            SetLevel(level);
            SetNickName(nickname);

        }
        public int SetEvasion()
        {
            Random random = new Random();
            int chance = random.Next(0, 100);
            //Console.WriteLine($"Рандом: {chance}");
            return chance;
            
        }
            
            
            
        public override int TakeDamage(int value)
        {
            this.Health -= value;
            return value;
        }



        public void SetEnergy(int value)
        {
            this.Level = value;
            Energy = value * Energy;

        }
        public override string MyFulllName()
        {
            return "\n" + "Ваш Никнейм: " + NickName + "\n" + "Ваш уровень: " + Level + "\n"
                + "Ваше здоровье:" + Health + "\n" + "Ваша ярость:"
                + Energy + "\n";

        }

        public override int Attack(Enemy enemy)
        {
            if (this.Energy < 5)
            {
                Console.WriteLine("Недостаточно энергии.");
                Console.WriteLine("Подсказка: Чтобы восстановить энергию в размере 5 единиц, нужно пропустить ход.");
                return Energy;

            }
            else
            {
                this.Energy = Energy - 10;
                return enemy.TakeDamage(AttackPower);
            }



        }
        public override int StrongAttack(Enemy enemy)
        {

            if (this.Energy < 10)
            {
                Console.WriteLine("Недостаточно энергии.");
                Console.WriteLine("Подсказка: Чтобы восстановить энергию в размере 5 единиц, нужно пропустить ход.");
                return Energy;

            }
            else
            {
                this.Energy = Energy - 10;
                return enemy.TakeDamage(AttackPower * 2);
            }


            // чтобы восстановить ярость в размере 5 единиц, нужно пропустить ход.
        }
        public int EnergyRecovery()
        {
            if (this.Energy < 50)
            {
                this.Energy = Energy + 5;
                return Energy;
            }

            else
            {
                Console.WriteLine("Вам не требуется отдых для восстановления Ярости.");
                return Energy;
            }
        }
        
    }
}
