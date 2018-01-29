using System;
using System.Threading;
namespace WNS{
    public class Wizard:Human{
        public Wizard(string person):base(person){
            intelligence = 25;
            health = 50;
        }

        public void heal (){
            health += 10 * intelligence;
        }
        public void fireball (object obj){
            Human enemy = obj as Human;
            Random rnd = new Random();
            int damage = rnd.Next(20, 50);
            if (enemy == null){
                System.Console.WriteLine("Failed Healing");
            }
            else{
                enemy.health -= damage;
            }
        }
    }
}