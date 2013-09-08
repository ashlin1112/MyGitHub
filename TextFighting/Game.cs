using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFighting
{
    class Game
    {
        Player p1;
        Player p2;

        // 遊戲開始  依序輸入兩位玩家的名字、生命、攻擊力、防禦力
        public Game()
        {
            p1 = new Player();
            p2 = new Player();
            Console.WriteLine("Input Player's Name");
            p1.name = Console.ReadLine();
            Console.WriteLine("Input Live (5~10)");
            p1.lifePoint = Convert.ToInt32( Console.ReadLine() );
            Console.WriteLine("Input Attack Power (1~5)");
            p1.attackPower = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Defense Power(1~5)");
            p1.defensePower = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Input Player's Name");
            p2.name = Console.ReadLine();
            Console.WriteLine("Input Live (5~10)");
            p2.lifePoint = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Attack Power (1~5)");
            p2.attackPower = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Defense Power (1~5)");
            p2.defensePower = Convert.ToInt32(Console.ReadLine());

            p1.setSkill(0);
            p2.setSkill(1);
            
            Console.ReadLine();
        }
        public void fightMyself()
        {
            p1.lifePoint = 0;
        }

        public void fight()
        {
            while (true)
            {
                Console.WriteLine(p1.name + "使出" +  p1.skillName + "打向 " + p2.name);
                int p1a = p1.attack(),
                    p2d = p2.defense();
                int damage = p1a - p2d;
                
                // 當爆擊發生  顯示字幕
                if (p1a == 7)
                {
                    // 傷害寫入
                    p2.damage(damage);
                    Console.WriteLine(p1.name + "發動爆擊，" + p2.name + "受到" + damage + "傷害  剩下" + p2.lifePoint + "血量");
                }
                // 一般傷害
                else if (damage > 0)
                {
                    p2.damage(damage);
                    Console.WriteLine(p2.name + "受到" + damage + "傷害  剩下" + p2.lifePoint + "血量");
                }
                // 傷害低於防禦值=>擋下攻擊
                else
                    Console.WriteLine(p2.name + " 擋下了攻擊");
                Console.ReadLine();
                // 當生命等於 0 時  顯示擊敗訊息並結束遊戲
                if (p2.lifePoint <= 0)
                {
                    Console.WriteLine(p1.name + " 擊敗了" + p2.name);
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine(p2.name + "使出" + p2.skillName + "打向 " + p1.name);
                p1a = p2.attack();
                p2d = p1.defense();
                damage = p1a - p2d;
                // 當爆擊發生  顯示字幕
                if (p1a == 7)
                {
                    // 傷害寫入
                    p1.damage(damage);
                    Console.WriteLine(p2.name + "發動爆擊，" + p1.name + "受到" + damage + "傷害  剩下" + p1.lifePoint + "血量");
                }
                // 一般傷害
                else if (damage > 0)
                {
                    p1.damage(damage);
                    Console.WriteLine(p1.name + "受到" + damage + "傷害  剩下" + p1.lifePoint + "血量");
                }
                // 傷害低於防禦值=>擋下攻擊
                else
                    Console.WriteLine(p1.name + " 擋下了攻擊");
                Console.ReadLine();
                // 當生命等於 0 時  顯示擊敗訊息並結束遊戲
                if (p1.lifePoint <= 0)
                {
                    Console.WriteLine(p2.name + " 擊敗了" + p1.name);
                    Console.ReadLine();
                    break;
                }
            }
        }


    }
}
