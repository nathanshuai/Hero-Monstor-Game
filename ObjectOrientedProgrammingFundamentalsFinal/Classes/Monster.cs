using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public class Monster
    {
        private string _name;
        public string monsName { get { return _name; } }
        private int _strength;
        public int Strength { get { return _strength; } }
        private int _defence;
        public int Defence { get { return _defence; } }
        private int _originalHealth;
        public int OriginalHealth { get { return _originalHealth; } }


        public int CurrentHealth;

        public Monster( string monsName, int Strength, int Defence, int OriginHealth) 
        {
            _name = monsName;
            _defence = Defence;
            _strength = Strength;
            _originalHealth = OriginHealth;
            CurrentHealth = OriginHealth;
        }

        
    }
}
