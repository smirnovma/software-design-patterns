using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Memento
{
    // Originator
    class Hero
    {
        private int patrons = 10; // Number of cartridges
        private int lives = 5; // Number of lives

        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("We make a shot. {0} cartridges remaining", patrons);
            }
            else
                Console.WriteLine("No more ammunition");
        }
        // Preservation of state
        public HeroMemento SaveState()
        {
            Console.WriteLine("Save the game. Parameters: {0} cartridges, {1} lives", patrons, lives);
            return new HeroMemento(patrons, lives);
        }

        // Recovery
        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Restore the game. Parameters: {0} cartridges, {1} lives", patrons, lives);
        }
    }
    // Memento
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
