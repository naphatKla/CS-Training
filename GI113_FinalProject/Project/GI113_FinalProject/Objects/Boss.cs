using System;
using GI113_FinalProject.UI;

namespace GI113_FinalProject.Objects
{
    public class Boss
    {
        protected string name;
        protected int hp;
        protected int atk;
        protected int maxHp;
        protected int maxMp;
        protected int damage;
        protected string picture;
        protected Random rnd = new Random();
        protected bool canAttack = true;
        protected bool lockTarget = false;
        protected string bossTarget;
        protected bool isLife = true;


        public bool CanAttack { get => canAttack; set => canAttack = value; }
        public string Picture { get => picture; set => picture = value; }
        public string Name { get => name; set => name = value; }
        public int Hp { get => hp; set => hp = value; }

        public int Atk { get => atk; set => atk = value; }

        public int MaxHp { get => maxHp; set => maxHp = value; }

        public bool LockTarget { get => lockTarget; set => lockTarget = value; }

        public string BossTarget { get => bossTarget; set => bossTarget = value; }

        public bool IsLife { get => isLife; set => isLife = value; }


        public void Attack(ref Player[] playerTarget)
        {
            if (canAttack)
            {
                int randomNumber = rnd.Next(1, 100);
                int randomTarget = 0;

                if (lockTarget)
                {
                    foreach (var player in playerTarget)
                    {
                        if (player.Name == bossTarget)
                        {
                            randomTarget = Array.IndexOf(playerTarget,player);
                        }
                    }
                }
                else
                {
                    do
                    {
                        randomTarget = rnd.Next(0, playerTarget.Length);
                        
                    } while (playerTarget[randomTarget].IsLife == false);
                }
                
                if (randomNumber > 90)    // 10% Critical
                {
                    damage = rnd.Next(atk - 5, atk + 10) * 2;
                    
                    Console.Clear();
                    Console.WriteLine();
                    Text.TextPrint($" Boss {Name}",5,false,true,false);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Text.TextPrint($" Critical Attack {damage} damage", 5, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" to", 5, false, true, false);
                    Console.ForegroundColor = playerTarget[randomTarget].Color;
                    Text.TextPrint($" {playerTarget[randomTarget].Name}",5,false,true,false);
                    Console.ResetColor();
                }
                else
                {
                    damage = rnd.Next(atk - 5, atk + 10);
                    
                    Console.Clear();
                    Console.WriteLine();
                    Text.TextPrint($" Boss {Name}",5,false,true,false);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Text.TextPrint($" Attack {damage} damage", 5, false, true, false);
                    Console.ResetColor();
                    Text.TextPrint($" to", 5, false, true, false);
                    Console.ForegroundColor = playerTarget[randomTarget].Color;
                    Text.TextPrint($" {playerTarget[randomTarget].Name}",5,false,true,false);
                    Console.ResetColor();
                }

                playerTarget[randomTarget].TakeDamage(damage);
                lockTarget = false;
                
                Console.WriteLine("\n\n");
                Menu.SelectMenu(new[] { "Continue" });
                Menu.ShowCurrentStats(playerTarget);
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Text.TextPrint($" Boss {Name} can't attack",5,false,true,false);
                Console.ResetColor();
            }
            
        }

        public void TakeDamage(int damage)
        {
            this.hp -= damage;

            if (hp <= 0)
            {
                hp = 0;
                IsLife = false;
            }
        }
        
        public void skillJOKNA(ref Player[] players)     // attack random player by 10 hit ( 25 dam )
        {
            if (canAttack)
            {
                int[] hits = new[] { 0, 0, 0, 0 };
     
                int randomTarget = 0;

                if (lockTarget)
                {
                    foreach (var player in players)
                    {
                        if (player.Name == bossTarget)
                        {
                            randomTarget = Array.IndexOf(players,player);
                        }
                    }
                }
                
                for (int i = 0; i < 10; i++)
                {
                    if (lockTarget)
                    {
                        players[randomTarget].TakeDamage(25);
                        hits[randomTarget] += 1;
                    }
                    else
                    {
                        do
                        {
                            randomTarget = rnd.Next(0, players.Length);
                            
                        } while (players[randomTarget].IsLife == false);

                        players[randomTarget].TakeDamage(25);
                        hits[randomTarget] += 1;
                    }
                }

                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Text.TextPrint($" {Name}",1,false,true,false);
                Console.ResetColor();
                Text.TextPrint($" use skill",1,false,true,false);
                Console.ForegroundColor = ConsoleColor.Red;
                Text.TextPrint($" SuperSkill \"JOK NA\"",1,false,true,true);
                Console.ResetColor();
                hits[randomTarget] += 1;
                
                for (int i = 0; i < players.Length; i++)
                {
                    int totalDamage = hits[i] * 25;
                    Console.ForegroundColor = players[i].Color;
                    Text.TextPrint($" {players[i].Name} was attacked for {hits[i]} hits and take {totalDamage} damage ",1,false,true,true);
                }
                Console.ResetColor();
                lockTarget = false;
                
                Console.WriteLine("\n\n");
                Menu.SelectMenu(new[] { "Continue" });
                Menu.ShowCurrentStats(players);
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Text.TextPrint($" Boss {Name} can't attack",5,false,true,false);
                Console.ResetColor();
            }
        }

        public void skillGAYRAY()     // heal 100 - 300 unit
        {
            int randomHeal = rnd.Next(100, 301);
            hp += randomHeal;

            if (Hp > MaxHp)
            {
                Hp = MaxHp;
            }
            
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Text.TextPrint($" {Name}",1,false,true,false);
            Console.ResetColor();
            Text.TextPrint($" use skill",1,false,true,false);
            Console.ForegroundColor = ConsoleColor.Red;
            Text.TextPrint($" Healing Skill \"GAY RAY\"",1,false,true,false);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Text.TextPrint($" and heal for {randomHeal} point",1,false,true,false);
            Console.ResetColor();
        }
    }

    public class BossPTO : Boss
    {
        public BossPTO()
        {
            maxHp = 1000;
            hp = 1000;
            atk = 25;
            name = "PTO";
            picture = BossPicture.PTO;
        }
    }
}