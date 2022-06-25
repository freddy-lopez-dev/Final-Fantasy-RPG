//Play D&D
Game dungeonsDragons = new Game();
dungeonsDragons.Start();

class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; } = 20;
    public int BaseDefence { get; set; } = 20;
    public int OriginalHealth { get; set; } = 100;
    public int CurrentHealth { get; set; } = 100;
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }

    public Hero()
    {
        Console.WriteLine("Welcome to Final Fantasy");
        Console.WriteLine("Enter your name:");
        Name = Console.ReadLine();
        Console.Clear();
    }

    public void ShowStats()
    {
        Console.WriteLine($"Your Stats");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Player Name: {Name}");
        Console.WriteLine($"Player Strenght: {BaseStrength}");
        Console.WriteLine($"Player Defence: {BaseDefence}");
        Console.WriteLine($"Player Health: {CurrentHealth}/{OriginalHealth}");
    }

    public void ShowInventory()
    {
        Weapon playerWeapon = EquippedWeapon;
        Armor playerArmor = EquippedArmor;
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Your Inventory");
        Console.WriteLine($"Your Weapon is {(playerWeapon == null ? "Empty": playerWeapon.Name)}");
        Console.WriteLine($"Your Armor is {(playerArmor == null ? "Empty" : playerArmor.Name)}");
        Console.WriteLine("----------------------------------");
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
    public static Monster Bahamuts = new Monster("Bahamuts", 40, 10);
    public static Monster Zeromus = new Monster("Zeromus", 30, 8);
    public static Monster Emperor = new Monster("Emperor", 50, 6);
    public static Monster Necron = new Monster("Necron", 20, 4);
    public static Monster Shuyin = new Monster("Shuyin", 10, 2);
    public static List<Monster> Monsters = new List<Monster>() { Bahamuts, Shuyin, Zeromus, Emperor, Necron };
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
        int weaponNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine($"Weapon {Weapons.ElementAt(weaponNum).Name} equipped!");
        Console.WriteLine("Choose an Armor from 0-4");
        int armorNum = Int32.Parse(Console.ReadLine());
        Console.WriteLine($"Armor {Armors.ElementAt(armorNum).Name} equipped");

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
        Console.WriteLine("Main Menu");
        Console.WriteLine("[A] Statistics");
        Console.WriteLine("[B] Inventory");
        Console.WriteLine("[C] Fight");
    }

    public static char SelectMenu()
    {
        char selectedMenu = char.Parse(Console.ReadLine());
        while (selectedMenu != 'A' && selectedMenu != 'B' && selectedMenu != 'C')
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
    public List<Monster> GameMonsters = MonsterList.Monsters;
    public Hero CurrentPlayer = new Hero();

    public void Start()
    {
        MainMenu.ShowMenu();
        char userSelection = MainMenu.SelectMenu();
        switch (userSelection)
        {
            case 'A':
                Console.WriteLine($"Game Statistics: Games Played:{GameStatistics.GamesPlayed} Fights Won: {GameStatistics.FightsWon} Fights Loss: {GameStatistics.FightsLost}");
                CurrentPlayer.ShowStats();
                CurrentPlayer.ShowInventory();
                Start();
                break;

            case 'B':
                //display Game Inventory
                //Inventory class
                Console.WriteLine("Displaying Inventory...");
                GameInventory.ShowInventory();
                
                CurrentPlayer.ShowStats();
                CurrentPlayer.ShowInventory();
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
                Console.WriteLine($"{randomMonster.Name} || Health: {randomMonster.CurrentHealth}/{randomMonster.OriginalHealth} || Strength: {randomMonster.Strength} || Defense: {randomMonster.Defense}");
                while(CurrentPlayer.CurrentHealth > 0 && randomMonster.CurrentHealth > 0)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"{randomMonster.Name} || Health: {randomMonster.CurrentHealth}/{randomMonster.OriginalHealth}");
                    Console.WriteLine($"Hero: {CurrentPlayer.Name} || Health: {CurrentPlayer.CurrentHealth}/{CurrentPlayer.OriginalHealth}");
                    fight.HeroTurn(CurrentPlayer, randomMonster);
                    fight.MonsterTurn(CurrentPlayer, randomMonster);
                    fight.Win(randomMonster, GameStatistics);
                    fight.Lose(CurrentPlayer, GameStatistics);
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

    public void HeroTurn(Hero hero, Monster monster)
    {
        //try catch here
        int heroDamage = hero.BaseStrength + hero.EquippedWeapon.Power;
        monster.CurrentHealth -= heroDamage;
    }

    public void MonsterTurn(Hero hero, Monster monster)
    {
        //try catch here
        int monsterDamage = monster.Strength - (hero.BaseDefence + hero.EquippedArmor.Power);
        if(monsterDamage < 0)
        {
            Console.WriteLine("No Damage!");
        } else
        {
            hero.CurrentHealth -= monsterDamage;
        }
    }

    public void Win(Monster monster, Statistics stats)
    {
        if (monster.CurrentHealth < 0)
        {
            Console.WriteLine($"You've killed {monster.Name}");
            //Remove from monster list
            MonsterList.Monsters.Remove(monster);
            //WinCounter++
            stats.FightsWon++;
        }
    }

    public void Lose(Hero hero, Statistics stats)
    {
        if (hero.CurrentHealth < 0)
        {
            //LoseCounter++
            stats.FightsLost++;
        }
    }
}