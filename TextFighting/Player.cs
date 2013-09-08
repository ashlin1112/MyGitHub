using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFighting
{

    interface fatalBlow
    {
        Boolean chance();
    }

    class Player  : fatalBlow
    {
        public String name;
        private int _lifePoint;
        private int _attackPower;
        private int _defensePower;
        private Random rand = new Random();
        
        private String[] skillList = { " 橡膠槍 ", " 鬼斬 ", " 千鳥 ", " 螺旋丸 " };
        public String skillName;

        // 從 skillList 中隨機選擇技能名稱  兩個玩家分別取前半和後半的名字，避免招式名稱重複
        public void setSkill( int k )
        {
            int i;
            //Random rand = new Random();
            int n = rand.Next( k * 2, (k + 1) * 2);
            skillName = skillList[n];
            for (i = 0; i < k * 3; i++)
                rand.Next();

        }

        // 保護 _lifePoint, _attackPower 和 _defensePower 當輸入值不符規定時 自動改成1
        public int lifePoint
        {
            get
            {
                return _lifePoint;
            }
            set
            {
                if (value > 10 || value <= 0)
                    _lifePoint = 5;
                else
                    _lifePoint = value;
            }
        }
        public int attackPower
        {
            get
            {
                return _attackPower;
            }
            set
            {
                if (value > 5 || value <= 0 )
                    _attackPower = 1;
                else
                    _attackPower = value;
            }
        }
        public int defensePower
        {
            get
            {
                return _defensePower;
            }
            set
            {
                if (value > 5 || value <= 0)
                    _defensePower = 1;
                else
                    _defensePower = value;
            }
        }

        // 受到傷害時扣除生命  當低於零時  設為零
        public void damage( int damagePoint )
        {
            _lifePoint -= damagePoint;
            if( _lifePoint < 0 )
                _lifePoint = 0;
        }

        // 隨機回傳傷害值和防禦值
        public int attack()
        {
            // 當生命低於3時  有1/2機率可以發動爆擊  為7點傷害
            fatalBlow fatal = new Player();
            if (_lifePoint < 3 && fatal.chance())
                return 7;
            
            // 一般情況  隨機輸出傷害值
            return rand.Next( 1 , _attackPower );
        }
        public int defense()
        {
            //Random rand = new Random();
            return rand.Next(0, _defensePower);
        }
        // 編寫 method
        Boolean fatalBlow.chance()
        {
            Random rand = new Random();
            // 1/2 機率回傳 true
            if (rand.NextDouble() > 0.5)
                return true;
            else
                return false;
        }
        
    
    }
}
