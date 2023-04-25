using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class Ork : Enemy
    {
        public int Stun { get; private set; }
        public new int Jerk { get; private set; } = 1;
       
        public Ork() { }
        public Ork(int level, int stun, int jerk)  :base(level)
        {
            Jerk = jerk; 
            Stun = stun;
            SetLevel(level);
        }
        public Ork(int level) : base(level)
        {
            SetLevel(level);
        }
        public override string EnemyName()
        {
            this.Name = "Ork";
            return this.Name;
        }
        public override int EnemyActiveAbility(Player player)
        {
            return player.GetCloser(Jerk);
        }
        public override int EnemyPassiveAbility(Player player)
        {
            Random random = new Random();
            int chance = random.Next(0, 100);
            //Console.WriteLine($"Рандом: {chance}");
            return chance;
        }


    }

}
