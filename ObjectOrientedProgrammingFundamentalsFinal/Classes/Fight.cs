using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public class Fight
    {
        private Hero _hero;
        private Monster _monster;
        public Hero hero { get { return _hero; } }
        public Monster monster { get { return _monster; } }

        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;
         
        }

        public void HeroTurn()
        {
            int heroDamage = hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defence;
            monster.CurrentHealth -= heroDamage;

            Console.WriteLine($"Hero attacked Monster '{monster.monsName}' for '{heroDamage}' damage.");
            Console.WriteLine($"Monster's current health: {Math.Max(0, monster.CurrentHealth)}");
        }

        public void MonsterTurn()
        {
            int monsterDamage = monster.Strength - (hero.BaseDefence + hero.EquippedArmour.Power);
            hero.CurrentHealth -= monsterDamage;

            Console.WriteLine($"Monster attacked Hero '{hero.UserName}' for '{monsterDamage}' damage.");
            Console.WriteLine($"Hero's current health: {Math.Max(0, hero.CurrentHealth)}");
        }

        public bool Win()
        {
            if (monster.CurrentHealth <= 0)
            {
                return true;
            }
            return false;
        }

        public bool Lose()
        {
            if (hero.CurrentHealth <= 0)
            {
                hero.CurrentHealth = hero.OriginalHealth;
                return true;
            }
            return false;
        }


    }

}
