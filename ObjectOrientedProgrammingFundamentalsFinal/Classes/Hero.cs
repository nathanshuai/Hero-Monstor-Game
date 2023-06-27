using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public class Hero:Character
    {
        public Weapon EquippedWeapon;
        public Armour EquippedArmour;

        private HashSet<Weapon> _weapons = new HashSet<Weapon>();
        private HashSet<Armour> _armours = new HashSet<Armour>();
        public HashSet<Weapon> GetWeapons() { return _weapons.ToHashSet(); }
        public HashSet<Armour> GetArmours() { return _armours.ToHashSet(); }

        public Hero(string name, int strength = 5, int defence = 1, int originalHealth = 40, int currentHealth = 0) : base(name, strength, defence, originalHealth, currentHealth)
        {
            Name = name;
            CurrentHealth = originalHealth;
            EquippedWeapon = new Weapon("Default Weapon", 1);
            EquippedArmour = new Armour("Default Armour", 1);

        }
        

        public void GetStats()
        {
            Console.WriteLine("Hero Stats:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Base Strength: {Strength}");
            Console.WriteLine($"Base Defense: {Defence}");
            Console.WriteLine($"Original Health: {OriginalHealth}");
            Console.WriteLine($"Current Health: {CurrentHealth}");
        }


        public string GetInventory()
        {
            string inventory = $"Equipped Weapon: {EquippedWeapon.Name}, Power: {EquippedWeapon.Power}" +
                               Environment.NewLine +
                               $"Equipped Armour: {EquippedArmour.Name}, Power: {EquippedArmour.Power}";

            return inventory;
        }


        public Weapon CreateWeapon(string name, int power)
        {
            Weapon newWeapon = new Weapon(name, power);
            _weapons.Add(newWeapon);
            return newWeapon;
        }
        

        public void EquipWeapon(Hero hero, Weapon weapon )
        { 
           hero.EquippedWeapon = weapon;   
        }

        public void GetWeaponsList()
        {
            _weapons.Clear();
            CreateWeapon("God Sword", 2);
            CreateWeapon("Top Gun", 3);
            CreateWeapon("Gost Knife", 4);
            Console.WriteLine($"Weapon list:");
            foreach (Weapon weapon in _weapons)
            {
                Console.WriteLine($"name: {weapon.Name}  power:{weapon.Power}");
            }
        }

        public Armour CreateArmour(string name, int power)
        {
            Armour newArmour = new Armour(name, power);
            _armours.Add(newArmour);
            return newArmour;
        }

        public void EquipArmour(Hero hero, Armour armour)
        {
            hero.EquippedArmour = armour;
        }
        public void GetArmoursList()
        {
            _armours.Clear();
            CreateArmour("Silver Shield", 2);
            CreateArmour("Fire Plate", 3);
            CreateArmour("Golden Shield", 4);
            Console.WriteLine($"Armour list:");
            foreach (Armour armour in _armours)
            {
                Console.WriteLine($"name: {armour.Name}  power:{armour.Power}");
            }
        }


    }

   
}
