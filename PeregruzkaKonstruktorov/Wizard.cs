using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class Wizard : Player
    {
        public int Barrier { get; private set; } = 5;
        public int Mana { get; private set; } = 100;
        public Wizard(int barrier, int mana) 
        {
            Barrier = barrier;
            Mana = mana;

        }
        public Wizard(string nickname, int level) :base (nickname, level)  
        {
            SetLevel(level);
            SetMana(level);
            SetNickName(nickname);
        }
        public void SetMana(int value)
        {
            this.Level = value; 
            Mana = value * Mana;
        }
        public override int TakeDamage(int value)
        {
            this.Health = this.Health + Barrier - value;
            return value;
        }
        public override string MyFulllName()
        {
            return "\n" + "Ваш Никнейм: " + NickName + "\n" + "Ваш уровень: " + Level + "\n"
              + "Ваше здоровье:" + Health + "\n" +"Ваш барьер" + Barrier + "\n"+"Ваша мана:"
              + Mana + "\n";
        }
        public override int Attack(Enemy enemy)
        {
            if (this.Mana < 5)
            {
                Console.WriteLine("Недостаточно маны.");
                Console.WriteLine("Подсказка: Чтобы восстановить ману в размере 5 единиц, нужно пропустить ход.");
                return Mana;

            }
            else
            {
                this.Mana = Mana - 10;
                return enemy.TakeDamage(MagicAttackPower);
            }
        }
        public override int StrongAttack(Enemy enemy)
        {
            if (this.Mana < 10)
            {
                Console.WriteLine("Недостаточно маны.");
                Console.WriteLine("Подсказка: Чтобы восстановить ману в размере 5 единиц, нужно пропустить ход.");
                return Mana;

            }
            else
            {
                this.Mana = Mana - 10;
                return enemy.TakeDamage(MagicAttackPower * 2);
            }
            
        }
        public int ManaRecovery()
        {
            if (this.Mana < 50)
            {
                this.Mana = this.Mana = 5;
                return this.Mana;
            }
            else
            {
                Console.WriteLine("У вас достаточно маны.");
                return this.Mana;
            }
        }

    }
}
