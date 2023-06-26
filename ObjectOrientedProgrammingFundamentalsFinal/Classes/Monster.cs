using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public class Monster : Character
    {

        public Monster(string name, int strength = 0, int defence = 0, int originalHealth = 0, int currentHealth = 0)
            : base(name, strength, defence, originalHealth, currentHealth)
        {
            this.CurrentHealth = originalHealth;
        }
    }
}
