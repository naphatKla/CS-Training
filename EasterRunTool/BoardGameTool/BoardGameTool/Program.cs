using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace BoardGameTool
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            while (restart)
            {
                List<string> card = new List<string>();
                string[] cardName = {"STEAL","PROTECT","ENTRY CLOSED","THE JUMPER","UFO ABDUCTION","MAFIA","PERFECT BAIT","DIRTY WAY"};
                int[] numberofcard =  { 30        , 15      , 5              , 14          , 7    , 5          , 6    , 8 };
                int[] cardUsedSimulate = new int[numberofcard.Length];
                Array.Copy(numberofcard, 0, cardUsedSimulate , 0, numberofcard.Length);
                ConsoleKey functionKey;
                string space = "                    ";
                for (int i = 0; i < cardName.Length; i++)
                {
                    AddCardtodek(card,cardName[i],numberofcard[i]);
                }

                int allOfdek = card.Count;
                bool Condition = true;
                bool firstTimeCheck = true;
                printHowtouse();
                List<string> cardDek = card.ToList();
                List<int> numberOfcard = numberofcard.ToList();
                int eggsCount = 0;
                int walkTime = 0;
                
                Console.Write(" \rPlese press key to select mode . . .\r");
                functionKey = Console.ReadKey().Key;
                while (functionKey != ConsoleKey.C && functionKey != ConsoleKey.E && functionKey != ConsoleKey.W && functionKey != ConsoleKey.Q)
                {
                    Console.Write(" Plese press key to select mode . . .");
                    Console.WriteLine($"\r!! Press only key on rules{space}{space}\n Plese press key to select mode . . .\r\n");
                    functionKey = Console.ReadKey().Key;
                }
                    
                while (Condition)
                {
                    if (functionKey == ConsoleKey.C)
                    {
                        Console.Clear();
                        printHowtouse();
                        Console.WriteLine("Card Random Mode\n");
                        cardFn(ref cardDek, ref numberOfcard, ref functionKey,card);
                    }
                    if(functionKey == ConsoleKey.E)
                    {
                        Console.Clear();
                        printHowtouse();   
                        Console.WriteLine("Egg Random Mode\n");
                        eggFn(ref functionKey,ref eggsCount);
                    }
                    if(functionKey == ConsoleKey.W)
                    {
                        Console.Clear();
                        printHowtouse();   
                        Console.WriteLine("Walk Random Mode\n");
                        walkFn(ref functionKey, ref walkTime);
                        
                    }

                    if (functionKey == ConsoleKey.Q || functionKey == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Console.WriteLine(" ========== Conclusion ==========\n");
                        Console.WriteLine("Eggs\n");
                        Console.WriteLine($" Eggs spawn: {eggsCount}");
                        int eggsPoint = eggsCount - 5;
                        if (eggsPoint >= 0)
                            eggsPoint = eggsPoint;
                        else
                            eggsPoint = 0;
                        Console.WriteLine($" Egg point: {eggsPoint}");
                        Console.WriteLine($"\n ------------------------------\n");
                        Console.WriteLine("Walk\n");
                        Console.WriteLine($" Walk Time: {walkTime}");
                        Console.WriteLine($"\n ------------------------------\n");
                        Console.WriteLine("Card");
                        Console.WriteLine($"\n All Card: {card.Count}\n");
                        string txt = $" Card Left: {cardDek.Count} ";
                        while (txt.Length <= 35)
                        {
                            txt += " ";
                        }
                        Console.Write(txt);
                        percentagePrint(cardDek.Count,card.Count);
                        Console.WriteLine("");
                        
                        int[] numberCard = new int[cardName.Length];
                        for (int i = 0; i < cardDek.Count; i++)
                        {
                            for (int n = 0; n < cardName.Length; n++)
                            {
                                if (cardName[n] == cardDek[i])
                                {
                                    numberCard[n]++;
                                }
                            }
                        }

                        for (int i = 0; i < cardName.Length; i++)
                        {
                            string text = $"  {cardName[i]}: {numberCard[i]}";
                            while (text.Length <= 35)
                            {
                                text += " ";
                            }
                            Console.Write(text);
                            percentagePrint(numberCard[i],card.Count);
                        }
                        
                        
                        txt = $" Card Picked: {card.Count - cardDek.Count}";
                        while (txt.Length <= 35)
                        {
                            txt += " ";
                        }
                        Console.Write($"\n{txt}");
                        percentagePrint(card.Count- cardDek.Count,card.Count);
                        Console.WriteLine();
                        
                        for (int i = 0; i < cardName.Length; i++)
                        {
                            string text = $"  {cardName[i]}: {numberofcard[i] - numberCard[i]}";
                            while (text.Length <= 35)
                            {
                                text += " ";
                            }
                            Console.Write(text);
                            percentagePrint(numberofcard[i] - numberCard[i],card.Count);
                        }
                        Console.WriteLine($"\n ------------------------------\n");
                        break;
                    }
                    
                    if((functionKey != ConsoleKey.C) && (functionKey != ConsoleKey.E) && (functionKey != ConsoleKey.W) && (functionKey == ConsoleKey.Q) && (functionKey == ConsoleKey.Escape))
                    {
                        Console.Clear();
                        functionKey = Console.ReadKey().Key;
                        printHowtouse();
                    }
                }
                
                while (restart)
                {
                    Console.Write("Do you want to use again [Y / N] ?");
                    ConsoleKey ans = Console.ReadKey().Key;
                    if (ans == ConsoleKey.Y)
                    {
                        Console.Write($"\r OK Restart ... {space} {space}\r\n\r");
                        Console.Clear();
                        break;
                    }
                    else if (ans == ConsoleKey.N)
                    {
                        Console.Write($"\r Thank for use my app !! {space} {space}\r\n");
                        Console.Write(" Please any key to close . . .");
                        Console.ReadKey();
                        restart = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\r!! Press only Y or N !! {space} {space}\r");
                    }
                }
            }
        }

        static void walkFn(ref ConsoleKey functionKey,ref int walkTime)
        {
            ConsoleKey input;
            string space = "                   ";
            int randomNumber;
            List<int> number = new List<int>();
            for (int i = 1 ; i <= 6; i++)
            {
                number.Add(i);
            }
            while (true)
            {
                input = Console.ReadKey().Key;
                if (input == ConsoleKey.Enter)
                {
                    randomNumber = RandomNumber(number);
                    Console.Write($" {randomNumber}{space}{space}\n\n\r");
                    walkTime++;
                }
                else if(input == ConsoleKey.C || input == ConsoleKey.Q || input == ConsoleKey.E)
                {
                    Console.Write($"\r{space}{space}{space}\r");
                    functionKey = input;
                    break;
                }
                else if(input == ConsoleKey.W)
                {
                    Console.Write($"\r!! You are already stay in this mode\r");
                }
                else 
                {
                    Console.Write($"\r!! Press only key rules\r");
                }
            }
        }
        static void eggFn(ref ConsoleKey functionKey,ref int eggCount)
        {
            ConsoleKey input;
            string space = "                   ";
            int randomNumber;
            List<int> number = new List<int>();
            for (int i = 0 ; i <= 45; i++)
            {
                number.Add(i);
            }
            while (true)
            {
                input = Console.ReadKey().Key;
                if (input == ConsoleKey.Enter)
                {
                    randomNumber = RandomNumber(number);
                    Console.Write($" {randomNumber}{space}{space}\n\n\r");
                    eggCount++;
                }
                else if(input == ConsoleKey.C || input == ConsoleKey.Q || input == ConsoleKey.W)
                {
                    Console.Write($"\r{space}{space}{space}\r");
                    functionKey = input;
                    break;
                }
                else if(input == ConsoleKey.E)
                {
                    Console.Write($"\r!! You are already stay in this mode\r");
                }
                else 
                {
                    Console.Write($"\r!! Press only key on rules\r");
                }
            }
        }
        static void cardFn(ref List<string> cardDek,ref List<int> numberOfcard,ref ConsoleKey functionKey,List<string> card)
        {
            string space = "                   ";
            
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.Enter)
                {
                    if (cardDek.Count == 0)
                    {
                        ConsoleKey ans;
                        Console.WriteLine("!! Don't have any Card to pick");
                        Console.WriteLine(" Do you want to shuffle and pick again [Y / N] ?");
                        ans = Console.ReadKey().Key;
                        while (ans != ConsoleKey.Y && ans != ConsoleKey.N)
                        {
                            Console.WriteLine(" !! Press only Y or N [ Yes or No ]");
                            ans = Console.ReadKey().Key;
                        }

                        if (ans == ConsoleKey.Y)
                        {
                            cardDek = card;
                        }
                        else
                        {
                            functionKey = ConsoleKey.Q;
                            break;
                        }

                    }
                    if(cardDek.Count != 0)
                    {
                        string randomCard = RandomCard(cardDek);
                        Console.Write($" {randomCard} : {cardDek.Count-1}{space}{space}\n\n\r");
                        cardDek.Remove(randomCard);
                    }
                }
                else if(input == ConsoleKey.C)
                {
                    Console.Write($"\r!! You are already stay in this mode\r");
                }
                else if(input == ConsoleKey.E || input == ConsoleKey.Q || input == ConsoleKey.W)
                {
                    Console.Write($"\r{space}{space}{space}\r");
                    functionKey = input;
                    break;
                }
                else 
                {
                    Console.Write($"\r!! Press only key on rules\r");
                }
            }
        }
        static void printHowtouse()
        {
            Console.WriteLine(" ======== Easter Run Tools ========\n");
            Console.WriteLine(" !! How to use !!\n");
            Console.WriteLine("  \'E\' Eggs mode");
            Console.WriteLine("  \'W\' Walk mode");
            Console.WriteLine("  \'C\' Card mode\n");
            Console.WriteLine("  \'Enter\'  action");
            Console.WriteLine("  \'Q\' or \'Esc\'  quit and Conclusion");
            Console.WriteLine("\n --------------------------------\n");
            
        }
        static void AddCardtodek(List<string> list, string text, int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                list.Add(text);
            }
        }

        static string RandomCard(List<string> list)
        {
            string result;
            var rnd = new Random();
            var randomized = list.OrderBy(item => rnd.Next());
            list = randomized.ToList();
            result = list[0];
            return result;
        }
        static int RandomNumber(List<int> list)
        {
            int result;
            var rnd = new Random();
            var randomized = list.OrderBy(item => rnd.Next());
            list = randomized.ToList();
            result = list[0];
            return result;
        }

        static void percentagePrint(int input, int allInput)
        {
            float percentage = ((float)input / (float)allInput) *100;
            Console.WriteLine($"{percentage:F2}%");
        }
    }
}