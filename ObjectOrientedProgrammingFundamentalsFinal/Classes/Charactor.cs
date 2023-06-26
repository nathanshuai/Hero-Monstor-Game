using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public abstract class Character
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _strength;
        public int Strength { get { return _strength; } set { _strength = value; } }

        private int _defence;
        public int Defence { get { return _defence; } set { _defence = value; } }

        private int _originalHealth;
        public int OriginalHealth { get { return _originalHealth; } set { _originalHealth = value; } }

        private int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }

        public Character(string name, int strength, int defence, int originalHealth, int currentHealth)
        {
            _name = name;
            _strength = strength;
            _defence = defence;
            _originalHealth = originalHealth;
            _currentHealth = currentHealth;
        }
    }
}
