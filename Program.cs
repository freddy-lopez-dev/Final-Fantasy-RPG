//Initialize Game
Game finalFantasy = new Game();
finalFantasy.Start();

class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; } = 20;
    public int BaseDefense { get; set; } = 20;
    public int OriginalHealth { get; set; } = 100;
    public int CurrentHealth { get; set; } = 100;
    public int Coins { get; set; } = 0;
    public Weapon EquippedWeapon { get; set; } = new Weapon("Bare Hands", 1);
    public Armor EquippedArmor { get; set; } = new Armor("Shirt", 1);

    // Constructor for Hero that will read the user Name when the game is started.
    public Hero()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Welcome to Final Fantasy");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Enter your name:");
        Console.WriteLine("----------------------------------");
        Name = Console.ReadLine();
        Console.Clear();
    }

    /* Method to display the Hero statistics. 
     * This method is called in Game > Main Menu > Game Statistics.
     * Also will be called when the user change equipment in Inventory
     */
    public void ShowStats()
    {
        Console.WriteLine($"Your Stats");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Player Name: {Name}");
        Console.WriteLine($"Player Strenght: {BaseStrength}");
        Console.WriteLine($"Player Defense: {BaseDefense}");
        Console.WriteLine($"Player Health: {CurrentHealth}/{OriginalHealth}");
    }

    /* Method to display the Hero Inventory. 
     * This method is called in Game > Main Menu > Game Statistics.
     * Also will be called when the user change equipment in Inventory
     */
    public void ShowInventory()
    {
        Weapon playerWeapon = EquippedWeapon;
        Armor playerArmor = EquippedArmor;
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Your Inventory");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Your Weapon is {(playerWeapon == null ? "Empty" : playerWeapon.Name)}");
        Console.WriteLine($"Your Armor is {(playerArmor == null ? "Empty" : playerArmor.Name)}");
        Console.WriteLine($"Coin pouch: {Coins}");

    }
    /*
     * Method to change Hero Equipped Weapon and Armor. Passing Weapon and Armor as Parameter then assign to Hero EquippedWeapon/EquippedArmor.
     * This method is called in Inventory > Change Equipment.
     */
    public Weapon EquipWeapon(Weapon weapon)
    {
        return EquippedWeapon = weapon;
    }
    public Armor EquipArmor(Armor armor)
    {
        return EquippedArmor = armor;
    }

}
class Weapon
{
    public string Name { get; set; }
    public int Power { get; set; }

    // Constructor Overload Weapon with name and power.
    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;
    }
}
class Armor
{
    public string Name { get; set; }
    public int Power { get; set; }

    //Constructor Overload Armor with name and power.
    public Armor(string name, int power)
    {
        Name = name;
        Power = power;
    }
}
class Monster
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int OriginalHealth { get; set; } = 100;
    public int CurrentHealth { get; set; } = 100;

    //Constructor Overload Monster with name, strength, defense.
    public Monster(string name, int strength, int defense)
    {
        Name = name;
        Strength = strength;
        Defense = defense;
    }
}

/* New Static MonsterList.
 * This will Populate the list of all monsters in Game.
 * A static method that will return a new intances of Monster.
 * Static method is called when the Game is initialized, Hero Losses and when Hero defeated all original monster.
 */
static class MonsterList
{
    public static List<Monster> PopulateMonster()
    {
        List<Monster> monsters = new List<Monster>();
        Monster Bahamuts = new Monster("Bahamuts", 40, 10);
        Monster Zeromus = new Monster("Zeromus", 30, 8);
        Monster Emperor = new Monster("Emperor", 50, 6);
        Monster Necron = new Monster("Necron", 20, 4);
        Monster Shuyin = new Monster("Shuyin", 10, 2);
        monsters.Add(Bahamuts);
        monsters.Add(Zeromus);
        monsters.Add(Emperor);
        monsters.Add(Necron);
        monsters.Add(Shuyin);
        return monsters;
    }
}

/*
 * Static Weapon List that will store a new instances of Weapon and add it on a static list called Weapons.
 * This static List of Weapons is called when the Game is initialized and when displaying the inventory. Also for selecting new Weapon in Inventory.
 */
static class WeaponList
{
    public static Weapon Dagger = new Weapon("Dagger", 4);
    public static Weapon Lance = new Weapon("Lance", 12);
    public static Weapon Crossbow = new Weapon("Crossbow", 8);
    public static Weapon MorningStar = new Weapon("Morningstar", 8);
    public static Weapon QuarterStaff = new Weapon("Quarter Staff", 6);
    public static List<Weapon> Weapons = new List<Weapon>() { Dagger, Lance, Crossbow, MorningStar, QuarterStaff };
}
/*
 * Static Armor List that will store a new instances of Armor and add it on a static list called Armors.
 * This static List of Armors is called when the Game is initialized and when displaying the inventory. Also for selecting new Armor in Inventory.
 */
static class ArmorList
{
    public static Armor Padded = new Armor("Padded", 11);
    public static Armor ScaleMail = new Armor("Scale Mail", 14);
    public static Armor ChainMail = new Armor("Chain Mail", 16);
    public static Armor HalfPlate = new Armor("Half Plate", 15);
    public static Armor Plate = new Armor("Plate", 18);
    public static List<Armor> Armors = new List<Armor>() { Padded, ScaleMail, ChainMail, HalfPlate, Plate };
}

// Game Statistics for storing the GamesPlayer, FightsWon, FightsLost.
class Statistics
{
    public int GamesPlayed { get; set; } = 0;
    public int FightsWon { get; set; } = 0;
    public int FightsLost { get; set; } = 0;
}

// Inventory will be instantiated when the user initialized the Game.
class Inventory
{
    public ICollection<Weapon> Weapons { get; set; }
    public ICollection<Armor> Armors { get; set; }

    public Inventory()
    {
        Weapons = WeaponList.Weapons;
        Armors = ArmorList.Armors;
    }

    /*
     * Inventory Method that will display the Inventory of the game. This method is called when the Hero access Inventory in Game.
     * Calling both static Weapon and Armor list and iterating over them to be displayed in the console.
     */
    public void ShowInventory()
    {
        int weaponCounter = 0;
        int armorCounter = 0;
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Weapon Inventory");
        foreach (Weapon weapon in Weapons)
        {
            Console.WriteLine($"[{weaponCounter++}] {weapon.Name} || Power: {weapon.Power}");
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Armor Inventory");
        foreach (Armor armor in Armors)
        {
            Console.WriteLine($"[{armorCounter++}] {armor.Name} || Power: {armor.Power}");
        }
        Console.WriteLine("----------------------------------");
    }

    /* Inventory Method that will ask user to change equipment and find it in the local variable Weapons/Armors list.
     * Previously mentioned method in Hero, EquippedWeapon and EquippedArmor is called here to pass the user selection of a new Weapon and Armor.
     * Hero Stats and Hero Inventory is also called for showing the changes for Hero.
     */
    public void ChangeEquipment(Hero hero)
    {
        // Try Catch
        Console.WriteLine("Choose a Weapon from 0-4");
        Console.WriteLine("----------------------------------");
        int weaponNum = Int32.Parse(Console.ReadLine());
        while (weaponNum < 0 || weaponNum > 4)
        {
            Console.WriteLine("Please select a weapon from 0 to 4");
            weaponNum = Int32.Parse(Console.ReadLine());
        }
        Console.WriteLine($"Weapon {Weapons.ElementAt(weaponNum).Name} equipped!");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Choose an Armor from 0-4");
        Console.WriteLine("----------------------------------");
        int armorNum = Int32.Parse(Console.ReadLine());
        while (armorNum < 0 || armorNum > 4)
        {
            Console.WriteLine("Please select a armor from 0 to 4");
            armorNum = Int32.Parse(Console.ReadLine());
        }
        Console.WriteLine($"Armor {Armors.ElementAt(armorNum).Name} equipped");
        Console.WriteLine("----------------------------------");

        hero.EquipWeapon(Weapons.ElementAt(weaponNum));
        hero.EquipArmor(Armors.ElementAt(armorNum));
        Console.Clear();
        Console.WriteLine($"Your New Weapon is: {hero.EquippedWeapon.Name}");
        Console.WriteLine($"Your New Armor is: {hero.EquippedArmor.Name}");
        Console.WriteLine("----------------------------------");
        hero.ShowStats();
        hero.ShowInventory();
    }
}

// Static MainMenu is called in the Game whenever Hero started Game, After accessing Statistics, Inventory, ChangeEquipment, After fights, and Store.
static class MainMenu
{
    //Static method to display Menu in Console.
    public static void ShowMenu()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Main Menu");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("[A] Statistics");
        Console.WriteLine("[B] Inventory");
        Console.WriteLine("[C] Fight");
        Console.WriteLine("[D] Store");
        Console.WriteLine("----------------------------------");
    }

    /* Static method that will be called everytime Main Menu is called.
     * This method will ask user for Main Menu selection and checks if it's in the correct range A-D.
     * It will return a char for user selection that will be determined in Game > Start > Switch.
     */
    public static char SelectMenu()
    {
        char selectedMenu = char.Parse(Console.ReadLine());
        while (selectedMenu != 'A' && selectedMenu != 'B' && selectedMenu != 'C' && selectedMenu != 'D')
        {
            Console.WriteLine("Select correct Option");
            selectedMenu = char.Parse(Console.ReadLine());
        }
        Console.Clear();
        return selectedMenu;
    }

}
/*
 * Fight updates the instances of Hero and Monster decreasing each health base on properties of Hero and Monster.
 * Fight is called when Game is started > Main Menu > Fight.
 */
class Fight
{
    public Hero Hero { get; set; }
    public Monster Monster { get; set; }
    public Fight(Hero hero, Monster monster)
    {
        Hero = hero;
        Monster = monster;
    }
    public int FightCounter { get; set; } = 1;
    public int NewGameStrength { get; set; } = 10;

    /* Hero Turn method will take hero and monster as parameter calculating the damage to be done by the Hero to the monster.
     * This method will be called whenever the fight is selected from Main menu.
     */
    public void HeroTurn()
    {
        //try catch here
        int heroDamage = Hero.BaseStrength + Hero.EquippedWeapon.Power;
        Monster.CurrentHealth -= heroDamage;
        Console.WriteLine($"Fight Turn {FightCounter++}");
        Console.WriteLine($"Hero turn attack Damage: {heroDamage}");
    }

    /* Monster Turn method will take both hero and monster as parameter to calculate the monster damage with hero properties.
     * This method will be called whenever the fight is selected from Main menu and after the Hero Turn method is called.
     */
    public void MonsterTurn()
    {
        //try catch here
        int monsterDamage = Monster.Strength - (Hero.BaseDefense + Hero.EquippedArmor.Power);
        if (monsterDamage < 0)
        {
            Console.WriteLine($"Monster turn attack damage: {(monsterDamage < 0 ? 0 : monsterDamage)}");
            Console.WriteLine("No Damage! You have a strong armor");
        }
        else
        {
            Console.WriteLine($"Monster turn attack damage: {(monsterDamage < 0 ? 0 : monsterDamage)}");
            Hero.CurrentHealth -= monsterDamage;
        }
    }

    /* Check Win method that will determine if the monster health is below 0 for the Hero to win, add win counter, add 10 coins for Hero each win. 
     * Parameters are Monster, Statistics and list of monsters for removing.
     * This method is called whenever both HeroTurn and MonsterTurn is called.
     * New Game Plus: If Hero finishes the first instances of Monster, List of Monster will be reinstantiate with modification to their strength(Much Stronger).
     */
    public void Win(Statistics stats, List<Monster> monsters)
    {
        if (Monster.CurrentHealth < 0)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"You've killed {Monster.Name} and earned 10 coins");
            //Remove from monster list
            monsters.Remove(Monster);
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total Coins in pouch: {Hero.Coins += 10}");
            Console.WriteLine("----------------------------------");
            //WinCounter++
            stats.FightsWon++;
            //NEW GAME PLUS
            if (monsters.Count == 0)
            {
                Console.WriteLine("You've Defeated ALL of the monster. Now the Real Challenge begin.");
                Console.WriteLine("New Game Plus Initiated!");
                Console.WriteLine("Stronger Monsters will appear");
                Game.GameMonsters = MonsterList.PopulateMonster();
                NewGameStrength += 20;
                foreach (Monster m in Game.GameMonsters)
                {
                    m.Strength += NewGameStrength;
                }
            }
        }
    }

    /* Check Lose method that will check if Hero's health is below 0.
     * This method is called whenever both HeroTurn and MonsterTurn is called.
     * If Hero loses all of the monsters will be instantiated again and lose couneter + 1.
     */
    public void Lose(Statistics stats)
    {
        if (Hero.CurrentHealth < 0)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("You've died!");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("All monsters came back from the dead");
            Console.WriteLine("----------------------------------");
            Game.GameMonsters = MonsterList.PopulateMonster();
            //LoseCounter++
            stats.FightsLost++;
            Hero.CurrentHealth = Hero.OriginalHealth;
        }
    }
}

/* Bonus: In game store that will allow Hero to update he/she properties.
 */
class Store
{
    // Displaying store options called when user access store in Main Menu.
    public void ShowStoreOptions(Hero hero)
    {
        Console.Clear();
        Console.WriteLine($"Available Coins: {hero.Coins}");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Store Option");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("[A] Increase Base Strength by 5 for 10 Coins");
        Console.WriteLine("[B] Increase Base Defense by 5 for 10 Coins");
        Console.WriteLine("[C] Restore Health by 50 for 20 Coins ");
        Console.WriteLine("----------------------------------");
    }

    /* Method that will be called everytime Store is called.
     * This method will ask user for Store selection and checks if it's in the correct range A-C.
     * It will return a char for user selection that will be determined in Game > Start > Main Menu > Store.
     */
    public char StoreSelect()
    {
        Console.WriteLine($"Choose what to purchase");
        char selectedMenu = char.Parse(Console.ReadLine());
        while (selectedMenu != 'A' && selectedMenu != 'B' && selectedMenu != 'C')
        {
            Console.WriteLine("Select correct Option");
            selectedMenu = char.Parse(Console.ReadLine());
        }
        Console.Clear();
        return selectedMenu;
    }

    /* Method to IncreaseBaseStrength of Hero.
     * This will check if Hero has coins to purchase else display not enough coins.
     */
    public void IncreaseBaseStrength(Hero hero)
    {
        if (hero.Coins >= 10)
        {
            hero.BaseStrength += 5;
            hero.Coins -= 10;
        }
        else
        {
            Console.WriteLine("Not enough coins for Increasing your Strength");
        }
        Console.WriteLine($"Your base strength is now {hero.BaseStrength}");
    }

    /* Method to IncreaseBaseDefenseof Hero.
     * This will check if Hero has coins to purchase else display not enough coins.
     */
    public void IncreaseBaseDefense(Hero hero)
    {
        if (hero.Coins >= 10)
        {
            hero.BaseDefense += 5;
            hero.Coins -= 10;
        }
        else
        {
            Console.WriteLine("Not enough coins for Increasing your Defense");
        }
        Console.WriteLine($"Your base defense is now {hero.BaseDefense}");
    }

    /* Method to RestoreHealth by 50 of Hero.
     * This will check if Hero has already maximum health else add 50.
     * This will alsp check if Hero has coins to purchase else display not enough coins.
     */
    public void RestoreHealth(Hero hero)
    {
        if (hero.Coins >= 20)
        {
            if (hero.CurrentHealth == hero.OriginalHealth)
            {
                Console.WriteLine("You're already at full health");
                Console.WriteLine("Take your coins back!");
            }
            if (hero.CurrentHealth < hero.OriginalHealth)
            {
                int healthPoints = hero.CurrentHealth + 50;
                if (healthPoints > 100)
                {
                    hero.CurrentHealth = hero.OriginalHealth;
                    hero.Coins -= 20;
                }
                else
                {
                    hero.CurrentHealth = healthPoints;
                    hero.Coins -= 20;
                }
                Console.WriteLine($"Your current health is now restored to {hero.CurrentHealth}");
            }
        }
        else
        {
            Console.WriteLine("Not enough coins to restore health");
        }
    }
}

/* Application heart and brain.
 * New Instances of Statistics, Inventory, List of Monsters, Hero and Store upon starting the Game.
 */
class Game
{
    public Statistics GameStatistics = new Statistics();
    public Inventory GameInventory = new Inventory();
    public static List<Monster> GameMonsters = MonsterList.PopulateMonster();
    public Store GameStore = new Store();
    public Hero CurrentPlayer = new Hero();


    /* Start method is the brain of the application that will determine the movement of Hero.
     * Upon starting it will call the Main Menu for user selection of either Statistics, Inventory, Fight or Store.
     * Selection of Statistics will call the method to display the stats of the game.
     * Selection of Inventory will call the ShowInventory and ask Hero if he/she wants to change Equipment.
     * Selection of Fight will Instantiate the Fight method and selects a Random Monster to fight with. This is the Playthrough of the game.
     * Selection of Store will call the method that will provide a change for the Hero to change its parameters if he/she has coins.
     */
    public void Start()
    {
        MainMenu.ShowMenu();
        char userSelection = MainMenu.SelectMenu();
        switch (userSelection)
        {
            case 'A':
                // Show Game Statistics
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Game Statistics:");
                Console.WriteLine($"Fights Played:{GameStatistics.GamesPlayed}");
                Console.WriteLine($"Fights Won: {GameStatistics.FightsWon}");
                Console.WriteLine($"Fights Loss: {GameStatistics.FightsLost}");
                Console.WriteLine("----------------------------------");
                CurrentPlayer.ShowStats();
                CurrentPlayer.ShowInventory();
                Start();
                break;

            case 'B':
                // Display Game Inventory
                // Inventory class and Equipment Change.
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Displaying Inventory...");
                GameInventory.ShowInventory();
                //change equipment
                Console.WriteLine("Do you want to change your equipment? Y/N");
                string doEquipmentChange = Console.ReadLine();
                Console.WriteLine("----------------------------------");
                while (doEquipmentChange != "Y" && doEquipmentChange != "N")
                {
                    Console.WriteLine("Choose 'Y' for yes or 'N' for no");
                    doEquipmentChange = Console.ReadLine();
                }
                if (doEquipmentChange == "Y")
                {
                    GameInventory.ChangeEquipment(CurrentPlayer);
                }
                Start();
                break;
            case 'C':
                // Selects Random Monster
                Random randomNum = new Random();
                Monster randomMonster = GameMonsters.ElementAt(randomNum.Next(GameMonsters.Count));
                // new Fight class
                Fight fight = new Fight(CurrentPlayer, randomMonster);
                Console.WriteLine("Monster Encountered!");
                GameStatistics.GamesPlayed++;
                Console.WriteLine($"{randomMonster.Name} || Health: {randomMonster.CurrentHealth}/{randomMonster.OriginalHealth} || Strength: {randomMonster.Strength} || Defense: {randomMonster.Defense}");
                // Continuos playthrough of HeroTurn, MonsterTurn, CheckWin and CheckLose.
                while (CurrentPlayer.CurrentHealth > 0 && randomMonster.CurrentHealth > 0)
                {
                    Console.WriteLine("----------------------------------");
                    fight.HeroTurn();
                    fight.MonsterTurn();
                    Console.WriteLine($"{randomMonster.Name} || Health: {(randomMonster.CurrentHealth < 0 ? 0 : randomMonster.CurrentHealth)}/{randomMonster.OriginalHealth}");
                    Console.WriteLine($"Hero: {CurrentPlayer.Name} || Health: {(CurrentPlayer.CurrentHealth < 0 ? 0 : CurrentPlayer.CurrentHealth)}/{CurrentPlayer.OriginalHealth}");
                }
                fight.Win(GameStatistics, GameMonsters);
                fight.Lose(GameStatistics);
                Start();
                break;
            case 'D':
                // Store class
                GameStore.ShowStoreOptions(CurrentPlayer);
                // Check if it has coins
                if (CurrentPlayer.Coins <= 0)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("You don't have enough coins");
                    Console.WriteLine("----------------------------------");
                }
                else
                {
                    // Store Selections for the Hero calling A-C switch, Increasing either Strength, Defense or Health.
                    char storeSelection = GameStore.StoreSelect();
                    switch (storeSelection)
                    {
                        case 'A':
                            GameStore.IncreaseBaseStrength(CurrentPlayer);
                            break;
                        case 'B':
                            GameStore.IncreaseBaseDefense(CurrentPlayer);
                            break;
                        case 'C':
                            GameStore.RestoreHealth(CurrentPlayer);
                            break;
                    }
                }
                Start();
                break;
        }
    }
}

