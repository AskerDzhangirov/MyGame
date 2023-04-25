using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class Wolf : Enemy
    {

        public new int Jerk { get; private set; } = 2;
    
        public Wolf() { }
        public Wolf(int level, int jerk) : base(level)
        {
            Jerk = jerk;
            
        }

        public Wolf(int level) : base(level)
        {
            SetLevel(level);
        }

       
        public override string EnemyName()
        {
            this.Name = "Wolf";
            return this.Name;
        }
        
        public override int EnemyActiveAbility(Player player)
        {
            return player.GetCloser(Jerk);

           
        }
        //public override int EnemyPassiveAbility(Player player)
        //{
        //    Random random = new Random();
        //    int chance = random.Next(0, 100);
        //    //Console.WriteLine($"Рандом: {chance}");
        //    return chance;
        //}

    }
}
