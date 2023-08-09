### Hero-Monstor

##For this project, we will be creating a “Role-Playing Game” as a console application. 
In this application, the console will prompt the user to take different actions and then display information based on the outcome.

The User Experience of the Game Sequence will be as follows:

1. The game will first ask for the Player’s name. Pressing “Enter” will save that name.
2. The game will present a Main Menu. Its options will be selected by pressing an associated letter or number. The prompt will be repeated on an invalid choice. The options are:
	1. Display Statistics (number of games played, number of “Fights” won, number of “Fights” lost.
	2. Display Inventory 
		1. This will contain another option to change the Equipped Weapon, change the Equipped Armour, or exit back to the main menu.
		2. On the Change Equipped Weapon and Armour screens, users can select a letter/number value to change the Hero Equipped- Weapon or Equipped-Armour.
	3. Fight, beginning a “fight” with a randomly selected “Monster” from a list of available monsters.
3. In each Fight, the Hero and Monster have Health (a number) which they take turns reducing by “attacking” each other.
	1. The “Hero” takes a “turn” by attacking the Monster.
		1. The “damage” of that attack is calculated as Hero Base Strength + Equipped Weapon Power - Monster Defence. Damage subtracts from the Current Health of the Monster.
			1. For example, if the hero's Base Strength is 5, and the Equipped Weapon's Power is 10, and the Monster's Defence is 3, the resulting damage is 5 + 10 - 3 = 12. If the Monster has 20 health, it is reduced by 12, to 8.
	2. The “Monster” takes a “turn” by attacking the Hero.
		1. The “damage” of that attack is calculated as Monster Strength - Hero Base Defence - Equipped Armour's Power. The result is subtracted from the Hero’s Current Health.
			1. For example, if the Monster's Strength is 20, and the Hero's Base Defence is 3, and their Equipped Armour's Power is 7, then the resulting damage is 20 - 3 - 7 = 10. If the Hero's current health is 10, then it is reduced to 0.
	3. If either the Hero or the Monster is reduced to 0 Current Health from an attack, that character loses the fight and the other character wins.
4. After each Fight, the win or loss is recorded, and the user is returned to the Main Menu.
