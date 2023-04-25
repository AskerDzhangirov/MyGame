using System;
using System.Collections;
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



        //class MeleeEnemies
        //{
        //    private List<Enemy> enemy = new List<Enemy>();

        //    public IEnumerable<string> Ability()
        //    {
        //        return new List<string>();

        //    }
        //}
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
        
       
      
        //дситанция значение чтобы бралось отсюда.
        // передать дистанцию в класс.

        public void StartBattleWolf(Enemy enemy, Player player)
        {         
            if (enemy is Wolf wolf)
            {
                Console.WriteLine($"Перед вами появился {enemy.EnemyName()}");
            }                     
            if(player is Warrior warrior)
            {
                Console.WriteLine($"В битву вступает воин {warrior.NickName}");
            }
            if(player is Hawkeye hawkeye)
            {
                Console.WriteLine($"В битву вступает лучник {hawkeye.NickName}");
            }
            if(player is Wizard wizard)
            {
                Console.WriteLine($"В битву вступает волшебник {wizard.NickName}");  
            }
            player.GetType();
            
            while (enemy.GetStatus() >= 0 || player.GetStatus() >= 0)
            {
                Console.WriteLine($"Ударить {enemy.Name} Y/N");
                if (IsCorrectSymbolY())
                {
                    Console.WriteLine($"Ударить {enemy.Name} сильной атакой(Y) или обычной атакой(N)? Y/N");
                    if (IsCorrectSymbolY())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.Name} ровняется: {player.StrongAttack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.Name} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            InBattle(enemy, player);
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
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.Name} ровняется: {player.Attack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.Name} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            InBattle(enemy, player);
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
                    if (IsCorrectSymbolY())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вы восстанавливаете Энергию.Ваша Энергия ровняется: {player.AbilityActive()}");
                        InBattle(enemy, player);
                    }                       
                    else
                    {
                        Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
                        break;
                    }
                }
            }
        }
        public void StartBattleOrk(Enemy enemy, Player player)
        {
            if (enemy is Ork ork)
            {
                Console.WriteLine($"Перед вами появился {enemy.EnemyName()}");
            }
            if (player is Warrior warrior)
            {
                Console.WriteLine($"В битву вступает воин {warrior.NickName}");              
            }
            if (player is Hawkeye hawkeye)
            {
                Console.WriteLine($"В битву вступает лучник {hawkeye.NickName}");              
            }
            if (player is Wizard wizard)
            {
                Console.WriteLine($"В битву вступает волшебник {wizard.NickName}");
            }          
            while (enemy.GetStatus() >= 0 || player.GetStatus() >= 0)
            {
                Console.WriteLine($"Ударить {enemy.Name} Y/N");

                if (IsCorrectSymbolY())
                {
                    Console.WriteLine($"Ударить {enemy.Name} сильной атакой(Y) или обычной атакой(N)? Y/N");
                    if (IsCorrectSymbolY())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.Name} ровняется: {player.StrongAttack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.Name} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            InBattle(enemy, player);
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
                        Console.WriteLine($"Нанесеный урон по врагу: {enemy.Name} ровняется: {player.Attack(enemy)} ед. урона");
                        if (enemy.GetStatus() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Здоровье {enemy.Name} ровняется: {enemy.GetStatus()}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            InBattle(enemy, player);
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
                    if (IsCorrectSymbolY())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вы восстанавливаете Энергию. Ваша Энергия ровняется: {player.AbilityActive()}");
                        InBattle(enemy, player);
                    }
                    else
                    {
                        Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
                        break;
                    }
                }
            }
        }
        private void InBattle(Enemy enemy, Player player)
        {
            if (player is Hawkeye)
            {
                Console.WriteLine("<Лучник может уклониться.>");
                if (player.DistancePlayer() != 0)
                {
                    Console.WriteLine($"{enemy.Name} делает шаг");
                    Console.WriteLine($"Сделано шагов {enemy.EnemyActiveAbility(player)} осталось шагов: {player.DistancePlayer()}");
                }          
                if (player.DistancePlayer() <= 0)
                {
                    Console.WriteLine($"{enemy.Name} находится рядом");
                    if (player.AbilityAPassive() <= 30)
                    {
                        Console.WriteLine("Вы уклонились от Атаки.");                      
                    }
                    else
                    {
                        if(enemy.EnemyPassiveAbility(player) <= 50)
                        {
                            Console.WriteLine($"{enemy.Name} нанес удар по вам." +
                            $"\nВы получили: {enemy.Attack(player)} ед.урона. " +
                            $"\nВаше здоровье ровняется: {player.GetStatus()} " +
                            $"\nВаша Энергия ровняется:{player.Power()}");
                            Console.WriteLine($"{enemy.Name} Вас оглушил.");
                            Console.WriteLine($"Вы пропускаете ход. {enemy.Name} атакует повторно. ");
                            Console.WriteLine("__________________________________________________");  
                        }
                        Console.WriteLine($"{enemy.Name} нанес удар по вам." +
                        $"\nВы получили: {enemy.Attack(player)} ед.урона. " +
                        $"\nВаше здоровье ровняется: {player.GetStatus()} " +
                        $"\nВаша Энергия ровняется:{player.Power()}");                       
                    }
                }
            }
            else
            {
                if (player.DistancePlayer() != 0)
                {                  
                    Console.WriteLine($"{enemy.Name} делает рывок");
                    Console.WriteLine($"Сделано шагов {enemy.EnemyActiveAbility(player)} осталось шагов: {player.DistancePlayer()}");
                }
                if (player.DistancePlayer() <= 0)
                {
                    if (enemy.EnemyPassiveAbility(player) <= 50)
                    {
                        Console.WriteLine($"{enemy.Name} нанес удар по вам." +
                        $"\nВы получили: {enemy.Attack(player)} ед.урона. " +
                        $"\nВаше здоровье ровняется: {player.GetStatus()} " +
                        $"\nВаша Энергия ровняется:{player.Power()}");
                        Console.WriteLine($"{enemy.Name} Вас оглушил.");
                        Console.WriteLine($"Вы пропускаете ход. {enemy.Name} атакует повторно. ");
                        Console.WriteLine("__________________________________________________");
                    }
                    Console.WriteLine($"{enemy.Name} нанес удар по вам." +
                        $"\nВы получили:{enemy.Attack(player) - player.AbilityAPassive()} ед.урона. " +
                            $"\nВаше здоровье ровняется: {player.GetStatus()}" +
                            $"\nВаша Энергия ровняется:{player.Power()}");
                }
            }
        }
        #region
        //public void StartBattleWizard(Enemy enemy, Wizard wizard, Player player)
        //{
        //    bool laststep = true;

        //    while (enemy.GetStatus() >= 0 || wizard.GetStatus() >= 0)
        //    {
        //        Console.WriteLine($"Ударить {enemy.GetName()} уровень врага {enemy.GetLevel()} Y/N"); // волк идет во всех ссылках в сторилайн
        //        if (IsCorrectSymbolY())
        //        {
        //            Console.WriteLine($"Ударить Сильной атакой (Y) или обычной атакой(N)? Y/N");
        //            if (IsCorrectSymbolY())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {player.StrongAttack(enemy)} ед. урона");
        //                if (enemy.GetStatus() > 0)

        //                {
        //                    Console.ForegroundColor = ConsoleColor.Yellow;
        //                    Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    if (step != 5)
        //                    {
        //                        step++;
        //                        Console.WriteLine($"{enemy.GetName()} делает шаг.");
        //                        if (step < 5)
        //                        {
        //                            step += jerk;
        //                            Console.WriteLine($"{enemy.GetName()} делает рывок");
        //                            //Console.WriteLine(step + "шагов");
        //                        }

        //                        continue;
        //                    }
        //                    if (step >= 5 && laststep)
        //                    {
        //                        laststep = false;
        //                        Console.WriteLine($"{enemy.GetName()} сделал последний шаг.");
        //                        Console.WriteLine($"{enemy.GetName()} находится рядом с Вами.");
        //                        continue;
        //                    }
        //                    else if (step >= 5)
        //                    {

        //                        Console.WriteLine($"{enemy.GetName()} находится рядом с Вами.");
        //                        Console.WriteLine($"{enemy.GetName()} нанес удар по вам. \nВы получили: " +
        //                        $"{enemy.Attack(wizard) - wizard.Barrier} ед.урона. \nВаше здоровье ровняется: {wizard.GetStatus()}" +
        //                        $"\nВаша мана ровняется:{wizard.Mana}");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine();
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {wizard.Attack(enemy)} ед. урона");
        //                if (enemy.GetStatus() > 0)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Yellow;
        //                    Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    if (step != 5)

        //                    {
        //                        step++;
        //                        Console.WriteLine($"{enemy.GetName()} делает шаг.");
        //                        if (step < 5)
        //                        {
        //                            step += jerk;
        //                            Console.WriteLine($"{enemy.GetName()} делает рывок");
        //                            //Console.WriteLine(step + "шагов");
        //                        }
        //                        continue;
        //                    }
        //                    if (step == 5 && laststep)
        //                    {
        //                        laststep = false;
        //                        Console.WriteLine($"{enemy.GetName()} сделал последний шаг.");
        //                        Console.WriteLine($"{enemy.GetName()} находится рядом с Вами.");
        //                        continue;
        //                    }
        //                    else if (step == 5)
        //                    {
        //                        Console.WriteLine($"{enemy.GetName()} находится рядом с Вами.");
        //                        Console.WriteLine($"{enemy.GetName()} нанес удар по вам. \nВы получили: " +
        //                        $"{enemy.Attack(wizard) - wizard.Barrier} ед.урона. \nВаше здоровье ровняется: {wizard.GetStatus()}" +
        //                        $"\nВаша мана ровняется:{wizard.Mana}");

        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine();
        //                    break;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            Console.WriteLine("Пропустить ход(Y) или избежать боя(N)? Y/N");
        //            if (IsCorrectSymbolY())
        //                Console.ForegroundColor = ConsoleColor.Red;
        //            {
        //                if (step != 5)

        //                {
        //                    step++;
        //                    Console.WriteLine($"{enemy.GetName()} делает шаг.");
        //                    if (step < 5)
        //                    {
        //                        step += jerk;
        //                        Console.WriteLine($"{enemy.GetName()} делает рывок");
        //                        //Console.WriteLine(step + "шагов");
        //                    }
        //                    continue;
        //                }
        //                if (step == 5 && laststep)
        //                {
        //                    laststep = false;
        //                    Console.WriteLine($"{enemy.GetName()} сделал последний шаг.");
        //                    Console.WriteLine($"{enemy.GetName()} находится рядом с Вами.");
        //                    continue;
        //                }
        //                else if (step == 5)
        //                {
        //                    Console.WriteLine($"{enemy.GetName()} находится рядом с Вами.");

        //                    Console.WriteLine($"{enemy.GetName()} нанес удар по вам. " +
        //                        $"\nВы получили: {enemy.Attack(wizard) - wizard.Barrier} ед.урона. " +
        //                        $"\nВаше здоровье ровняется: {wizard.GetStatus()}");
        //                    Console.WriteLine($"Ваша Ярость ровняется: {wizard.AbilityActive()}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
        //                    break;
        //                }
        //            }
        //        }

        //    }

        //}
        //public void StartBattleWarrior(Enemy enemy, Warrior warrior, Player player)
        //{
        //    while (enemy.GetStatus() >= 0 || warrior.GetStatus() >= 0)
        //    {


        //        Console.WriteLine("Ударить волка? Y/N");

        //        if (IsCorrectSymbolY())
        //        {
        //            Console.WriteLine("Ударить Волка сильной атакой(Y) или обычной атакой(N)? Y/N");
        //            if (IsCorrectSymbolY())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {player.StrongAttack(enemy)} ед. урона");
        //                if (enemy.GetStatus() > 0)

        //                {
        //                    Console.ForegroundColor = ConsoleColor.Yellow;
        //                    Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.WriteLine($"Wolf нанес ответный удар по вам. \nВы получили: " +
        //                        $"{enemy.Attack(warrior) - warrior.Protection} ед.урона. \n" +
        //                        $"Ваше здоровье ровняется: {warrior.GetStatus()}" +
        //                        $"\nВаша ярость ровняется:{warrior.Rage}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine();
        //                    break;
        //                }

        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {player.Attack(enemy)} ед. урона");
        //                if (enemy.GetStatus() > 0)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Yellow;
        //                    Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.WriteLine($"Wolf нанес ответный удар по вам. " +
        //                        $"\nВы получили: {enemy.Attack(warrior) - warrior.Protection} ед.урона. " +
        //                        $"\nВаше здоровье ровняется: {warrior.GetStatus()} \nВаша ярость ровняется:{warrior.Rage}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine();
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Пропустить ход(Y) или избежать боя(N)? Y/N");
        //            if (IsCorrectSymbolY())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine($"Wolf нанес удар по вам. " +
        //                    $"\nВы получили: {enemy.Attack(warrior) - warrior.AbilityAPassive()} ед.урона. " +
        //                    $"\nВаше здоровье ровняется: {warrior.GetStatus()}");
        //                Console.WriteLine($"Ваша Ярость ровняется: {warrior.AbilityActive()}");
        //                //прописать восстановление ярости как у хавка.
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
        //                break;
        //            }
        //        }
        //    }
        //}
        //public void StartBattleHawkeye(Enemy enemy, Hawkeye hawkeye, Player player)
        //{
        //    bool laststep = true;
        //    int step = 1;
        //    while (enemy.GetStatus() >= 0 || hawkeye.GetStatus() >= 0)
        //    {
        //        Console.WriteLine("Ударить волка? Y/N");
        //        if (IsCorrectSymbolY())
        //        {
        //            Console.WriteLine("Ударить Волка сильной атакой(Y) или обычной атакой(N)? Y/N");
        //            if (IsCorrectSymbolY())
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {player.StrongAttack(enemy)} ед. урона");
        //                if (enemy.GetStatus() > 0)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Yellow;
        //                    Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    if (step != 5)

        //                    {
        //                        step++;
        //                        Console.WriteLine("Волк делает шаг.");
        //                        if (step < 5)
        //                        {
        //                            step += jerk;
        //                            Console.WriteLine($"{enemy.GetName()} делает рывок");
        //                            //Console.WriteLine(step + "шагов");
        //                        }
        //                        continue;


        //                    }
        //                    if (step == 5 && laststep)
        //                    {
        //                        laststep = false;
        //                        Console.WriteLine("Волк сделал последний шаг.");
        //                        Console.WriteLine("Волк находится рядом с Вами.");
        //                        continue;
        //                    }

        //                    else if (step == 5)
        //                    {
        //                        Console.WriteLine("Волк находится рядом с Вами.");


        //                        if (player.AbilityAPassive() <= 30)
        //                        {
        //                            Console.WriteLine("Вы уклонились от Атаки.");
        //                            if (step < 5)
        //                            {
        //                                step += jerk;
        //                                Console.WriteLine($"{enemy.GetName()} делает рывок");
        //                                //Console.WriteLine(step + "шагов");
        //                            }
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Wolf нанес ответный удар по вам." +
        //                            $"\nВы получили: {enemy.Attack(hawkeye)} ед.урона. " +
        //                            $"\nВаше здоровье ровняется: {hawkeye.GetStatus()} " +
        //                            $"\nВаша Энергия ровняется:{player.AbilityActive()}");
        //                            continue;
        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    Console.WriteLine();
        //                    break;
        //                }

        //            }
        //            else
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"Нанесеный урон по врагу: {enemy.GetName()} ровняется: {player.Attack(enemy)} ед. урона");
        //                if (enemy.GetStatus() > 0)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Yellow;
        //                    Console.WriteLine($"Здоровье {enemy.GetName()} ровняется: {enemy.GetStatus()}");
        //                    Console.ForegroundColor = ConsoleColor.Red;

        //                    if (step != 5)

        //                    {
        //                        step++;
        //                        Console.WriteLine("Волк делает шаг.");
        //                        continue;


        //                    }
        //                    if (step == 5 && laststep)
        //                    {
        //                        laststep = false;
        //                        Console.WriteLine("Волк сделал последний шаг.");
        //                        Console.WriteLine("Волк находится рядом с Вами.");
        //                        continue;
        //                    }

        //                    else if (step == 5)
        //                    {
        //                        Console.WriteLine("Волк находится рядом с Вами.");

        //                        if (player.AbilityAPassive() <= 30)
        //                        {
        //                            Console.WriteLine("Вы уклонились от Атаки.");

        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Wolf нанес ответный удар по вам." +
        //                                $"\nВы получили: {enemy.Attack(hawkeye)} ед.урона. " +
        //                                $"\nВаше здоровье ровняется: {hawkeye.GetStatus()} " +
        //                                $"\nВаша Энергия ровняется:{player.AbilityActive()}");
        //                        }



        //                    }
        //                }
        //            }
        //        }

        //        else
        //            Console.WriteLine("Пропустить ход(Y) или избежать боя(N)? Y/N");
        //        if (IsCorrectSymbolY())
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            if (step != 5)

        //            {
        //                step++;
        //                Console.WriteLine("Волк делает шаг.");
        //                if (step < 5)
        //                {
        //                    step += jerk;
        //                    Console.WriteLine($"{enemy.GetName()} делает рывок");
        //                    //Console.WriteLine(step + "шагов");
        //                }
        //                continue;
        //            }
        //            if (step == 5 && laststep)
        //            {
        //                laststep = false;
        //                Console.WriteLine("Волк сделал последний шаг.");
        //                Console.WriteLine("Волк находится рядом с Вами.");
        //                continue;
        //            }

        //            else if (step == 5)
        //            {
        //                Console.WriteLine("Волк находится рядом с Вами.");
        //                if (player.AbilityAPassive() <= 30)
        //                {
        //                    Console.WriteLine("Вы уклонились от Атаки.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Wolf нанес ответный удар по вам." +
        //                        $"\nВы получили: {enemy.Attack(hawkeye)} ед.урона. " +
        //                        $"\nВаше здоровье ровняется: {hawkeye.GetStatus()} " +
        //                        $"\nВаша Энергия ровняется:{player.AbilityActive()}");
        //                }
        //                Console.WriteLine($"Ваша Энергия ровняется: {player.AbilityActive()}");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Вы убегаете от {enemy.GetName()}");
        //                break;
        //            }
        //        }
        //    }
        //}
        //public void StartBattlePlayer(Enemy enemy, Player player)
        //{
        //    switch (player)
        //    {
        //        case Warrior warrior:
        //            StartBattleWarrior(enemy, (Warrior)player, (Player)warrior);
        //            break;
        //        case Hawkeye hawkeye:
        //            StartBattleHawkeye(enemy, (Hawkeye)player, (Player)hawkeye);
        //            break;
        //        case Wizard wizard:
        //            StartBattleWizard(enemy, (Wizard)player, (Player)wizard);
        //            break;
        //        default:
        //            Console.WriteLine("xyeta");
        //            break;
        //    }
        //}
        #endregion


        public void StartBattle(IEnumerable<Enemy> enemy)
        {
            var enemys = new List<Enemy>
            {
                new Wolf()
                {
                    Name = "Серый волк"
                },
                new Ork()
                {
                    Name = "Биба"
                },
                new Wolf()
                {
                    Name = "Черный волк"
                }
            };
            
           
            Console.WriteLine("На локации следующие враги: ");
            foreach (var _enemy in enemy)
            {
                Console.WriteLine($"{_enemy.Name} | {_enemy.GetType().Name}");
            }
           
            Console.ReadLine();
        }
    } 
}



    


        // создание врага орка со способностью оглушать, игрок прпопускает один ход. 
        // создание листа с врагом.



    















