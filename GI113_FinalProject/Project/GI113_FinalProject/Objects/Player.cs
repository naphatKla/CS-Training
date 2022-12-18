using System;
using System.Threading;
using GI113_FinalProject.UI;

namespace GI113_FinalProject.Objects
{
    public class Player
    {
        protected string name;
        protected string playerClass;
        protected string classDescription;
        protected int hp;
        protected int mp;
        protected int atk;
        protected int maxHp;
        protected int maxMp;
        protected int maxAtk;
        protected int maxCriRate;
        protected int damage;
        private ConsoleColor color;
        protected int criRate;
        protected Random rnd = new Random();
        protected string[] skills;
        protected int[] manaSkillDrains;
        protected bool isLife = true;

        public Player()
        {
            MaxHp = 100;
            MaxMp = 100;
            MaxAtk = 200;
            MaxCriRate = 100;
            hp = 100;
            mp = 100;
            atk = 10;
            criRate = 10;
            playerClass = "Novice";
            name = "Novice";
        }

        public int MaxCriRate { get => maxCriRate; set => maxCriRate = value; }
        public int MaxAtk { get => maxAtk; set => maxAtk = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int MaxMp { get => maxMp; set => maxMp = value; }
        public int Atk { get => atk; set => atk = value; }
        public string Name { get => name; set => name = value; }

        public int CriRate { get => criRate; set => criRate = value; }
        public string ClassDescription { get => classDescription; set => classDescription = value; }
        public int Damage { get => damage; set => damage = value; }
        public ConsoleColor Color { get => color; set => color = value; }
        public string PlayerClass => playerClass;

        public string[] Skills { get => skills; set => skills = value; }

        public int[] ManaSkillDrains { get => manaSkillDrains; set => manaSkillDrains = value; }

        public bool IsLife { get => isLife; set => isLife = value; }

        public void SetColor(ref Player player,ConsoleColor color)
        {
            player.Color = color;
        }
        public void PrintStats()
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Class : {playerClass}");
            Console.WriteLine($"HP : {hp}");
            Console.WriteLine($"MP : {mp}");
            Console.WriteLine($"ATK : {atk}");
            Console.WriteLine($"Critical Rate : {criRate} %");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("===============================");
            Console.ResetColor();
        }

        public virtual void TakeDamage(int damage)
        {
            IsLife = true;
            this.Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
                IsLife = false;
            }
        }
        
        public void Attack(ref Boss boss)
        {
            Console.Clear();
            if (rnd.Next(0, 101) < criRate)
            {
                Damage = rnd.Next(Atk - 5, Atk + 15) * 2;
                Console.ForegroundColor = color;
                Text.TextPrint($" {Name}",1,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" Attack",1,false,true,false);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Text.TextPrint($" Critical Hit!! {Damage} damage",5,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" to Boss {boss.Name}",1,false,true,false);
            }
            else
            {
                Damage = rnd.Next(Atk - 5, Atk + 15) * 2;
                Console.ForegroundColor = color;
                Text.TextPrint($" {Name}",1,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" Attack",1,false,true,false);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Text.TextPrint($" {Damage} damage",1,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" to Boss {boss.Name}",1,false,true,false);
            }
            boss.Hp -= damage;
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        public virtual void UseSkill(int skillIndex,ref Boss boss,ref Player[] players)
        {
            
        }
        
        
        public virtual void SkillDescription(int skillIndex)
        {
            
        }
        public void SelectClass(ref Player player, ref Bar hpBar, ref Bar mpBar, ref Bar atkBar, ref Bar criBar)
        {
            
            int classIndex = Menu.SelectClass(new[] { "Tank","Support", "Carry", "Random" },ref hpBar,ref mpBar,ref atkBar,ref criBar);

            if (classIndex == 3)
            {
                classIndex = rnd.Next(0, 3);
            }
            
            if (classIndex == 0)
            {
                player = new Tank();
            }
            else if (classIndex == 1)
            {
                player = new Support();
            }
            else if (classIndex == 2)
            {
                player = new Carry();
            }

            player.Name = this.name;
        }
    }
    
    public class Tank : Player
    {
        private bool isIronbody = false;
        public Tank()
        {
            MaxHp = 300;
            MaxMp = 120;
            hp = MaxHp;
            mp = MaxMp;
            atk = 25;
            criRate = 30;
            playerClass = "Tank";
            ClassDescription = "Tank has the highest hp with CC skills and party defense skills.";
            skills = new[] { "Party Protected", "Iron Body", "Roar" };
            manaSkillDrains = new[] { 40, 20, 10 };
        }

        public override void TakeDamage(int damage)
        {
            if (isIronbody)
            {
                base.TakeDamage(damage / 4);
                isIronbody = false;
            }
            else
            {
                base.TakeDamage(damage);
            }
            
        }
           public override void UseSkill(int skillIndex,ref Boss boss,ref Player[] players)
            {
                if (Mp < manaSkillDrains[skillIndex])
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Text.TextPrint($" Can't use skill",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" because",1,false,true,false);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Text.TextPrint($" have not enough MP",1,false,true,false);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Text.TextPrint($" Skip {Name} turn",1,false,true,false);
                    Console.ResetColor();
                }
                else if (skillIndex == 0)   // Party Protected
                {

                    boss.CanAttack = false;
                    Mp -= manaSkillDrains[skillIndex];
                    
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" effect to",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" boss {boss.Name} can't attack for 1 turn",1,false,true,false);
                    Console.ResetColor();
                }
                else if (skillIndex == 1)  // Iron body
                {
                    isIronbody = true;
                    Mp -= manaSkillDrains[skillIndex];
                    
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" effect to",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name} take less damage 75% for 1 turn",5,false,true,false);
                    Console.ResetColor();
                }
                else if (skillIndex == 2)    // Roar
                {
                    boss.LockTarget = true;
                    boss.BossTarget = Name;
                    Mp -= manaSkillDrains[skillIndex];
                    
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" effect to",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" Force the boss to attack {name} for 1 turn",1,false,true,false);
                    Console.ResetColor();
                }
            }
        public override void SkillDescription(int skillIndex)
        {
            if (skillIndex == 0)  // Party Protected
            {
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}",0,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" effect to",0,false,true,false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" boss can't attack for 1 turn",0,false,true,false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.TextPrint($" (-{manaSkillDrains[skillIndex]} MP)",0,false,true,false);
                Console.ResetColor();

            }
            else if (skillIndex == 1)  // Iron Body
            {
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}",0,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" effect to",0,false,true,false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" {Name} take less damage 75% for 1 turn",0,false,true,false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.TextPrint($" (-{manaSkillDrains[skillIndex]} MP)",0,false,true,false);
                Console.ResetColor();

            }
            else if (skillIndex == 2) // Roar
            {
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}",0,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" effect to",0,false,true,false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" Force the boss to attack tank for 1 turn",0,false,true,false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.TextPrint($" (-{manaSkillDrains[skillIndex]} MP)",0,false,true,false);
                Console.ResetColor();

            }
        }
    }

    /*
    public class Mage : Player
    {
        public Mage()
        {
            MaxHp = 150;
            MaxMp = 200;
            hp = 150;
            mp = 200;
            atk = 65;
            playerClass = "Mage";
            ClassDescription = "Mage ...";
        }
    }
    */
    
    public class Support : Player
    {
        public Support()
        {
            MaxHp = 180;
            MaxMp = 240;
            hp = maxHp;
            mp = maxMp;
            atk = 25;
            playerClass = "Support";
            ClassDescription = "Support has the highest MP with buff skills and healing skills";
            criRate = 10;
            skills = new[] { "Party HP Recovery", "Party MP Recovery", "Party ATK Buff" };
            manaSkillDrains = new[] { 40, 100, 100 };
        }
         public override void UseSkill(int skillIndex,ref Boss boss,ref Player[] players)
            {
                if (Mp < manaSkillDrains[skillIndex])
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Text.TextPrint($" Can't use skill",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" because",1,false,true,false);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Text.TextPrint($" have not enough MP",1,false,true,false);
                    Console.ResetColor();
                }
                else if (skillIndex == 0)   // Party HP Recovery
                {
                    int healPoint = rnd.Next(50, 101);
                    foreach (var player in players)
                    {
                        
                        player.Hp += healPoint;
                        if (player.Hp > player.MaxHp)
                        {
                            player.Hp =  player.MaxHp;
                        }
                        
                    }
                    Mp -= manaSkillDrains[skillIndex];
                    
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" effect to",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" Heal party for {healPoint} point",1,false,true,false);
                    Console.ResetColor();
                    Console.WriteLine("\n\n");
                    Menu.SelectMenu(new[] { "Continue" });
                    Menu.ShowCurrentStats(players);
                }
                else if (skillIndex == 1)  // Party MP Recovery
                {
                    int mpRecoveryPoint = rnd.Next(50, 101);
                    foreach (var player in players)
                    {
                        if (player.Name != this.name)
                        {
                            player.Mp += mpRecoveryPoint;
                        }

                        if (player.Mp > player.MaxMp)
                        {
                            player.Mp = player.MaxMp;
                        }
                    }
                    Mp -= manaSkillDrains[skillIndex];
                    
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" effect to",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" all player expect {Name} recovery MP for {mpRecoveryPoint} point",5,false,true,false);
                    Console.ResetColor();
                    Console.WriteLine("\n\n");
                    Menu.SelectMenu(new[] { "Continue" });
                    Menu.ShowCurrentStats(players);
                }
                else if (skillIndex == 2)    // Party ATK Buff
                {
                    int atkBuff = 15;
                    foreach (var player in players)
                    {
                        player.Atk += atkBuff;
                    }
                    Mp -= manaSkillDrains[skillIndex];
                    
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}",1,false,true,false);
                    Console.ResetColor();
                    Text.TextPrint($" effect to",1,false,true,false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" all player increase ATK for {atkBuff} Point",1,false,true,false);
                    Console.ResetColor();
                    Console.WriteLine("\n\n");
                    Menu.SelectMenu(new[] { "Continue" });
                    Menu.ShowCurrentStats(players);
                }
            }

         public override void SkillDescription(int skillIndex)
         {
             if (skillIndex == 0) // Party HP Recovery
             {
                 Console.ForegroundColor = Color;
                 Text.TextPrint($" {skills[skillIndex]}", 0, false, true, false);
                 Console.ResetColor();
                 Text.TextPrint($" effect to", 0, false, true, false);
                 Console.ForegroundColor = Color;
                 Text.TextPrint($" Heal party for 50-100 point", 0, false, true, false);
                 Console.ForegroundColor = ConsoleColor.Blue;
                 Text.TextPrint($" (-{manaSkillDrains[skillIndex]}) MP",0,false,true,false);
                 Console.ResetColor();
             }
             else if (skillIndex == 1) // Party MP Recovery
             {
                 Console.ForegroundColor = Color;
                 Text.TextPrint($" {skills[skillIndex]}", 0, false, true, false);
                 Console.ResetColor();
                 Text.TextPrint($" effect to", 0, false, true, false);
                 Console.ForegroundColor = Color;
                 Text.TextPrint($" all player expect user recovery MP for 50-100 point", 0, false, true, false);
                 Console.ForegroundColor = ConsoleColor.Blue;
                 Text.TextPrint($" (-{manaSkillDrains[skillIndex]}) MP",0,false,true,false);
                 Console.ResetColor();
             }
             else if (skillIndex == 2) // Party ATK Buff
             {
                 int atkBuff = 15;
                 Console.ForegroundColor = Color;
                 Text.TextPrint($" {skills[skillIndex]}", 0, false, true, false);
                 Console.ResetColor();
                 Text.TextPrint($" effect to", 0, false, true, false);
                 Console.ForegroundColor = Color;
                 Text.TextPrint($" all player increase ATK for {atkBuff} Point", 0, false, true, false);
                 Console.ForegroundColor = ConsoleColor.Blue;
                 Text.TextPrint($" (-{manaSkillDrains[skillIndex]}) MP",0,false,true,false);
                 Console.ResetColor();
             }
         }
    }
    
    public class Carry : Player
    {
        public Carry()
        {
            MaxHp = 150;
            MaxMp = 120;
            hp = maxHp;
            mp = maxMp;
            atk = 100;
            playerClass = "Carry";
            ClassDescription = "Carry has the highest ATK with critical buff and powerful skills";
            criRate = 50;
            skills = new[] { "Critical Buff", "Super Arrow", "Quick Shot"};
            manaSkillDrains = new[] { 40 , 60 , 20};
        }

        public override void UseSkill(int skillIndex, ref Boss boss, ref Player[] players)
        {
            if (Mp < manaSkillDrains[skillIndex])
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = Color;
                Text.TextPrint($" {Name}", 1, false, true, false);
                Console.ForegroundColor = ConsoleColor.Red;
                Text.TextPrint($" Can't use skill", 1, false, true, false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}", 1, false, true, false);
                Console.ResetColor();
                Text.TextPrint($" because", 1, false, true, false);
                Console.ForegroundColor = ConsoleColor.Red;
                Text.TextPrint($" have not enough MP", 1, false, true, false);
                Console.ResetColor();
            }
            else if (skillIndex == 0) // Critical Buff
            {
                CriRate += 15;
                Mp -= manaSkillDrains[skillIndex];

                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = Color;
                Text.TextPrint($" {Name}", 1, false, true, false);
                Console.ResetColor();
                Text.TextPrint($" use skill ", 1, false, true, false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}", 1, false, true, false);
                Console.ResetColor();
                Text.TextPrint($" effect to", 1, false, true, false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" Critical Rate of {Name} increase for 15%", 1, false, true, false);
                Console.ResetColor();
                Console.WriteLine("\n\n");
                Menu.SelectMenu(new[] { "Continue" });
                Menu.ShowCurrentStats(players);
            }
            else if (skillIndex == 1) // Super Arrow
            {
                if (rnd.Next(0, 101) < CriRate) // Cri
                {
                    Damage = rnd.Next(atk + 50, atk + 100) * 2;
                    boss.TakeDamage(damage);

                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" attack to boss {boss.Name}", 1, false, true, false);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Text.TextPrint($" Critical Hit!!", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" for", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Damage} damage", 1, false, true, false);
                    Console.ResetColor();
                    
                }
                else
                {
                    Damage = rnd.Next(atk + 50, atk + 100);
                    boss.TakeDamage(damage);

                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" attack to boss {boss.Name}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" for", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Damage} damage", 1, false, true, false);
                    Console.ResetColor();
                }

                Mp -= manaSkillDrains[skillIndex];
            }
            else if (skillIndex == 2) // quick shot
            {
                if (rnd.Next(0, 101) < CriRate) // Cri
                {
                    Damage = rnd.Next(atk + 20, atk + 40) * 2;
                    boss.TakeDamage(damage);

                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" attack to boss {boss.Name}", 1, false, true, false);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Text.TextPrint($" Critical Hit!!", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" for", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Damage} damage", 5, false, true, false);
                    Console.ResetColor();
                }
                else
                {
                    Damage = rnd.Next(atk + 20, atk + 40);
                    boss.TakeDamage(damage);

                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Name}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" use skill ", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {skills[skillIndex]}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" attack to boss {boss.Name}", 1, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" for", 1, false, true, false);
                    Console.ForegroundColor = Color;
                    Text.TextPrint($" {Damage} damage", 1, false, true, false);
                    Console.ResetColor();
                }
            }
        }

        public override void SkillDescription(int skillIndex)
        {
            if (skillIndex == 0) // Critical Buff
            {
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}", 0, false, true, false);
                Console.ResetColor();
                Text.TextPrint($" effect to", 0, false, true, false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" increase your critical rate for 15%", 0, false, true, false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.TextPrint($" (-{manaSkillDrains[skillIndex]}) MP",0,false,true,false);
                Console.ResetColor();
            }
            else if (skillIndex == 1) // Super Arrow
            {
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}", 0, false, true, false);
                Console.ResetColor();
                Text.TextPrint($" attack boss with", 0, false, true, false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" the most powerful skill", 0, false, true, false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.TextPrint($" (-{manaSkillDrains[skillIndex]}) MP",0,false,true,false);
                Console.ResetColor();
            }
            else if (skillIndex == 2) // auick shot
            {
                Console.ForegroundColor = Color;
                Text.TextPrint($" {skills[skillIndex]}", 0, false, true, false);
                Console.ResetColor();
                Text.TextPrint($" attack boss with", 0, false, true, false);
                Console.ForegroundColor = Color;
                Text.TextPrint($" quick arrow deal a lot of damage", 0, false, true, false);
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.TextPrint($" (-{manaSkillDrains[skillIndex]}) MP",0,false,true,false);
                Console.ResetColor();
            }
        }
    }
}