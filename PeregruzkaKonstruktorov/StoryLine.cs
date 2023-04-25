using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class StoryLine
    {
        // сделать лес и пещеру для других классов.
        public static void StoryLineWarrior(Enemy wolf, Enemy enemy, Enemy ork, BattleMechanics battleMechanics, Player player)
        {
            InTheForest(wolf, enemy, battleMechanics, (Warrior)player);
            InTheCave(ork, enemy, battleMechanics, (Warrior)player);
            
        }
        public static void StoryLineHawkeye(Enemy wolf, Enemy enemy, Enemy ork, BattleMechanics battleMechanics, Player player )
        {
            InTheForest(wolf, enemy, battleMechanics, (Hawkeye)player);
            InTheCave(ork, enemy, battleMechanics, (Hawkeye)player);

        }

        public static void InTheCave(Enemy enemy, Enemy ork, BattleMechanics battleMechanics, Player player)
        {
            Console.WriteLine("Идем дальше? Y/N");
            if (Console.ReadLine() == "Y")
            {
                Console.WriteLine("Вы выходите из пещеры обратно в лес...");
            }
            else if (enemy.GetStatus() <= 0)
            {

                Console.WriteLine("Вы выходите из пещеры обратно в лес...");
            }
            else
            {
                battleMechanics.StartBattleOrk(ork, (Player)player);
            }
        }

        public static void InTheForest(Enemy wolf, Enemy enemy, BattleMechanics battleMechanics, Player player)
        {
            Console.WriteLine("Идем дальше? Y/N");
            if (Console.ReadLine() == "Y")
            {
                Console.WriteLine("Вы идете по тропе в глубь леса...");
                Console.WriteLine("Вы видите огромную пещеру.");
                Console.WriteLine("Вы заходите в огромную пещеру.");
                
            }
            else if (enemy.GetStatus() <= 0)
            {

                Console.WriteLine("Вы идете по тропе в глубь леса...");
                Console.WriteLine("Вы видите огромную пещеру.");
                Console.WriteLine("Вы заходите в огромную пещеру.");
            }
            else
            {
                battleMechanics.StartBattleWolf(wolf, (Player)player);
            }
        }

        public static void StoryLineWizard(Enemy wolf, Enemy enemy, Enemy ork, BattleMechanics battleMechanics, Player player)
        {
            InTheForest(wolf, enemy, battleMechanics, (Wizard)player);
            InTheCave(ork, enemy, battleMechanics, (Wizard)player);
        }
           
        
    }
}
