using System;
using System.Collections.Generic;
using System.Linq;
namespace Exercise
{
    public class Exercise
    {
        public void Exercise_1()
        {
            // โจทย์ให้ปริ้น Hello World
            Console.WriteLine("Hello World");
        }

        public void Exercise_2()
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

        public void Exercise_3()
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

        public void Exercise_4()
        {
            // นำตัวเลขบวกกัน
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 + num2);
        }

        public void Exercise_5()
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

        public void Exercise_6()
        {
            //ปริ้นข้อความธรรมดา
            Console.WriteLine("Welcome to Sommai 108 Eleven Shop");
        }

        public void Exercise_7()
        {
            Console.WriteLine("*\n**\n***\n****\n*****\n******");
        }

        public void Exercise_8()
        {
            Console.WriteLine("    $\n   $ $\n  $ $ $\n $ $ $ $\n$ $ $ $ $");
        }

        public void Exercise_9()
        {
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome {name} !");
            Console.WriteLine("Sommai 108 Eleven Shop");
        }

        public void Exercise_10()
        {
            //รับค่ามา 2 ตัวแล้วเอามา พีชคณิตกัน
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
        }

        public void Exercise_11()
        {
            //คำนวณหาอัตราเร็ว
            int distance = Convert.ToInt32(Console.ReadLine());
            int hours = Convert.ToInt32(Console.ReadLine());
            int result = distance / hours;
            Console.WriteLine($"{result} km/h");
        }

        public void Exercise_12()
        {
            //เอาเลขคูณกันเฉยๆ
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result = num1 * num2;
            Console.WriteLine(result);
        }

        public void Exercise_13()
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 % num2);
        }

        public void Exercise_14()
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

        public void Exercise_15()
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

        public void Exercise_16()
        {
            //ปริ้น A ตามจำนวนรอบ
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("A");
            }
        }

        public void Exercise_17()
        {
            Exercise_2();
        }

        public void Exercise_18()
        {
            //ยกกำลัง
            double num = Convert.ToDouble(Console.ReadLine());
            double pow = Convert.ToDouble(Console.ReadLine());
            double result = Math.Pow(num, pow);
            Console.WriteLine(result);
        }

        public void Exercise_19()
        {
            // Leap year check
            int years = Convert.ToInt32(Console.ReadLine());
            if((years % 4 == 0 && years % 100 != 0) || years % 400 == 0)
                Console.WriteLine("Leap Year");
            else 
                Console.WriteLine("Not a Leap Year");
        }

        public void Exercise_20()
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

        public void Exercise_21()
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

        public void Exercise_22()
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

        public void Exercise_23()
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

        public void Exercise_24()
        {
            // หาเกรด
            List<string> Subject = new List<string>() { "THAI", "MATH", "ENGLISH", "SCIENCE", "SPORT" };
            List<float> Point = new List<float>();
            float tempPoint;
            float sum = 0;

            for (int i = 0; i < Subject.Count; i++)
            {
                tempPoint = Convert.ToSingle(Console.ReadLine());
                Point.Add(tempPoint);
                sum += tempPoint;
            }
            
            for (int i = 0; i < Subject.Count; i++)
            {
                Console.WriteLine($"{Subject[i]} = {Point[i]:f1}");
            }
            
            float GPA = sum / Subject.Count;
            Console.WriteLine("---");
            Console.WriteLine($"GPA = {GPA:f1}");
        }

        public void Exercise_25()
        {
            // รับข้อมูลลุงสมหมาย แล้วปริ้นออกไป
            List<string> Topic = new List<string>() { "Name", "Address", "Gender", "Tel" };
            List<string> value = new List<string>();
            
            for (int i = 0; i <= Topic.Count; i++)
            {
                string temp = Console.ReadLine();
                value.Add(temp);
            }

            value[0] = value[0] + " " + value[1];
            value.RemoveAt(1);
            
            Console.WriteLine("--- Customer Detail ---");
            for (int i = 0; i < value.Count; i++)
            {
                Console.WriteLine($"{Topic[i]} : {value[i]}");
            }
        }

        public void Exercise_26()
        {
            // โรงเรียนของเด็กชาย A
            List<string> Grade = new List<string>() { "A", "B+", "B", "C+", "C", "D+", "D", "F" };
            List<int> Point = new List<int>() { 90, 85, 80, 75, 70, 65, 60,0 };
            int point = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Grade.Count; i++)
            {
                if (point >= Point[i])
                {
                    Console.WriteLine(Grade[i]);
                    break;
                }
            }
        }

        public void Exercise_27()
        {
            //โรงเรียนของเด็กชายเอ มันมีข้อผิดพลาด!
            List<string> Grade = new List<string>() { "A", "B+", "B", "C+", "C", "D+", "D", "F" };
            List<int> Point = new List<int>() { 90, 85, 80, 75, 70, 65, 60,0 };
            int point = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Grade.Count; i++)
            {

                if (point < 0)
                {
                    Console.WriteLine("Error : Value must be greater than or equal to 0.");
                    break;
                }
                else if (point > 100)
                {
                    Console.WriteLine("Error : Value must be less than or equal to 100.");
                    break;
                }
                else if (point >= Point[i])
                {
                    Console.WriteLine(Grade[i]);
                    break;
                }
            }
        }
        
        public void Exercise_28()
        {
            // ไม่ใช่แค่หนึ่งแต่ถึงสาม
            List<int> number = new List<int>();
            int max;
            for (int i = 0; i < 3; i++)
            {
                int temp = Convert.ToInt32(Console.ReadLine());
                number.Add(temp);
            }

            max = number[0];
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] > max)
                {
                    max = number[i];
                }
            }
            
            Console.WriteLine($"MAX : {max}");
        }
        
        public void Exercise_29()
        {
            // เครื่องคิดเงินลุงสมหมาย V.2
            int count = Convert.ToInt32(Console.ReadLine());
            int[] arrNumber = new int[count];
            int sum = 0;
            for (int i = 0; i < arrNumber.Length; i++)
            {
                arrNumber[i] = Convert.ToInt32(Console.ReadLine());
                sum += arrNumber[i];
            }
            Console.WriteLine($"{sum} THB");
        }
        
        public void Exercise_30()
        {
            // ก็แค่เรียงลำดับ
            List<int> number = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                number.Add(Convert.ToInt32(Console.ReadLine()));
            }
            number.Sort(); // sort จากน้อยไปมาก
            number.Reverse();
            for (int i = 0; i < number.Count; i++)
            {
                Console.WriteLine(number[i]);
            }
        }
        
        public void Exercise_31()
        {
            // ก็แค่เรียงลำดับ V.2
            List<int> number = new List<int>();
            int count = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                number.Add(Convert.ToInt32(Console.ReadLine()));
            }
            number.Sort();
            number.Reverse();

            foreach (int i in number)
            {
                Console.WriteLine(i);
            }
        }
        
        public void Exercise_32()
        {
            // ร้านลุงสมหมาย 3.0
            int numberCustumer = Convert.ToInt32(Console.ReadLine());
            List<string> fullname = new List<string>();
            List<int> years = new List<int>();
            List<string> gender = new List<string>();
            for (int i = 0; i < numberCustumer; i++)
            {
                fullname.Add(Console.ReadLine());
                years.Add(Convert.ToInt32(Console.ReadLine()));
                gender.Add(Console.ReadLine());
            }
            
            Console.WriteLine("--Customers Information--");
            for (int i = 0; i < numberCustumer; i++)
            {
                Console.WriteLine($"{fullname[i]} (age : {2017 - years[i]})");
            }
        }
        
        public void Exercise_33()
        {
            // หน้าไปหลังแล้วหลังมาหน้า
            int count = Convert.ToInt32(Console.ReadLine());
            List<int> number = new List<int>();
            for (int i = 0; i < count; i++)
            {
                number.Add(Convert.ToInt32(Console.ReadLine()));
            }

            number.Reverse();
            foreach (var VARIABLE in number)
            {
                Console.WriteLine(VARIABLE);
            }
        }
        
        public void Exercise_34()
        {
            // Factorial
            int number = Convert.ToInt32(Console.ReadLine());
            long fac = 1;
            for (int i = 1; i <= number; i++)
            {
                fac *= i;
            }
            Console.WriteLine(fac);
        }
        
        public void Exercsie_35()
        {
            // จากแสนรวมเป็นหนึ่ง
            string number = Console.ReadLine();
            int result = 0;

            while (number.Length > 1)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    result += Convert.ToInt32(number[i].ToString()); // ถ้าไม่แปลง char เป็น string มันจะเอา ascii code ของ char ไป + แทน
                }

                number = result.ToString();
                result = 0;
            }
            Console.WriteLine(number);
        }
        
        public void Exercise_36()
        {
            //The Password
            // ascii number 
            // ตัวเลข 0-9 id 48 - 57
            // พิมพ์ใหญ่ id 65 - 90
            // พิมพ์เล็ก id 97 - 122
            // นอกนั้นเป็น ปุ่มอื่นๆ และอักษรพิเศษ
            
            string password = Console.ReadLine();
            bool lengthCheck = password.Length >= 3 && password.Length <= 20;
            bool numberCheck = false;
            bool bigLetterCheck = false;
            bool smallLetterCheck = false;
            bool specialLetterCheck = false;
            
            for (int i = 0; i < password.Length && lengthCheck; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    numberCheck = true;
                }
                else if (password[i] >= 65 && password[i] <= 90)
                {
                    bigLetterCheck = true;
                }
                else if(password[i] >= 97 && password[i] <= 122)
                {
                    smallLetterCheck = true;
                }
                else
                {
                    specialLetterCheck = true;
                }
            }

            if (lengthCheck && numberCheck && bigLetterCheck && smallLetterCheck && specialLetterCheck)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
        
        public void Exercise_37()
        {
            //ต้นคริสมาสต์
            int number = Convert.ToInt32(Console.ReadLine());
            int xlimit, ylimit, layerlimit, baseTree;
            layerlimit = number;
            xlimit = number + 1;
            ylimit = 2;
            baseTree = 0;
            
            for (int layer = 1; layer <= layerlimit; layer++) // ปริ้นใบ
            {
                for (int y = 1; y <= ylimit; y++,xlimit++)
                {
                    for (int x = 1; x <= xlimit; x++)
                    {
                        if (x <= number-(y-1))
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                    Console.WriteLine("");
                }
                ylimit++;
                baseTree = xlimit-1;
                xlimit = number + 1;
            }

            ylimit = 2;
            for (int y = 1; y <= ylimit; y++) // ปริ้นฐาน
            {
                for (int x = 1; x <= xlimit && y == 1; x++)
                {
                    if (x == xlimit)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                for (int x = 1; x <= baseTree && y != 1; x++)
                {
                    if (x == xlimit)
                    {
                        Console.Write("V");
                    }
                    else
                    {
                        Console.Write("=");
                    }
                }
                Console.WriteLine("");
            }
        }
        
    }
}