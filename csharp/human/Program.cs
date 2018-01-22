using System;

namespace human
{
    public class human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public human(string n, int str, int intl, int dex, int hp){
            name = n;
            strength = str;
            intelligence = intl;
            dexterity = dex;
            health = hp;
        }
        static void Attack(object target)
        {
            human enemy = target as human;
            if(enemy != null){
                enemy.health -= 5 * strength;
            }
        }
        static void main(){
            
        }
    }
}
