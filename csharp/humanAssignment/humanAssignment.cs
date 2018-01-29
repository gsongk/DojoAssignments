namespace humanAssignment
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public Human(string n){
            name = n;
        }
        public Human(string n, int s, int i, int d, int h){
            name = n;
            strength = s;
            intelligence = i;
            dexterity = d;
            health = h;
        }
        public void Attack(object target){
            Human enemy = target as Human;
            if (enemy != null){
                enemy.health -= 5 * strength;
            }
        }
    }
}
