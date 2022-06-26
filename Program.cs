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

    public void ShowStats()
    {
        Console.WriteLine($"Your Stats");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Player Name: {Name}");
        Console.WriteLine($"Player Strenght: {BaseStrength}");
        Console.WriteLine($"Player Defense: {BaseDefense}");
        Console.WriteLine($"Player Health: {CurrentHealth}/{OriginalHealth}");
    }

    public void ShowInventory()
    {
        Weapon playerWeapon = EquippedWeapon;
        Armor playerArmor = EquippedArmor;
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Your Inventory");
        Console.WriteLine($"Your Weapon is {(playerWeapon == null ? "Empty" : playerWeapon.Name)}");
        Console.WriteLine($"Your Armor is {(playerArmor == null ? "Empty" : playerArmor.Name)}");
        Console.WriteLine($"Coin pouch: {Coins}");

    }

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

    public Monster(string name, int strength, int defense)
    {
        Name = name;
        Strength = strength;
        Defense = defense;
    }
}
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
static class WeaponList
{
    public static Weapon Dagger = new Weapon("Dagger", 4);
    public static Weapon Lance = new Weapon("Lance", 12);
    public static Weapon Crossbow = new Weapon("Crossbow", 8);
    public static Weapon MorningStar = new Weapon("Morningstar", 8);
    public static Weapon QuarterStaff = new Weapon("Quarter Staff", 6);
    public static List<Weapon> Weapons = new List<Weapon>() { Dagger, Lance, Crossbow, MorningStar, QuarterStaff };
}

static class ArmorList
{
    public static Armor Padded = new Armor("Padded", 11);
    public static Armor ScaleMail = new Armor("Scale Mail", 14);
    public static Armor ChainMail = new Armor("Chain Mail", 16);
    public static Armor HalfPlate = new Armor("Half Plate", 15);
    public static Armor Plate = new Armor("Plate", 18);
    public static List<Armor> Armors = new List<Armor>() { Padded, ScaleMail, ChainMail, HalfPlate, Plate };
}

class Statistics
{
    public int GamesPlayed { get; set; } = 0;
    public int FightsWon { get; set; } = 0;
    public int FightsLost { get; set; } = 0;
}
class Inventory
{
    public ICollection<Weapon> Weapons { get; set; }
    public ICollection<Armor> Armors { get; set; }

    public Inventory()
    {
        Weapons = WeaponList.Weapons;
        Armors = ArmorList.Armors;
    }

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

    public void ChangeEquipment(Hero hero)
    {
        Console.WriteLine("Choose a Weapon from 0-4");
        Console.WriteLine("----------------------------------");
        int weaponNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine($"Weapon {Weapons.ElementAt(weaponNum).Name} equipped!");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Choose an Armor from 0-4");
        Console.WriteLine("----------------------------------");
        int armorNum = Int32.Parse(Console.ReadLine());
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

static class MainMenu
{
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

class Game
{
    public Statistics GameStatistics = new Statistics();
    public Inventory GameInventory = new Inventory();
    public static List<Monster> GameMonsters = MonsterList.PopulateMonster();
    public Store GameStore = new Store();
    public Hero CurrentPlayer = new Hero();

    public void Start()
    {
        MainMenu.ShowMenu();
        char userSelection = MainMenu.SelectMenu();
        switch (userSelection)
        {
            case 'A':
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
                //display Game Inventory
                //Inventory class
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Displaying Inventory...");
                GameInventory.ShowInventory();
                //change equipment
                Console.WriteLine("Do you want to change your equipment? Y/N");
                char doEquipmentChange = char.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------");
                if (doEquipmentChange == 'Y')
                {
                    GameInventory.ChangeEquipment(CurrentPlayer);
                }
                Start();
                break;
            case 'C':
                //Fight class
                Random randomNum = new Random();
                Monster randomMonster = GameMonsters.ElementAt(randomNum.Next(GameMonsters.Count));
                Fight fight = new Fight(CurrentPlayer, randomMonster);
                Console.WriteLine("Monster Encountered!");
                GameStatistics.GamesPlayed++;
                Console.WriteLine($"{randomMonster.Name} || Health: {randomMonster.CurrentHealth}/{randomMonster.OriginalHealth} || Strength: {randomMonster.Strength} || Defense: {randomMonster.Defense}");
                while (CurrentPlayer.CurrentHealth > 0 && randomMonster.CurrentHealth > 0)
                {
                    Console.WriteLine("----------------------------------");
                    fight.HeroTurn(CurrentPlayer, randomMonster);
                    fight.MonsterTurn(CurrentPlayer, randomMonster);
                    Console.WriteLine($"{randomMonster.Name} || Health: {(randomMonster.CurrentHealth < 0 ? 0 : randomMonster.CurrentHealth)}/{randomMonster.OriginalHealth}");
                    Console.WriteLine($"Hero: {CurrentPlayer.Name} || Health: {(CurrentPlayer.CurrentHealth < 0 ? 0 : CurrentPlayer.CurrentHealth)}/{CurrentPlayer.OriginalHealth}");
                    fight.Win(randomMonster, GameStatistics, GameMonsters);
                    fight.Lose(CurrentPlayer, GameStatistics);
                    if (CurrentPlayer.CurrentHealth < 0)
                    {
                        CurrentPlayer.CurrentHealth = CurrentPlayer.OriginalHealth;
                        break;
                    }
                }
                Start();
                break;
            case 'D':
                //Store class
                GameStore.ShowStoreOptions(CurrentPlayer);
                //check if it has coins
                if (CurrentPlayer.Coins <= 0)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("You don't have enough coins");
                    Console.WriteLine("----------------------------------");
                }
                else
                {
                    //initialize store
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

    public void HeroTurn(Hero hero, Monster monster)
    {
        //try catch here
        int heroDamage = hero.BaseStrength + hero.EquippedWeapon.Power;
        monster.CurrentHealth -= heroDamage;
        Console.WriteLine($"Fight Turn {FightCounter++}");
        Console.WriteLine($"Hero turn attack Damage: {heroDamage}");
    }

    public void MonsterTurn(Hero hero, Monster monster)
    {
        //try catch here
        int monsterDamage = monster.Strength - (hero.BaseDefense + hero.EquippedArmor.Power);
        if (monsterDamage < 0)
        {
            Console.WriteLine($"Monster turn attack damage: {(monsterDamage < 0 ? 0 : monsterDamage)}");
            Console.WriteLine("No Damage! You have a strong armor");
        }
        else
        {
            Console.WriteLine($"Monster turn attack damage: {(monsterDamage < 0 ? 0 : monsterDamage)}");
            hero.CurrentHealth -= monsterDamage;
        }
    }

    public void Win(Monster monster, Statistics stats, List<Monster> monsters)
    {
        if (monster.CurrentHealth < 0)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"You've killed {monster.Name} and earned 10 coins");
            //Remove from monster list
            monsters.Remove(monster);
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

    public void Lose(Hero hero, Statistics stats)
    {
        if (hero.CurrentHealth < 0)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("You've died!");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("All monsters came back from the dead");
            Console.WriteLine("----------------------------------");
            Game.GameMonsters = MonsterList.PopulateMonster();
            //LoseCounter++
            stats.FightsLost++;
            hero.CurrentHealth = hero.OriginalHealth;
        }
    }
}

class Store
{

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

    public void IncreaseBaseStrength(Hero hero)
    {
        if (hero.Coins > 5)
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

    public void IncreaseBaseDefense(Hero hero)
    {
        if (hero.Coins > 5)
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

    public void RestoreHealth(Hero hero)
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
            }

        }
        Console.WriteLine($"Your current health is now restored to {hero.CurrentHealth}");
    }
}