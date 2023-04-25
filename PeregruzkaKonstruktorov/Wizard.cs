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
        public int Space { get; private set; } = 5;
        public new int Distance { get; private set; } = 4;
       
        public Wizard()
        {

        }
        public Wizard(string nickname, int level, int barrier, int mana, int distance) :base(nickname, level, distance)
        {
            Barrier = barrier;
            Mana = mana;
            Distance = distance;

        }
        public Wizard(string nickname, int level) :base (nickname, level)  
        {
            SetLevel(level);
            SetMana(level);
            SetNickName(nickname);
            
        }
        public override int GetCloser(int value)
        {

            this.Distance -= value;
            return value;
        }
        public override int DistancePlayer()
        {
            
            return this.Distance;
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
                this.Mana = Mana - 5;
                return enemy.TakeDamage(AttackPower);
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
                return enemy.TakeDamage(AttackPower * 2);
            }
            
        }
        public override int AbilityActive()
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
        public override int AbilityAPassive()
        {
            Barrier = this.Level * Barrier;
            return Barrier;
        }
        public override int Power()
        {
            return this.Mana;
        }
    }
}
