using System;

namespace WNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Joe");
            Wizard wizard = new Wizard ("Gandolf");
            Ninja ninja = new Ninja ("Black Ninja");
            Samurai samurai = new Samurai ("Knife");
            Console.WriteLine($"Human stat: Name =>{human.name}");
            Console.WriteLine($"Wizard stat: Name =>{wizard.name}");
            Console.WriteLine($"Ninja stat: Name =>{ninja.name}");
            Console.WriteLine($"Samurai stat: Name =>{samurai.name}");
        }
    }
}
