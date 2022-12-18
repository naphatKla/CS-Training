using System;
using GI113_FinalProject.Objects;

namespace GI113_FinalProject.UI
{
    public static class Menu
    {
        public static Bar hpBar = new Bar("HP", ConsoleColor.Red);
        public static Bar mpBar= new Bar("MP", ConsoleColor.Blue);

        public static int SelectMenu(string[] options) // รับค่า String Array ( Option ที่จะแสดง )
        {
            int selectIndex = 0;
            ConsoleKey keyPress;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectIndex)
                    {
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (options[i].Length > 10)
                        {
                            Text.TextPrint($">>> {options[i]} <<<",0 ,false,false);
                        }
                        else
                        {
                            Text.TextPrint($">>> {options[i]} <<<",1 ,false,false);
                        }
                        //Console.WriteLine($">>> {options[i]} <<<");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($" {options[i]}");
                    }
                }
                
                while (true)
                {
                    keyPress = Console.ReadKey(true).Key;
                    
                    if (keyPress == ConsoleKey.UpArrow)
                    {
                        selectIndex--;
                    }
                    else if (keyPress == ConsoleKey.DownArrow)
                    {
                        selectIndex++;
                    }
                    else if (keyPress == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                    if (selectIndex > options.Length - 1)
                    {
                        selectIndex = options.Length - 1;
                    }
                    else if (selectIndex < 0)
                    {
                        selectIndex = 0;
                    }
                    else
                    {
                        break;
                    }
                }
                
                Text.ClearLine(options.Length);

            } while (keyPress != ConsoleKey.Enter);

            return selectIndex; // ส่งค่า Index ของ Option ที่ผู้เล่นเลือกออกไป
        }
        public static int SelectClass(string[] classes,ref Bar hpBar,ref Bar mpBar,ref Bar atkBar,ref Bar criBar) // รับค่า String Array ( Option ที่จะแสดง )
        {
            int selectIndex = 0;
            bool isPrint = true;
            bool firtPrint = true;
            ConsoleKey keyPress;
            Tank tank = new Tank();
            Support support = new Support();
            Carry carry = new Carry();
            int maxHpBar = 300;
            int maxMpBar = 270;
            int maxAtkBar = 116;
            int maxCriBar = 58;
            int hpDivisor = 10;
            int mpDivisor = 9;
            int atkDivisor = 4;
            int criDivisor = 2;
            int waitTime = 5;

            do
            {
                for (int i = 0; i < classes.Length; i++)
                {
                    if (classes[selectIndex] == "Tank" && isPrint)
                    {
                        if (firtPrint)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Text.TextPrint($" {tank.ClassDescription}",0,false);
                            Console.ResetColor();
                            Console.WriteLine();
                            hpBar.PrintBar(tank.Hp,maxHpBar,hpDivisor,waitTime);
                            Console.WriteLine();
                            mpBar.PrintBar(tank.Mp,maxMpBar,mpDivisor,waitTime);
                            Console.WriteLine();
                            atkBar.PrintBar(tank.Atk,maxAtkBar,atkDivisor,waitTime);
                            Console.WriteLine();
                            criBar.PrintBar(tank.CriRate,maxCriBar,criDivisor,waitTime);
                            Console.WriteLine("\n");
                            firtPrint = false;
                        }
                        else
                        {
                            Text.ClearLine(7);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Text.TextPrint($" {tank.ClassDescription}",0,false);
                            Console.ResetColor();
                            Console.WriteLine();
                            hpBar.PrintBar(tank.Hp,maxHpBar,hpDivisor,waitTime);
                            Console.WriteLine();
                            mpBar.PrintBar(tank.Mp,maxMpBar,mpDivisor,waitTime);
                            Console.WriteLine();
                            atkBar.PrintBar(tank.Atk,maxAtkBar,atkDivisor,waitTime);
                            Console.WriteLine();
                            criBar.PrintBar(tank.CriRate,maxCriBar,criDivisor,waitTime);
                            Console.WriteLine("\n");
                        }
                    }
                    else if (classes[selectIndex] == "Support" && isPrint)
                    {
                        Text.ClearLine(7);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Text.TextPrint($" {support.ClassDescription}",0,false);
                        Console.ResetColor();
                        Console.WriteLine();
                        hpBar.PrintBar(support.Hp,maxHpBar,hpDivisor,waitTime);
                        Console.WriteLine();
                        mpBar.PrintBar(support.Mp,maxMpBar,mpDivisor,waitTime);
                        Console.WriteLine();
                        atkBar.PrintBar(support.Atk,maxAtkBar,atkDivisor,waitTime);
                        Console.WriteLine();
                        criBar.PrintBar(support.CriRate,maxCriBar,criDivisor,waitTime);
                        Console.WriteLine("\n");
                    }
                    else if (classes[selectIndex] == "Carry" && isPrint)
                    {
                        Text.ClearLine(7);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Text.TextPrint($" {carry.ClassDescription}",0,false);
                        Console.ResetColor();
                        Console.WriteLine();
                        hpBar.PrintBar(carry.Hp,maxHpBar,hpDivisor,waitTime);
                        Console.WriteLine();
                        mpBar.PrintBar(carry.Mp,maxMpBar,mpDivisor,waitTime);
                        Console.WriteLine();
                        atkBar.PrintBar(carry.Atk,maxAtkBar,atkDivisor,waitTime);
                        Console.WriteLine();
                        criBar.PrintBar(carry.CriRate,maxCriBar,criDivisor,waitTime);
                        Console.WriteLine("\n");
                    }
                    else if (classes[selectIndex] == "Random" && isPrint)
                    {
                        Text.ClearLine(7);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\n");
                        Text.TextPrint(" Random your class. Good Luck XD",0,false);
                        Console.ResetColor();
                        Console.WriteLine("\n\n\n");
                    }
                    isPrint = false;

                    if (i == selectIndex)
                    {
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (classes[i].Length > 10)
                        {
                            Text.TextPrint($">>> {classes[i]} <<<",0 ,false,false);
                        }
                        else
                        {
                            Text.TextPrint($">>> {classes[i]} <<<",1 ,false,false);
                        }
                        //Console.WriteLine($">>> {options[i]} <<<");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($" {classes[i]}");
                    }
                }
                
                while (true)
                {
                    keyPress = Console.ReadKey(true).Key;
                    
                    if (keyPress == ConsoleKey.UpArrow)
                    {
                        selectIndex--;
                    }
                    else if (keyPress == ConsoleKey.DownArrow)
                    {
                        selectIndex++;
                    }
                    else if (keyPress == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                    if (selectIndex > classes.Length - 1)
                    {
                        selectIndex = classes.Length - 1;
                    }
                    else if (selectIndex < 0)
                    {
                        selectIndex = 0;
                    }
                    else
                    {
                        isPrint = true;
                        break;
                    }
                }
                
                Text.ClearLine(classes.Length);

            } while (keyPress != ConsoleKey.Enter);

            return selectIndex; // ส่งค่า Index ของ Option ที่ผู้เล่นเลือกออกไป
        }
        
        public static int SelectSkill(string[] skills,ref Player player) // รับค่า String Array ( Option ที่จะแสดง )
        {
            int selectIndex = 0;
            ConsoleKey keyPress;
            bool isPrint = true;
            bool firtPrint = true;
            Tank tank = new Tank();
            Support support = new Support();
            Carry carry = new Carry();
            
            do
            {
                for (int i = 0; i < skills.Length; i++)
                {

                    if (selectIndex < player.Skills.Length)
                    {
                        if (player.Skills[selectIndex] == tank.Skills[selectIndex] &&  isPrint)
                        {
                            if (firtPrint)
                            {
                                player.SkillDescription(selectIndex);
                                Console.WriteLine("\n\n");
                                firtPrint = false;
                            }
                            else
                            {
                                Text.ClearLine(3);
                                player.SkillDescription(selectIndex);
                                Console.WriteLine("\n\n");
                            }
                        }
                        else if (player.Skills[selectIndex] == support.Skills[selectIndex] &&  isPrint)
                        {
                            if (firtPrint)
                            {
                                player.SkillDescription(selectIndex);
                                Console.WriteLine("\n\n");
                                firtPrint = false;
                            }
                            else
                            {
                                Text.ClearLine(3);
                                player.SkillDescription(selectIndex);
                                Console.WriteLine("\n\n");
                            }
                        }
                        else if (player.Skills[selectIndex] == carry.Skills[selectIndex] &&  isPrint)
                        {
                            if (firtPrint)
                            {
                                player.SkillDescription(selectIndex);
                                Console.WriteLine("\n\n");
                                firtPrint = false;
                            }
                            else
                            {
                                Text.ClearLine(3);
                                player.SkillDescription(selectIndex);
                                Console.WriteLine("\n\n");
                            }
                        }
                    }
                    else if(isPrint)
                    {
                        if (firtPrint)
                        {
                            Text.TextPrint(" Go back 1  Page ...",0,false,true,false);
                            Console.WriteLine("\n\n");
                            firtPrint = false;
                        }
                        else
                        {
                            Text.ClearLine(3);
                            Text.TextPrint(" Go back 1  Page ...",0,false,true,false);
                            Console.WriteLine("\n\n");
                        }
                    }
                    

                    isPrint = false;

                    if (i == selectIndex)
                    {
                        Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (skills[i].Length > 10)
                        {
                            Text.TextPrint($">>> {skills[i]} <<<",0 ,false,false);
                        }
                        else
                        {
                            Text.TextPrint($">>> {skills[i]} <<<",1 ,false,false);
                        }
                        //Console.WriteLine($">>> {options[i]} <<<");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($" {skills[i]}");
                    }
                }
                
                while (true)
                {
                    keyPress = Console.ReadKey(true).Key;
                    
                    if (keyPress == ConsoleKey.UpArrow)
                    {
                        selectIndex--;
                    }
                    else if (keyPress == ConsoleKey.DownArrow)
                    {
                        selectIndex++;
                    }
                    else if (keyPress == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                    if (selectIndex > skills.Length - 1)
                    {
                        selectIndex = skills.Length - 1;
                    }
                    else if (selectIndex < 0)
                    {
                        selectIndex = 0;
                    }
                    else
                    {
                        isPrint = true;
                        break;
                    }
                }
                
                Text.ClearLine(skills.Length);

            } while (keyPress != ConsoleKey.Enter);

            return selectIndex; // ส่งค่า Index ของ Option ที่ผู้เล่นเลือกออกไป
        }

        public static void ShowCurrentStats(Player[] players)
        {
            Console.Clear();
            Text.SetFontSize(18);
            
            int hpDivisor, mpDivisor, atkDivisor, criDivisor;
            
            for (int i = 0; i < players.Length; i++)
            {
                hpDivisor = players[i].MaxHp / 30;
                mpDivisor = players[i].MaxMp / 30;
                
                Console.ForegroundColor = players[i].Color;
                Console.WriteLine();
                Console.WriteLine($" Player : {players[i].Name} ({players[i].PlayerClass})\n");
                Console.ResetColor();
                hpBar.PrintBar(players[i].Hp,players[i].MaxHp,hpDivisor);
                Console.WriteLine();
                mpBar.PrintBar(players[i].Mp,players[i].MaxMp,mpDivisor);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" HP : {players[i].Hp} / {players[i].MaxHp}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($" MP : {players[i].Mp} / {players[i].MaxMp}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" ATK : {players[i].Atk}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" CRI : {players[i].CriRate}");
                Console.ResetColor();
                Text.underLine(60);
            }
        }
    }
}