using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PeregruzkaKonstruktorov
{
    public class Program
    {


        static void Main()
        {
            //var enemys = new List<Enemy>
            //{
            //    new Wolf()
            //    {
            //        Name = "Wolf"
            //    },
            //    new Ork()
            //    {
            //        Name = "Ork"
            //    },
            //    new Wolf()
            //    {
            //        Name = "Pizdabol"
            //    }
            //};


            #region OldCode
            Enemy wolf = new Wolf(1);
            Enemy enemy = new Enemy();
            Enemy ork = new Ork(10);
            StoryLine storyline = new StoryLine();
            BattleMechanics battleMechanics = new BattleMechanics();
            //battleMechanics.StartBattle(enemys);


            Console.Title = "Моя первая игра.";
            Console.WriteLine("Добро пожаловать в игру!");
            Console.WriteLine("Выберите класс, которым хотите начать играть.");
            Console.WriteLine("Доступные классы:" +
                "\nWarrior - Воин имеющий атаки ближнего боя" +
                "\nHawkeye - Лучник имеющий атаки дальнего боя" +
                "\nWizard - Волшебник имеющий атаки дальнего боя");
            Console.WriteLine("Кем вы хотите играть?");

            switch (Console.ReadLine())
            {
                case "Warrior":
                    Console.Write("Введите ваш НикНейм: ");
                    Warrior warrior = new Warrior(Console.ReadLine(), 1);
                    Console.WriteLine("Вы выбрали Воина.");
                    Console.WriteLine($"{warrior.MyFulllName()}");
                    battleMechanics.StartBattleWolf(wolf, warrior);
                    StoryLine.InTheForest(wolf, enemy, battleMechanics, warrior);
                    battleMechanics.StartBattleOrk(ork, warrior);
                    StoryLine.InTheCave(ork, enemy, battleMechanics, warrior);

                    break;

                case "Hawkeye":

                    Console.Write("Введите ваш НикНейм: ");
                    Hawkeye hawkeye = new Hawkeye(Console.ReadLine(), 1);
                    Console.WriteLine("Вы выбрали Лучника.");
                    Console.WriteLine($"{hawkeye.MyFulllName()}");
                    battleMechanics.StartBattleWolf(wolf, hawkeye);
                    StoryLine.InTheForest(wolf, enemy, battleMechanics, hawkeye);
                    battleMechanics.StartBattleOrk(ork, hawkeye);
                    StoryLine.InTheCave(ork, enemy, battleMechanics, hawkeye);
                    break;

                case "Wizard":
                    Console.WriteLine("Вы выбрали Волшебника.");
                    Console.Write("Введите ваш НикНейм: ");
                    Wizard wizard = new Wizard(Console.ReadLine(), 1);
                    Console.WriteLine("Вы выбрали Волшебника.");
                    Console.WriteLine($"{wizard.MyFulllName()}");
                    battleMechanics.StartBattleWolf(wolf, wizard);
                    StoryLine.InTheForest(wolf, enemy, battleMechanics, wizard);
                    battleMechanics.StartBattleOrk(ork, wizard);
                    StoryLine.InTheCave(ork, enemy, battleMechanics, wizard);
                    break;

                    // создать отдельные методы поведения боя с противниками.
                    // метод стартбатл появления противников.

            }
            #endregion
            Console.ReadLine();
        }

        //public static void StartBattle(IEnumerable<Enemy> enemy, IEnumerable<Player> player)
        //{
        //    Console.WriteLine("На локацию попали следующие игроки: ");
        //    foreach (var _player in player)
        //    {
        //        Console.WriteLine($"{_player.Name} | {_player.GetType().Name}");
        //    }
        //    Console.WriteLine("На локации следующие враги: ");
        //    foreach (var _enemy in enemy)
        //    {
        //        Console.WriteLine($"{_enemy.Name} | {_enemy.GetType().Name}");
        //    }
        //    var count = player.Count();
        //    Console.ReadLine();
        //}

    }
}










