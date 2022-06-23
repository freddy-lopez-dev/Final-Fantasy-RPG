//Let the game begin
Console.WriteLine(WeaponList.MorningStar.Name);

class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; } = 5;
    public int BaseDefence { get; set; } = 5;
    public int OriginalHealth { get; set; } = 100;
    public int CurrentHealth { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }

    public Hero(string name)
    {
        Name = name;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Player Name: {Name}");
        Console.WriteLine($"Player Strenght: {BaseStrength}");
        Console.WriteLine($"Player Defence: {BaseDefence}");
        Console.WriteLine($"Player Health: {CurrentHealth}/{OriginalHealth}");
    }

    public Dictionary<Weapon, Armor> ShowInventory()
    {
        Weapon playerWeapon = EquippedWeapon;
        Armor playerArmor = EquippedArmor;
        Dictionary<Weapon, Armor> inventory = new Dictionary<Weapon, Armor>();
        inventory.Add(playerWeapon, playerArmor);
        return inventory;
    }

    //public Weapon EquippedWeapon()
    //public Armor EquippedArmor()
    
}

class Weapon
{
    public string Name { get; set;}
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
    public string Name { get; set;}
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int OriginalHealth { get; set; } = 100;
    public int CurrentHealth { get; set; }
}

static class WeaponList
{
    public static Weapon Dagger = new Weapon("Dagger", 4);
    public static Weapon Lance = new Weapon("Lance", 12);
    public static Weapon Crossbow = new Weapon("Crossbow", 8);
    public static Weapon MorningStar = new Weapon("Morningstar", 8);
    public static Weapon QuarterStaff = new Weapon("Quarter Staff", 6);
}

static class ArmorList
{
    public static Armor Padded = new Armor("Padded", 11);
    public static Armor ScaleMail = new Armor("Scale Mail", 14);
    public static Armor ChainMail = new Armor("Chain Mail", 16);
    public static Armor HalfPlate = new Armor("Half Plate", 15);
    public static Armor Plate = new Armor("Plate", 18);
}