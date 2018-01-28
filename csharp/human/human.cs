namespace human{
    public class Human{
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string n){
            name = n;
        }
        public Human(string n, int str, int intl, int dex, int hp){
            name = n;
            strength = str;
            intelligence = intl;
            dexterity = dex;
            health = hp;
        }
        public void attack(object target){
           Human enemy = target as Human;
           if(enemy !=null){
               enemy.health -=5 *strength;
           } 
        }
        
    }
}