using System;
using System.Threading;
namespace WNS{
    public class Ninja: Human{
        public Ninja (string person): base(person){
            dexterity = 175;
        }
        public void steal (object obj){
            Human enemy = obj as Human;
            if (enemy != null){
                attack(enemy);
                health += 10;
            }
        }
        public void get_away(){
            health -= 15;
        }
    }
}