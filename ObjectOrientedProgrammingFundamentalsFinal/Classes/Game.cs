using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace ObjectOrientedProgrammingFundamentalsFinal.Classes
{
    public class Game
    {
        public HashSet<Weapon> weapons = new HashSet<Weapon>();
        public HashSet<Armour> armours = new HashSet<Armour>();
        public HashSet<Hero> heroes = new HashSet<Hero>();
        public HashSet<Monster> monsters = new HashSet<Monster>();
        public HashSet<Fight> fights = new HashSet<Fight>();
        public int FightsWon = 0;
        public int FightsLost = 0;
        public int Coins = 0;

        public Monster CreateMonster(string monsName, int Strength, int Defence, int OriginHealth)
        {
            Monster newMonster = new Monster(monsName, Strength, Defence, OriginHealth);
            monsters.Add(newMonster);
            return newMonster;
        }
        public Hero? CreateHero(string name)
        {
            try
            {
                Hero newHero = new Hero(name);
                heroes.Add(newHero);
                return newHero;
            } catch (Exception ex)
            {
                Console.WriteLine($"Unable to create new user: {ex.Message}");
                return null;
            }
        }


        public void Start()
        {
            
            Console.WriteLine("Welcome to the Role-Playing Game!");
            Hero newHero = null;
            bool userInput = false;

            while (!userInput)
            {
                Console.Write("Enter your name: ");
                string Input = Console.ReadLine();

                if (string.IsNullOrEmpty(Input) || string.IsNullOrWhiteSpace(Input))
                {
                    Console.WriteLine("UserName cannot be null or empty, or contain only whitespace");
                }
                else
                {
                    newHero = CreateHero(Input);
                    Console.WriteLine($"New Hero '{newHero.Name}'has been created! ");
                    userInput = true;
                }
                Console.WriteLine();  
            }
            
            CreateMonster("Decayman^-^", 9, 1, 17);
            CreateMonster("Sorrowbrood~~", 7, 1, 18);
            CreateMonster("Vampface", 7, 1, 29);
            CreateMonster("Fetidcreep", 8, 1, 14);
            CreateMonster("The Icy Freak", 9, 1, 13);
            CreateMonster("Dawntalon", 7, 1, 40);
            DisplayMainMenu(newHero);
        }

        public void DisplayMainMenu(Hero hero)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Display Statistics");
                Console.WriteLine("2. Display Inventory");
                Console.WriteLine("3. Fight");
                Console.WriteLine("4. Display Hero Wallet");
                Console.WriteLine("5. Display Hero's Static");
                Console.WriteLine("6. Spend Hero's Coins");
                Console.WriteLine("0. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        GetStats(hero);
                        continue;
                    case "2":
                        Console.WriteLine(hero.GetInventory());
                        DisplayOptionsTochangeEquipment(hero);
                        continue;
                    case "3":
                        StartFight(hero);
                        continue;
                    case "4":
                        Console.WriteLine($"Number of Coins won: {Coins}");
                        continue;
                    case "5":
                        hero.GetStats();
                        continue;
                    case "6":
                        SpendCoins(hero);
                        continue;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter the number of 1,2,3,4,5,6,0.");
                        break;
                }

                Console.WriteLine();
            }
        }
        public void GetStats(Hero hero)
        {
            Console.WriteLine($"Hero '{hero.Name}' Statistics:");
            Console.WriteLine($"Number of games played: {fights.Count}");
            Console.WriteLine($"Number of 'Fights' won: {FightsWon}");
            Console.WriteLine($"Number of 'Fights' lost: {FightsLost}");
        }
        
        public void DisplayOptionsTochangeEquipment(Hero hero)
        {
            bool exitEquip = false;
            
            while (!exitEquip)
            {
                Console.WriteLine("Equipment Options:");
                Console.WriteLine("1. Go to Equip Weapon");
                Console.WriteLine("2. Go to Equip Armour");
                Console.WriteLine("0. Exit to Main Menu");
                
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        hero.GetWeaponsList();
                        weapons = hero.GetWeapons();
                        Console.WriteLine("Enter the power of weapon which one you want to equip");
                        
                        int power = 0;
                        string powerInput = Console.ReadLine();
                        if (int.TryParse(powerInput, out power))
                        {
                            Weapon foundWeapon = null;

                            foreach (Weapon weapon in weapons)
                            {
                                if (weapon.Power.Equals(power))
                                {
                                    foundWeapon = weapon;
                                    hero.EquipWeapon(hero, foundWeapon);
                                    Console.WriteLine($"you have changed the Weapon to '{weapon.Name}' and change your weapon's power to '{weapon.Power}'");
                                    break;
                                }
                            }

                            if (foundWeapon == null)
                            {
                                Console.WriteLine("Please enter the power which weapon's is not out of stock");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter the integer of power");
                        }
                        Console.WriteLine("Press Enter to return to the Change Equipment Options Menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        hero.GetArmoursList();
                        armours = hero.GetArmours();
                        Console.WriteLine("Enter the power of Armour which one you want to equip");

                        int armourPower = 0;
                        string armourPowerInput = Console.ReadLine();
                        if (int.TryParse(armourPowerInput, out armourPower))
                        {
                            Armour foundArmour = null;

                            foreach (Armour armour in armours)
                            {
                                if (armour.Power.Equals(armourPower))
                                {
                                    foundArmour = armour;
                                    hero.EquipArmour(hero, foundArmour);
                                    Console.WriteLine($"you have changed the Armour to '{armour.Name}' and change your armour's power to '{armour.Power}'");
                                    break;
                                }
                            }

                            if (foundArmour == null)
                            {
                                Console.WriteLine("Please enter the power which armour's is not out of stock");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter the integer of power");
                        }
                        Console.WriteLine("Press Enter to return to the Change Equipment Options.");
                        Console.ReadLine();
                        break;
                    case "0":
                        exitEquip = true;
                        //DisplayMainMenu(hero);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please Please enter the number of 1,2,0..");
                        break;
                }

                Console.WriteLine();
            }
        }

        public void StartFight(Hero hero)
        {
            Console.WriteLine("Fight started!");
            Monster monster = GetRandomMonster();
            Fight fight = new Fight(hero, monster);

            while (monster != null && monster.CurrentHealth > 0 && hero.CurrentHealth > 0)
            {
                fight.HeroTurn();

                if (fight.Win())
                {
                    Console.WriteLine("You defeated the monster!");
                    FightsWon++;
                    Coins++;
                    monsters.Remove(monster);
                    fights.Add(fight);
                    break;
                }

                fight.MonsterTurn();

                if (fight.Lose())
                {
                    Console.WriteLine("You were defeated by the monster!");
                    FightsLost++;
                    fights.Add(fight);
                    hero.CurrentHealth = hero.OriginalHealth;
                    break;
                }

                Console.WriteLine();
            }
        }

        public Monster GetRandomMonster()
        {
            if (monsters.Count == 0)
            {
                Console.WriteLine("You have defeated all the monsters!!!");
                return null;
            }
            List<Monster> monsterList = new List<Monster>(monsters);
            //generate random monster in a list.
            //https://learn.microsoft.com/en-us/dotnet/api/system.random.next?view=net-7.0
            Random random = new Random();
            int index = random.Next(0, monsterList.Count);
            Monster randomMonster = monsterList[index];

            return randomMonster;
        }


        public void SpendCoins(Hero hero) 
        {
            bool exitEquip = false;

            while (!exitEquip)
            {
                Console.WriteLine("Spend Coins Options");
                Console.WriteLine("1. Increase your BaseStrength");
                Console.WriteLine("2. Increase your BaseDefence");
                Console.WriteLine("3. Increase your CurrentHealth");
                Console.WriteLine("0. Exit to Main Menu");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter the Conis which you want to spend on increasing your basestrength:");

                        int coins = 0;
                        string coinsInput = Console.ReadLine();
                        if (int.TryParse(coinsInput, out coins))
                        {
                            if(coins <= Coins)
                            {
                                hero.Strength = coins + hero.Strength;
                                Coins = Coins - coins;
                                Console.WriteLine($"You have increase your BaseStrength to '{hero.Strength}';");
                            }else
                            {
                                Console.WriteLine("Please enter the amount which is smaller or qual to wallet's coins amount ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter the integer of amount ");
                        }
                        Console.WriteLine("Press Enter to return to the Spend Coins Options Menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Enter the Conis which you want to spend on increasing your basedefence:");

                        int coins2 = 0;
                        string coinsInput2 = Console.ReadLine();
                        if (int.TryParse(coinsInput2, out coins2))
                        {
                            if (coins2 <= Coins)
                            {
                                hero.Defence = coins2 + hero.Defence;
                                Coins = Coins - coins2;
                                Console.WriteLine($"You have increase your BaseStrength to '{hero.Defence}';");
                            }
                            else
                            {
                                Console.WriteLine("Please enter the amount which is smaller or qual to wallet's coins amount ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter the integer of amount ");
                        }
                        Console.WriteLine("Press Enter to return to the Spend Coins Options Menu.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter the Conis which you want to spend on increasing your CurrentHealth:");

                        int coins3 = 0;
                        string coinsInput3 = Console.ReadLine();
                        if (int.TryParse(coinsInput3, out coins3))
                        {
                            if (coins3 <= Coins)
                            {
                                hero.CurrentHealth = coins3 + hero.CurrentHealth;
                                Coins = Coins - coins3;
                                Console.WriteLine($"You have increase your BaseStrength to '{hero.CurrentHealth}';");
                            }
                            else
                            {
                                Console.WriteLine("Please enter the amount which is smaller or qual to wallet's coins amount ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter the integer of amount ");
                        }
                        Console.WriteLine("Press Enter to return to the Spend Coins Options Menu.");
                        Console.ReadLine();
                        break;
                    case "0":
                        exitEquip = true;
                        //DisplayMainMenu(hero);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter the number of 1,2,3,0..");
                        break;
                }

                Console.WriteLine();
            }
        }
        

    }
}   


