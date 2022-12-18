using System;
using System.Reflection;
using System.Threading;

namespace GI113_FinalProject.UI
{
    public class Bar
    {
        private ConsoleColor[] colors = new[]
        {
            ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Magenta,
            ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow,
        };

        private ConsoleColor[] darkColors = new[]
        {
            ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray, ConsoleColor.DarkGreen,
            ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.Gray, ConsoleColor.DarkYellow
        };

        private ConsoleColor barShadow;
        private ConsoleColor barColor;
        private int barLength;
        private int maxBarLength;
        private int startPositionCursor;
        private int currentPositionCursor;
        private int endPositionCursor;
        private int lastCurrentBar;
        private bool firtPrint;
        private string barName;

        public int BarLength { get => barLength; set => barLength = value; }
        public int MaxBarLength { get => maxBarLength; }
        public ConsoleColor BarColor { get => barColor; set => barColor = value; }
        public string BarName { get => barName; set => barName = value; }
        public bool FirtPrint { get => firtPrint; set => firtPrint = value; }

        public Bar(string barName, ConsoleColor barColor)
        {
            lastCurrentBar = 0;
            firtPrint = true;
            this.barColor = barColor;
            this.barName = barName;
        }
        
        public void PrintBar (int Length,int maxLength,int divisor = 10,int waitTime = 20)
        {
            if (barLength < 0)
            {
                barLength = 0;
            }
            else if (barLength > maxBarLength)
            {
                barLength = maxBarLength;
            }

            this.barLength = Length / divisor;
            this.maxBarLength = maxLength / divisor;
            this.barLength = barLength;
            string Bar = "";
            string maxBar = "";

            Console.ForegroundColor = barColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($" {barName} ");
            startPositionCursor = Console.CursorLeft;
            endPositionCursor = startPositionCursor + maxBarLength;
            
            Console.BackgroundColor = barColor;
            for (int i = 0; i < colors.Length; i++)     // set shadow bar
            {
                if (barColor == colors[i])
                {
                    barShadow = darkColors[i];
                }
            }
            
            for (int i = 0; i < maxBarLength; i++)     // set bar ui
            {
                if (i < barLength)
                {
                    Bar += " ";
                }

                maxBar += " ";
            }
            
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < maxBarLength; i++)     // set base color 
            {
                Console.Write(maxBar[i]);
                    
                if (firtPrint)
                {
                    Thread.Sleep(5);
                }
            }
            Console.SetCursorPosition(startPositionCursor,Console.CursorTop);      

            Console.BackgroundColor = barColor;
            for (int i = 0; i < lastCurrentBar; i++)     // print bar before change
            {
                Console.Write(maxBar[i]);
                if (firtPrint)
                {
                    Thread.Sleep(5);
                }
            }
            Console.SetCursorPosition(startPositionCursor,Console.CursorTop);
            
            if (lastCurrentBar <= barLength)     // If hp increase
            {
                Console.BackgroundColor = barColor;
                for (int i = 0; i < Bar.Length; i++)     // print bar increase
                {
                    Console.Write(Bar[i]);
                    if (i > lastCurrentBar)
                    {
                        Thread.Sleep(waitTime);
                    }
                }
            }
            else     // hp decrease
            {
                Console.BackgroundColor = barShadow;
                for (int i = 0; i < lastCurrentBar - barLength; i++)     // print shadow when bar decrease
                {
                    Console.SetCursorPosition(currentPositionCursor - (i+1),Console.CursorTop);
                    Console.Write(" ");
                    Thread.Sleep(waitTime);
                }

                Console.BackgroundColor = ConsoleColor.DarkGray;     
                for (int i = 0; i < lastCurrentBar - barLength; i++)     // delete the shadow 
                {
                    Console.SetCursorPosition(currentPositionCursor - (i+1),Console.CursorTop);
                    Console.Write(" ");
                    Thread.Sleep(waitTime);
                    Console.SetCursorPosition(currentPositionCursor - (i+1),Console.CursorTop);
                }
            }
            
            firtPrint = false;
            lastCurrentBar = barLength;
            currentPositionCursor = Console.CursorLeft;
            Console.SetCursorPosition(0,Console.CursorTop);
            Console.ResetColor();
        }
    }
}