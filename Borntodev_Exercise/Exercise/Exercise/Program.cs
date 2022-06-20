using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise_23();
            // ถึงโจทย์ ReverseThe

        }

        static void Exercise_1()
        {
            // โจทย์ให้ปริ้น Hello World
            Console.WriteLine("Hello World");
        }

        static void Exercise_2()
        {
            /* โจทย์ให้ปริ้น บันไดตาม input
                intput: 4
             
                 *
                 **
                 ***
                 ****
             */
            int input = Convert.ToInt32(Console.ReadLine());
            int XLimit = 1;
            for (int i = 0; i < input; i++)
            {
                for (int I = 0; I < XLimit; I++)
                {
                    Console.Write("*");
                }

                Console.Write("\n");
                XLimit++;
            }
        }

        static void Exercise_3()
        {
            // เขียนโปรแกรมคำนวนเกรด
            int score = Convert.ToInt32(Console.ReadLine());
            int[] Score = { 80, 70, 60, 50, 0 };
            string[] Grade = { "A", "B", "C", "D", "F" };
            for (int i = 0; i < Score.Length; i++)
            {
                if (score >= Score[i])
                {
                    Console.WriteLine(Grade[i]);
                    break;
                }
            }
        }

        static void Exercise_4()
        {
            // นำตัวเลขบวกกัน
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 + num2);
        }

        static void Exercise_5()
        {
            //หาว่าจำนวนไหนมากกว่า
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());
            if (A > B)
                Console.Write("A");
            else if (A < B)
                Console.Write("B");
            else
                Console.Write("AB");
        }

        static void Exercise_6()
        {
            //ปริ้นข้อความธรรมดา
            Console.WriteLine("Welcome to Sommai 108 Eleven Shop");
        }

        static void Exercise_7()
        {
            Console.WriteLine("*\n**\n***\n****\n*****\n******");
        }

        static void Exercise_8()
        {
            Console.WriteLine("    $\n   $ $\n  $ $ $\n $ $ $ $\n$ $ $ $ $");
        }

        static void Exercise_9()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome {name} !");
            Console.WriteLine("Sommai 108 Eleven Shop");
        }

        static void Exercise_10()
        {
            //รับค่ามา 2 ตัวแล้วเอามา พีชคณิตกัน
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
        }

        static void Exercise_11()
        {
            //คำนวณหาอัตราเร็ว
            int distance = Convert.ToInt32(Console.ReadLine());
            int hours = Convert.ToInt32(Console.ReadLine());
            int result = distance / hours;
            Console.WriteLine($"{result} km/h");
        }

        static void Exercise_12()
        {
            //เอาเลขคูณกันเฉยๆ
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result = num1 * num2;
            Console.WriteLine(result);
        }

        static void Exercise_13()
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 % num2);
        }

        static void Exercise_14()
        {
            //ให้หาว่าค่าไหนมากและน้อยกว่า
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int max, min;

            if (num1 > num2)
            {
                max = num1;
                min = num2;
            }
            else
            {
                max = num2;
                min = num1;
            }

            Console.WriteLine($"MAX : {max}");
            Console.WriteLine($"MIN : {min}");
        }

        static void Exercise_15()
        {
            //กรองอายุ ต่ำกว่า 18 ห้ามเข้า
            string name = Console.ReadLine();
            int years = Convert.ToInt32(Console.ReadLine());
            if (2022 - years >= 18)
            {
                Console.WriteLine($"Welcome {name} to NongGipsy Pub");
            }
            else
            {
                Console.WriteLine("You shall not pass!");
            }
        }

        static void Exercise_16()
        {
            //ปริ้น A ตามจำนวนรอบ
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("A");
            }
        }

        static void Exercise_17()
        {
            Exercise_2();
        }

        static void Exercise_18()
        {
            //ยกกำลัง
            double num = Convert.ToDouble(Console.ReadLine());
            double pow = Convert.ToDouble(Console.ReadLine());
            double result = Math.Pow(num, pow);
            Console.WriteLine(result);
        }

        static void Exercise_19()
        {
            // Leap year check
            int years = Convert.ToInt32(Console.ReadLine());
            if((years % 4 == 0 && years % 100 != 0) || years % 400 == 0)
                Console.WriteLine("Leap Year");
            else 
                Console.WriteLine("Not a Leap Year");
        }

        static void Exercise_20()
        {
            /* ให้ตีกรอบตามจำนวน input เช่น 5
                    #####
                    #   #
                    #   #
                    #   #
                    #####
             */
            int num = Convert.ToInt32(Console.ReadLine());
            int XLimit = num;
            int YLimit = num;
            for (int y = 0; y < YLimit; y++)
            {
                for (int x = 0; x < XLimit; x++)
                {
                    if(y == 0 || y + 1 == YLimit)
                        Console.Write("#");
                    else if (x == 0 || x + 1 == XLimit)
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        static void Exercise_21()
        {
            // RevertThe ให้เอาคำที่ป้อนย้อนกลับกัน เช่น I Was 6 => 6 Was I
            string text = Console.ReadLine();
            List<string> Text = new List<string>();
            string temp = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    Text.Add(temp);
                    temp = string.Empty;
                }
                else
                {
                    temp += text[i];
                }

                if (i == text.Length - 1)
                {
                    Text.Add(temp);
                    temp = string.Empty;
                }
            }

            for (int i = Text.Count-1; i >= 0; i--)
            {
                Console.Write(Text[i]);
                if (i != 0)
                {
                    Console.Write(" ");
                }
            }

        }

        static void Exercise_22()
        {
            // รับน้ำหนักปลามาแบบไม่จำกัด หากจะหยุดรับ ให้ใส่เลข 0 จากนั้นป้อน max หรือ min เพื่อจัดเรียง
            List<int> fishWeight = new List<int>();
            int temp;
            string ans;
            
            while (true)
            {
                temp = Convert.ToInt32(Console.ReadLine());
                if (temp != 0)
                {
                    fishWeight.Add(temp);
                }
                else
                {
                    break;
                }
            }

            ans = Console.ReadLine();
            fishWeight.Sort();
            if (ans.ToLower() == "max")
            {
                fishWeight.Reverse();
            }

            foreach (var index in fishWeight)
            {
                Console.Write($"{index} ");
            }
            
        }

        static void Exercise_23()
        {
            // สร้าง pramid จาก input 
            int input = Convert.ToInt32(Console.ReadLine());
            int xlimit = input;
            int ylimit = input;

            for (int y = 1; y <= ylimit; y++)
            {
                for (int x = 1; x <= xlimit; x++)
                {
                    if (x <= ylimit - y)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.Write("\n");
                xlimit++;
            }
        }
    }
}