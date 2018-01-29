using System;
using System.Threading;
namespace WNS
{
    public class Samurai : Human
    {
        public static int count = 0;
        public Samurai(string person) : base(person)
        {
            count ++;
            health = 200;
        }
        public void death_blow(object obj)
        {
            Human enemy = obj as Human;
            if (enemy != null){
                if (enemy.health >=50){
                    enemy.health = 0;
                }
            }
        }
        public void meditate()
        {
            health = 200;
        }
        public static void how_many(){
            Console.WriteLine(count);
        }
    }
}