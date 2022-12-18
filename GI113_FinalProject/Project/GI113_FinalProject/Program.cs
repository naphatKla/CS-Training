using System;
using System.Linq;
using System.Threading;
using GI113_FinalProject.Objects;
using GI113_FinalProject.UI;
using Microsoft.VisualBasic;


namespace GI113_FinalProject
{
    internal class Program
    {
        private static ConsoleColor[] PlayerColors = new[] { ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Magenta };
        
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;     // Set encoding to fix a letter bug on console
            Console.CursorVisible = false;
            
            Random rnd = new Random();
            bool isStart = Start();
            bool isWin = false;
            
            
            if (isStart)     // If player start the game
            {
                const int stageNumber = 1; // can be change a round to play
                Player[] players = new Player[4] { new Player(), new Player(), new Player(), new Player() };
                Boss boss = new BossPTO();
                
                
                // Start story
                Text.StoryPrint(Story.story_1);

                
                // Select a class
                Text.TitlePrint("Select your Class",8,4,ConsoleColor.Cyan);
                Text.TopicPrint("Do you want to name your hero ?", 2);
                Console.WriteLine("\n");

                if (Menu.SelectMenu(new[] { "Yes", "No" }) == 0)     // If player select Yes ( player want to name a heroes )
                {
                    NameHero(ref players,true);
                }
                else
                {
                    NameHero(ref players,false);
                }
                
                SelectPlayerClass(ref players);
                
                // print stats
                for (int i = 0; i < players.Length; i++)
                {
                    Console.ForegroundColor = PlayerColors[i];
                    players[i].PrintStats();
                }
                Menu.SelectMenu(new[] { "Next" });
                
                // Start Game Play

                for (int i = 0; i < players.Length; i++)
                {
                    players[i].SetColor(ref players[i],PlayerColors[i]);
                }
                
                Bar[] playerHpBar = new[] { new Bar("HP", ConsoleColor.Red),new Bar("HP", ConsoleColor.Red),new Bar("HP", ConsoleColor.Red),new Bar("HP", ConsoleColor.Red) };
                Bar[] playerMpBar = new[] { new Bar("MP", ConsoleColor.Blue), new Bar("MP", ConsoleColor.Blue), new Bar("MP", ConsoleColor.Blue), new Bar("MP", ConsoleColor.Blue) };
                Bar bossHpBar = new Bar("Boss HP ", ConsoleColor.Red);
            
                for (int i = 0; i < stageNumber; i++)
                {
                    int playerIndex = 0;
                    int divisorPlayerHp;
                    int divisorPlayerMp;
                    int divisorBossHP = (boss.MaxHp / 90);
                    bool isEnd = false;
                    bool[] isPlayerLife = new bool[4];

                    Text.TitlePrint($"Stage {i+1}",13,4,PlayerColors[rnd.Next(0,PlayerColors.Length)]);
                    Text.TitlePrint($"Player VS {boss.Name}",10,4,PlayerColors[rnd.Next(0,PlayerColors.Length)]);
                    Text.PrintPicture(boss.Picture);
                    bossHpBar.PrintBar(boss.Hp,boss.MaxHp,divisorBossHP);
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    Console.Clear();
                    Text.SetFontSize(34);
                            
                    while (boss.Hp > 0)
                    {
                        
                        // check status player
                        for (int j = 0; j < isPlayerLife.Length; j++)
                        {
                            isPlayerLife[j] = players[j].IsLife;
                        }

                        // if player die all
                        if ((isPlayerLife[0] == false) && (isPlayerLife[1] == false) && (isPlayerLife[2] == false) && (isPlayerLife[3] == false))
                        {
                            isWin = false;
                            isEnd = true;
                            break;
                        }
                        
                        if (playerIndex > players.Length - 1)
                        {
                            playerIndex = 0;
                        }
                        
                        divisorPlayerHp = (players[playerIndex].MaxHp / 30);
                        divisorPlayerMp = (players[playerIndex].MaxMp / 30);
                        
                        // if player die
                        if (players[playerIndex].IsLife == false) 
                        {
                            playerIndex++;
                            continue;
                        }
                        
                        Text.SetFontSize(34);
                        // Player hp mp bar
                       
                        Text.TopicPrint($"{players[playerIndex].Name} Turn",2,players[playerIndex].Color,players[playerIndex].Color);
                        Console.WriteLine("\n");
                        playerHpBar[playerIndex].PrintBar(players[playerIndex].Hp,players[playerIndex].MaxHp,divisorPlayerHp);
                        Console.WriteLine();
                        playerMpBar[playerIndex].PrintBar(players[playerIndex].Mp,players[playerIndex].MaxMp,divisorPlayerMp);
                        Console.WriteLine();
                        Text.underLine(40);
                        
                        // Player stats show
                        Console.ForegroundColor = players[playerIndex].Color;
                        Text.TextPrint($" Class : {players[playerIndex].PlayerClass}",1,false);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Text.TextPrint($" HP : {players[playerIndex].Hp} / {players[playerIndex].MaxHp}",1,false);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Text.TextPrint($" MP : {players[playerIndex].Mp} / {players[playerIndex].MaxMp}",1,false);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Text.TextPrint($" ATK : {players[playerIndex].Atk}",1,false);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Text.TextPrint($" Critical Rate : {players[playerIndex].CriRate}%",1,false);
                        Text.underLine(40);
                        Console.WriteLine();

                        
                        // Player choice

                        bool playerAction = false;

                        while (playerAction == false && players[playerIndex].IsLife) 
                        {
                            if (Menu.SelectMenu(new[] { "Attack", $"{players[playerIndex].PlayerClass} Skills" }) == 0)
                            {
                                players[playerIndex].Attack(ref boss);
                                playerAction = true;
                            }
                            else
                            {
                                string[] menu = players[playerIndex].Skills.Concat(new[] { "back" }).ToArray();
                                int selectSkill = Menu.SelectSkill(menu,ref players[playerIndex]);
                                Text.ClearLine(menu.Length - 1);

                                if (selectSkill < players[playerIndex].Skills.Length)
                                {
                                    players[playerIndex].UseSkill(selectSkill, ref boss, ref players);
                                    playerAction = true;
                                }
                            }
                        }
                        
                        Console.WriteLine("\n\n");
                        Menu.SelectMenu(new[] { "Continue" });
                        Text.SetFontSize(34);
                       
                        Console.Clear();
                        
                        if (boss.Hp <= 0)    // if boss die
                        {
                            isEnd = true;
                            isWin = true;
                            break;
                        }
                        
                        // Boss Turn
                        Text.TopicPrint($"{boss.Name} Turn",2,ConsoleColor.Red,ConsoleColor.Red);
                        Console.WriteLine("\n");
                        Text.PrintPicture(boss.Picture);
                        bossHpBar.PrintBar(boss.Hp,boss.MaxHp,divisorBossHP);
                        Console.WriteLine("\n");
                        Text.underLine(80);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Text.TextPrint($" Boss Hp : {boss.Hp} / {boss.MaxHp} \n",5,false,true,true);
                        Text.underLine(80);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Text.TextPrint($" {boss.Name} is thinking ...",5,false);
                        Thread.Sleep(3000);
                        Text.SetFontSize(34);
                        Console.ResetColor();
                        
                        int randomActionBoss = rnd.Next(0, 101);

                        if (randomActionBoss < 70)   // 70 %  chance
                        {
                            boss.Attack(ref players);
                        }
                        else if (randomActionBoss >= 70 && randomActionBoss < 85 )
                        {
                            boss.skillJOKNA(ref players);
                        }
                        else
                        {
                            boss.skillGAYRAY();
                        }
                        
                        Console.WriteLine("\n\n");
                        Menu.SelectMenu(new[] { "Continue" });
                        
                        Console.Clear();
                        
                        playerIndex++;
                        boss.CanAttack = true;
                        
                    }
                    
            
                    if (isEnd)
                    {
                        if (isWin)
                        {
                            Text.SetFontSize(12);
                            Text.PrintPicture(BossPicture.PTOWhenYouWin);
                            Thread.Sleep(5000);
                            Text.ResetFontSize();
                            Text.TitlePrint("You Win !!",12,4,ConsoleColor.Green);
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Text.PrintPicture(BossPicture.PTOWhenYouLose);
                            Thread.Sleep(5000);
                            Text.TitlePrint("You Lose !!",12,4,ConsoleColor.Red);
                            Thread.Sleep(2000);
                        }
                        
                        Text.TitlePrint("THANK FOR PLAYING XD",7,4);
                        Thread.Sleep(3000);
                        break;
                    }
                    
                }
            }
            else     // Player exit
            {
                Text.TitlePrint("THANK FOR PLAYING XD",7,4);
                Thread.Sleep(3000);
            }
        
        }

        // Main ending -------------------------------------------------------------------------------------------

        private static bool Start()     // Start menu
        {
            bool isStart = false;
            bool isFirtTimeDisplay = true;
            while (isStart == false)
            {
                Console.Clear();
                Text.SetFontSize(34);
                Logo.Display();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (isFirtTimeDisplay)
                {
                    Text.TextPrint(" Please don't change the screen size for the best playing experience",1,false);
                    Text.TextPrint(" ( ↑ ↓ ) to control\n\n",1,false);
                    isFirtTimeDisplay = false;
                }
                else
                {
                    Console.WriteLine(" Please play on fullscreen(F11) and 16:9 window size for the best experience");
                    Console.WriteLine(" ( ↑ ↓ ) to control\n\n");
                }
         
                Console.ResetColor();
                
                int selectedIndex = Menu.SelectMenu(new[] { "PLAY", "HOW TO PLAY", "EXIT" });

                if (selectedIndex == 0)     // If player select Play
                {
                    isStart = true;
                }
                else if (selectedIndex == 1) // If player select How to play
                {
                    Console.Clear();
                    Text.TopicPrint("HOW TO PLAY",3);
                    Text.TextPrint("\n -----------------------------------------",1,false);
                    Console.WriteLine("\n");
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("↑ ↓");
                    Console.ResetColor();
                    Text.TextPrint(" \"Arrow\" key to control\n",1,false,false);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter");
                    Console.ResetColor();
                    Text.TextPrint(" \"Enter\" key to select a choice\n",1,false,false);
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" → ");
                    Console.ResetColor();
                    Text.TextPrint(" \"Right Arrow\" key to skip a text as possible\n\n",1,false,false);
                    Text.TextPrint(" -----------------------------------------\n\n",1,false);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Text.TextPrint(" Press enter to continue ...");
                    Console.ResetColor();
                    Text.ClearLine();
                    Menu.SelectMenu(new[] { "Back" });
                    
                }
                else     // Player select Exit
                {
                    Console.Clear();
                    Text.TopicPrint("Are you sure ?",1);
                    Console.WriteLine("\n");
                    if (Menu.SelectMenu(new[] { "YES", "NO" }) == 0)
                    {
                        break;
                    }
                }
            }
            Text.ResetFontSize();
            Console.Clear();
            return isStart;
        }

        private static void SelectPlayerClass(ref Player[] players)     // Let player select a class
        {
            Bar hpBar = new Bar("HP",ConsoleColor.Red);
            Bar mpBar = new Bar("MP",ConsoleColor.Blue);
            Bar atkBar = new Bar("ATK",ConsoleColor.Green);
            Bar criBar = new Bar("Cri",ConsoleColor.DarkYellow);
            
            for (int i = 0; i < players.Length; i++)
            {
                Console.Clear();
                Text.TopicPrint($"{players[i].Name}",2, PlayerColors[i], PlayerColors[i]);
                Console.WriteLine();
                Console.ResetColor();
                if (i == 0)
                {
                    Text.TextPrint($" Hi ",1,false,true,false);
                    Console.ForegroundColor = PlayerColors[i];
                    Text.TextPrint($"{players[i].Name} ",1 ,false);
                    Console.ResetColor();
                    Text.TextPrint($" What class you want to choose?\n",1,false);
                }
                else
                {
                    Text.TextPrint($" Hi ",0,false,true,false);
                    Console.ForegroundColor = PlayerColors[i];
                    Text.TextPrint($"{players[i].Name} ",0 ,false);
                    Console.ResetColor();
                    Text.TextPrint($" What class you want to choose?\n",0,false);
                }
                players[i].SelectClass(ref players[i],ref hpBar,ref mpBar,ref atkBar,ref criBar);
                Console.Clear();
            }
            
        }

        private static void NameHero(ref Player[] players, bool isName)     // Let player name a heroes [ True / False ]
        {
            Console.CursorVisible = true;
            Console.Clear();

            if (isName)     // if player want to name the heroes
            {
                Console.Clear();
                Text.TopicPrint("Name your heroes",2);
                Console.WriteLine();
                
                for (int i = 0; i < players.Length; i++)    // Loop for enter name
                {
                    bool isNameCorrect = false;
                    
                    while (isNameCorrect == false)      // Loop for input variable
                    {
                        Console.WriteLine();
                        Text.TextPrint($" Enter name of",1,false,true,false);
                        Console.ForegroundColor = PlayerColors[i];
                        Text.TextPrint($" player {i+1} : ",1,false,true,false);
                        players[i].Name = Console.ReadLine();
                        Console.ResetColor();
                        
                        if (players[i].Name.Trim() == "")     // If player enter empty name
                        {
                            Text.ClearLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Text.TextPrint($" !! Name cannot be spaces !!",1,false);
                            Thread.Sleep(2000);
                            Text.ClearLine(2);
                            Console.ResetColor();
                            continue;
                        }
                        else if (players[i].Name[0] == '?')     // If player name is not in English
                        {
                            Text.ClearLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Text.TextPrint($" !! Name must be in English only !!",1,false);
                            Thread.Sleep(2000);
                            Text.ClearLine(2);
                            Console.ResetColor();
                            continue;
                        }
                     
                        foreach (var player in players)     // Loop when player enter the name tha had already use
                        {
                            if (player.Name == players[i].Name && Array.IndexOf(players,player) != Array.IndexOf(players,players[i]))
                            {
                                Text.ClearLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Text.TextPrint($" !! This name is already use !!",1,false);
                                Thread.Sleep(2000);
                                Text.ClearLine(2);
                                Console.ResetColor();
                                break;
                            }
                            else if (Array.IndexOf(players,player) == players.Length - 1)
                            {
                                isNameCorrect = true;
                            }
                        }
                    }
                    
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Text.TextPrint("\n-----------------------------------------",1,false);
                    Console.ResetColor();
                }
                
                Console.WriteLine();
                Text.TextPrint(" Hi ",20,false,true,false);

                foreach (var player in players)     // Loop for say hi player
                {
                    Console.ForegroundColor = PlayerColors[Array.IndexOf(players, player)];
                    player.Color = PlayerColors[Array.IndexOf(players, player)];
                    
                    if (Array.IndexOf(players, player) == players.Length - 1)
                    {
                        Text.TextPrint($"{player.Name} ",20,false,true,false);
                    }
                    else
                    {
                        Text.TextPrint($"{player.Name}, ",20,false,true,false);
                    }
                }
                
                Console.ResetColor();
                Text.TextPrint("\n\n Welcome to Lagnarook... \n",20,false);
                Thread.Sleep(1000);
                Menu.SelectMenu(new []{"Next"});
            }
            else     // Player not name a hero : set default hero name 
            {
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].Name = $"Player {i + 1}";
                }
            }
            
            Console.CursorVisible = false;
        }
    }
}