using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeregruzkaKonstruktorov
{
    public class BattleMechanics
    {

        public bool IsCorrectSymbolN()
        {
            Console.WriteLine("Вы подтверждаете свое решение? Y/N ");
            switch (Console.ReadLine().ToLower())
            {
                case "y": return true;
                case "n": return false;

                default: Console.WriteLine("Неверный символ! Попробуйте еще раз."); return false;

            }
        }
        public bool IsCorrectSymbolY()
        {
            switch (Console.ReadLine().ToLower())
            {
                case "y": return true;
                case "n": return false;
                default: Console.WriteLine("Неверный символ! Попробуйте еще раз."); return false;

            }
        }
        public void StartBattleWizard(Enemy enemy, Wizard wizard)
        {
            bool laststep = true;
            int step = 1;
            while (enemy.GetStatus() >= 0 || wizard.GetStatus() >= 0)
            {


                Console.WriteLine("Ударить волка? Y/N");
                string yes = "y";
                string no = "n";
                no.ToLower();
                yes.ToLower();
                if (Console.ReadLine() == yes.ToLower())
                {
                    Console.WriteLine("Ударить Волка сильной атакой(Y) или обычной атакой(N)? Y/N");
                    if (Console.ReadLine() == yes.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {wizard.StrongAttack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)

                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (step != 3)

                            {
                                step++;
                                Console.WriteLine("Волк делает шаг.");
                                continue;
                            }
                            if (step == 3 && laststep)
                            {
                                laststep = false;
                                Console.WriteLine("Волк сделал последний шаг.");
                                Console.WriteLine("Волк находится рядом с Вами.");
                                continue;
                            }
                            else if (step == 3)
                            {

                                Console.WriteLine("Волк находится рядом с Вами.");
                                Console.WriteLine($"Wolf нанес удар по вам. \nВы получили: " +
                                $"{enemy.Attack(wizard) - wizard.Barrier} ед.урона. \nВаше здоровье ровняется: {wizard.GetStatus()}" +
                                $"\nВаша мана ровняется:{wizard.Mana}");
                            }
                            else
                            {
                                Console.WriteLine();
                                break;
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {wizard.Attack(enemy)} ед. урона");
                            if (enemy.GetStatus() > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                if (step != 3)

                                {
                                    step++;
                                    Console.WriteLine("Волк делает шаг.");
                                    continue;
                                }
                                if (step == 3 && laststep)
                                {
                                    laststep = false;
                                    Console.WriteLine("Волк сделал последний шаг.");
                                    Console.WriteLine("Волк находится рядом с Вами.");
                                    continue;
                                }
                                else if (step == 3)
                                {
                                    Console.WriteLine("Волк находится рядом с Вами.");
                                    Console.WriteLine($"Wolf нанес удар по вам. \nВы получили: " +
                                    $"{enemy.Attack(wizard) - wizard.Barrier} ед.урона. \nВаше здоровье ровняется: {wizard.GetStatus()}" +
                                    $"\nВаша мана ровняется:{wizard.Mana}");

                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пропустить ход(Y) или избежать боя(N)? Y/N");
                        if (Console.ReadLine() == yes.ToLower())
                            Console.ForegroundColor = ConsoleColor.Red;
                        {
                            if (step != 3)

                            {
                                step++;
                                Console.WriteLine("Волк делает шаг.");
                                continue;
                            }
                            if (step == 3 && laststep)
                            {
                                laststep = false;
                                Console.WriteLine("Волк сделал последний шаг.");
                                Console.WriteLine("Волк находится рядом с Вами.");
                                continue;
                            }
                            else if (step == 3)
                            {
                                Console.WriteLine("Волк находится рядом с Вами.");

                                Console.WriteLine($"Wolf нанес удар по вам. " +
                                    $"\nВы получили: {enemy.Attack(wizard) - wizard.Barrier} ед.урона. " +
                                    $"\nВаше здоровье ровняется: {wizard.GetStatus()}");
                                Console.WriteLine($"Ваша Ярость ровняется: {wizard.ManaRecovery()}");
                            }
                            else
                            {
                                Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
                                break;
                            }
                        }
                    }
                }

            }
          
        }
        public void StartBattleWarrior(Enemy enemy, Warrior warrior)
        {
            while (enemy.GetStatus() >= 0 || warrior.GetStatus() >= 0)
            {


                Console.WriteLine("Ударить волка? Y/N");
                string yes = "y";
                string no = "n";
                no.ToLower();
                yes.ToLower();
                if (Console.ReadLine() == yes.ToLower())
                {
                    Console.WriteLine("Ударить Волка сильной атакой(Y) или обычной атакой(N)? Y/N");
                    if (Console.ReadLine() == yes.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {warrior.StrongAttack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)

                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Wolf нанес ответный удар по вам. \nВы получили: " +
                                $"{enemy.Attack(warrior) - warrior.Protection} ед.урона. \nВаше здоровье ровняется: {warrior.GetStatus()}" +
                                $"\nВаша ярость ровняется:{warrior.Rage}");
                        }
                        else
                        {
                            Console.WriteLine();
                            break;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {warrior.Attack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Wolf нанес ответный удар по вам. " +
                                $"\nВы получили: {enemy.Attack(warrior) - warrior.Protection} ед.урона. " +
                                $"\nВаше здоровье ровняется: {warrior.GetStatus()} \nВаша ярость ровняется:{warrior.Rage}");
                        }
                        else
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Пропустить ход(Y) или избежать боя(N)? Y/N");
                    if (Console.ReadLine() == yes.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Wolf нанес удар по вам. " +
                            $"\nВы получили: {enemy.Attack(warrior) - warrior.Protection} ед.урона. " +
                            $"\nВаше здоровье ровняется: {warrior.GetStatus()}");
                        Console.WriteLine($"Ваша Ярость ровняется: {warrior.RageRecovery()}");
                    }
                    else
                    {
                        Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
                        break;
                    }
                }
            }
        }
        public void StartBattleHawkeye(Enemy enemy, Hawkeye hawkeye)
        {
            bool laststep = true;
            int step = 1;
            while (enemy.GetStatus() >= 0 || hawkeye.GetStatus() >= 0)
            {
                Console.WriteLine("Ударить волка? Y/N");
                if (IsCorrectSymbolY())
                {
                    Console.WriteLine("Ударить Волка сильной атакой(Y) или обычной атакой(N)? Y/N");
                    if (IsCorrectSymbolY())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {hawkeye.StrongAttack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (step != 3)

                            {
                                step++;
                                Console.WriteLine("Волк делает шаг.");
                                continue;


                            }
                            if (step == 3 && laststep)
                            {
                                laststep = false;
                                Console.WriteLine("Волк сделал последний шаг.");
                                Console.WriteLine("Волк находится рядом с Вами.");
                                continue;
                            }

                            else if (step == 3)
                            {
                                Console.WriteLine("Волк находится рядом с Вами.");


                                if (hawkeye.SetEvasion() <= 30)
                                {
                                    Console.WriteLine("Вы уклонились от Атаки.");
                                    continue;

                                }
                                else
                                {
                                    Console.WriteLine($"Wolf нанес ответный удар по вам." +
                                    $"\nВы получили: {enemy.Attack(hawkeye)} ед.урона. " +
                                    $"\nВаше здоровье ровняется: {hawkeye.GetStatus()} " +
                                    $"\nВаша Энергия ровняется:{hawkeye.Energy}");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                break;
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {hawkeye.Attack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;

                            if (step != 3)

                            {
                                step++;
                                Console.WriteLine("Волк делает шаг.");
                                continue;


                            }
                            if (step == 3 && laststep)
                            {
                                laststep = false;
                                Console.WriteLine("Волк сделал последний шаг.");
                                Console.WriteLine("Волк находится рядом с Вами.");
                                continue;
                            }

                            else if (step == 3)
                            {
                                Console.WriteLine("Волк находится рядом с Вами.");

                                if (hawkeye.SetEvasion() <= 30)
                                {
                                    Console.WriteLine("Вы уклонились от Атаки.");

                                }
                                else
                                {
                                    Console.WriteLine($"Wolf нанес ответный удар по вам." +
                                        $"\nВы получили: {enemy.Attack(hawkeye)} ед.урона. " +
                                        $"\nВаше здоровье ровняется: {hawkeye.GetStatus()} " +
                                        $"\nВаша Энергия ровняется:{hawkeye.Energy}");
                                }



                            }
                        }
                    }
                }

                else
                    Console.WriteLine("Пропустить ход(Y) или избежать боя(N)? Y/N");
                if (IsCorrectSymbolY())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (step != 3)

                    {
                        step++;
                        Console.WriteLine("Волк делает шаг.");
                        continue;


                    }
                    if (step == 3 && laststep)
                    {
                        laststep = false;
                        Console.WriteLine("Волк сделал последний шаг.");
                        Console.WriteLine("Волк находится рядом с Вами.");
                        continue;
                    }

                    else if (step == 3)
                    {
                        Console.WriteLine("Волк находится рядом с Вами.");
                        if (hawkeye.SetEvasion() <= 30)
                        {
                            Console.WriteLine("Вы уклонились от Атаки.");
                        }
                        else
                        {
                            Console.WriteLine($"Wolf нанес ответный удар по вам." +
                                $"\nВы получили: {enemy.Attack(hawkeye)} ед.урона. " +
                                $"\nВаше здоровье ровняется: {hawkeye.GetStatus()} " +
                                $"\nВаша Энергия ровняется:{hawkeye.Energy}");
                        }
                        Console.WriteLine($"Ваша Энергия ровняется: {hawkeye.EnergyRecovery()}");
                    }
                    else
                    {
                        Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
                        break;
                    }
                }
            }
        }

        public void StartBattlePlayer(Enemy enemy, Player player)
        {
            switch (player)
            {
                case Warrior warrior:
                    StartBattleWarrior(enemy, (Warrior)player);
                    break;
                case Hawkeye hawkeye:
                    StartBattleHawkeye(enemy, (Hawkeye)player);
                    break;
                case Wizard wizard:
                    StartBattleWizard(enemy, (Wizard)player);
                    break;
                default:
                    Console.WriteLine("xyeta");
                    break;
            }
        }
    }
}




    















