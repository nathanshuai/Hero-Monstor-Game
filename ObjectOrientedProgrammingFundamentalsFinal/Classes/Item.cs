using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public abstract class Item
    {
        private string _name;
        public string Name { get { return _name; } }

        private int _power;
        public int Power { get { return _power; } }
        

        public Item(string name, int power)
        {
            _name = name;
            _power = power;
        }
    }
}
