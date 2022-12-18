using System;
using System.Net.Http.Headers;
using System.Threading;

namespace GI113_FinalProject.UI
{
    public static class Text
    {
        private static short currentFontSize;
        public static void TextPrint(string text,int milliseconds = 20)  // รับ String เข้ามาแล้วปริ้นทีละตัวด้วย Delay ตามเวลาที่ป้อนมา
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.RightArrow)  //  ถ้ามีการกดปุ่มลูกศรขวา ให้ millisec = 0 ( skip Delay )
                {
                    milliseconds = 0;
                }
                
                Console.Write(text[i]);
                Thread.Sleep(milliseconds); // Delay
            }
            
            // เมื่อใช้ Console.Available หากมีการกดปุ่มใดๆค่าของปุ่นจะถูกส่งไปที่ Console.ReadKey ครั้งถัดไปทันที
            // หรือพูดง่ายๆก็คือ Console.ReadKey จะไม่ถูก Run 1 ครั้ง เนื่องจากมันได้ค่าป้อนเข้าไปจาก Console.Available แล้ว

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                    
            }
            Console.WriteLine();   
        }
        
        public static void TextPrint(string text,bool waitEnter,bool canSkip = true)  // Overloading method 
        {
            int milliseconds = 20;
            
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.RightArrow && canSkip)  
                {
                    milliseconds = 0;
                }
                
                Console.Write(text[i]);
                Thread.Sleep(milliseconds); 
            }

            if (waitEnter == true)
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    
                }
            }
            Console.WriteLine();   
        }

        public static void TextPrint(string text,int milliseconds, bool waitEnter,bool canSkip = true)  // Overloading method 
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.RightArrow && canSkip)  
                {
                    milliseconds = 0;
                }
                
                Console.Write(text[i]);
                Thread.Sleep(milliseconds); 
            }
            
            if (waitEnter == true)
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    
                }
            }
            Console.WriteLine();   
        }
        
        public static void TextPrint(string text,int milliseconds, bool waitEnter,bool canSkip, bool newLine)  // Overloading method 
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.RightArrow && canSkip)  
                {
                    milliseconds = 0;
                }
                
                Console.Write(text[i]);
                Thread.Sleep(milliseconds); 
            }
            
            if (waitEnter == true)
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    
                }
            }

            if (newLine)
            {
                Console.WriteLine();   
            }
        }


        public static void TopicPrint(string topic,int spaceFromLeft = 0,ConsoleColor charColor = ConsoleColor.White,ConsoleColor frameColor = ConsoleColor.White)
        {
            int frameLenght = topic.Length + 10;
            int waitTime = 5;
            string space = null;

            if (topic.Length > 15)
            {
                waitTime = 1;
            }
            // add space from the left
            for (int i = 0; i < spaceFromLeft; i++)
            {
                space = space + " ";
            }
            
            // Print topic
            for (int y = 0; y < 5; y++)
            {
                Console.Write(space);
                
                int i = 0;
                for (int x = 0; x < frameLenght; x++)
                {
                  
                    if (y == 0 || y == 4)
                    {
                        if (x > 1 && x < frameLenght-2)
                        {
                            Thread.Sleep(waitTime);
                            Console.BackgroundColor = frameColor;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    if (y == 1 || y == 3)
                    {
                        if (x == 1 || x == frameLenght - 2)
                        {
                            Thread.Sleep(waitTime);
                            Console.BackgroundColor = frameColor;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    if (y == 2)
                    {
                        if (x == 0 || x == frameLenght - 1)
                        {
                            Thread.Sleep(waitTime);
                            Console.BackgroundColor = frameColor;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else if (x > 4 && x < 5 + topic.Length)
                        {
                            Thread.Sleep(waitTime);
                            Console.ForegroundColor = charColor;
                            Console.Write(topic[i]);
                            i++;
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public static void TitlePrint(string title, int spaceFromLeft, int spaceFromTop, ConsoleColor underLineColor = ConsoleColor.Yellow)
        {
            string spaceLeft = null;
            string spaceTop = null;
            string underLine = null;
            string underLineSpaceLeft = null;
            int waitTime = 20;
            short fontSizeBefore = currentFontSize;
                
            for (int i = 0; i < spaceFromLeft; i++)
            {
                spaceLeft += " ";
                
                if (i > 0)
                {
                    underLineSpaceLeft += " ";
                }
            }

            for (int i = 0; i < spaceFromTop; i++)
            {
                spaceTop += "\n";
            }

            for (int i = 0; i < title.Length + 2; i++)
            {
                underLine += " ";
            }

            if (waitTime > 15)
            {
                waitTime = 1;
            }
            Console.Clear();
            SetFontSize(100);
            Console.Write($"{spaceTop}{spaceLeft}");
            TextPrint(title, waitTime,false,false);
            Console.Write(underLineSpaceLeft);
            Console.BackgroundColor = underLineColor;
            TextPrint(underLine,50,false,false);
            Thread.Sleep(1000);
            Console.ResetColor();
            SetFontSize(fontSizeBefore);
            Console.Clear();
        }

        public static void StoryPrint(string story,ConsoleColor color = ConsoleColor.Yellow)
        {
            short fontSizeBefore = currentFontSize;
            SetFontSize(40);
            TopicPrint("Story",2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            TextPrint("\n----------------------------------------------------------------------------------\n",1,false);
            Console.ResetColor();
            Console.ForegroundColor = color;
            TextPrint($" {story}",5,false,true);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            TextPrint("\n----------------------------------------------------------------------------------\n",1,false);
            Console.ResetColor();
            Menu.SelectMenu(new[] { "Next" });
            SetFontSize(fontSizeBefore);
        }
        
        public static void ClearLine(int lines = 1,bool specificLineMode = false) // รับค่า จำนวนบรรทัด ที่เราต้องการจะลบ
        {
            if (specificLineMode)
            {
                Console.SetCursorPosition(0, Console.CursorTop - lines);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            else
            {
                for (int i = 1; i <= lines; i++)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
            }
        }

        public static void PrintPicture(string picture,short size = 18)
        {
            short fontSizeBefore = currentFontSize;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            SetFontSize(size);
            Console.WriteLine(picture);
            Console.ResetColor();
            SetFontSize(currentFontSize);
        }

        public static void underLine(int line = 15)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < line; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.ResetColor();
        } 
        public static void SetFontSize(short fontSize)
        {
            currentFontSize = fontSize;
            ConsoleHelper.SetCurrentFont(fontSize);
        }

        public static void ResetFontSize()
        {
            ConsoleHelper.SetCurrentFont(18);
        }
    }
}