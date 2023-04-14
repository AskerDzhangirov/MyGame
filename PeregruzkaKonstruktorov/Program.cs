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
            Enemy enemy = new Enemy("Wolf", 10);

            BattleMechanics battleMechanics = new BattleMechanics();
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
                    battleMechanics.StartBattlePlayer(enemy, warrior);

                    Console.WriteLine("Идем дальше? Y/N");
                    if (Console.ReadLine() == "Y")
                    {
                        Console.WriteLine("Вы идете по тропе в глубь леса...");
                    }
                    else if (enemy.GetStatus() <= 0)
                    {

                        Console.WriteLine("Вы идете по тропе в глубь леса...");
                    }
                    else
                    {
                        battleMechanics.StartBattlePlayer(enemy, warrior);
                    }

                    break;
                case "Hawkeye":

                    Console.WriteLine("Вы выбрали Лучника.");
                    Console.Write("Введите ваш НикНейм: ");
                    Hawkeye hawkeye = new Hawkeye(Console.ReadLine(), 1);
                    Console.WriteLine("Вы выбрали Лучника.");
                    Console.WriteLine($"{hawkeye.MyFulllName()}");
                    battleMechanics.StartBattlePlayer(enemy, hawkeye);

                    Console.WriteLine("Идем дальше? Y/N");
                    if (Console.ReadLine() == "Y")
                    {
                        Console.WriteLine("Вы идете по тропе в глубь леса...");
                    }
                    else if (enemy.GetStatus() <= 0)
                    {

                        Console.WriteLine("Вы идете по тропе в глубь леса...");
                    }
                    else
                    {
                        battleMechanics.StartBattlePlayer(enemy, hawkeye);
                    }
                    Console.ReadLine();

                    break;
                case "Wizard":
                    Console.WriteLine("Вы выбрали Волшебника.");
                    Console.Write("Введите ваш НикНейм: ");
                    Wizard wizard = new Wizard(Console.ReadLine(), 1);
                    Console.WriteLine("Вы выбрали Волшебника.");
                    Console.WriteLine($"{wizard.MyFulllName()}");
                    battleMechanics.StartBattlePlayer(enemy, wizard);

                    Console.WriteLine("Идем дальше? Y/N");
                    if (Console.ReadLine() == "Y")
                    {
                        Console.WriteLine("Вы идете по тропе в глубь леса...");
                    }
                    else if (enemy.GetStatus() <= 0)
                    {

                        Console.WriteLine("Вы идете по тропе в глубь леса...");
                    }
                    else
                    {
                        battleMechanics.StartBattlePlayer(enemy, wizard);
                    }
                    Console.ReadLine();
                    break;
            //        сделать волшебника. Продумать механику дальнего боя у лучника и волшебника, примерно 3 хода пропускает волк, чтобы ударить игрока.
            //расмотреть вариант уменьшения кода и модификация его.
            //разделить сюжетные линии игроков в зависимости от выбора персонажа.

            }







            Console.ReadLine();
        }
    }
}










