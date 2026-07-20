using System.Globalization;

class Mage : Character
{
    int _jahMana;
    public Mage(
        int jahPositionX, 
        int jahPositionY, 
        int jahMana=50,
        int jahStrength=5, 
        int jahHealth=5, 
        int jahDefense=5, 
        int jahSpeed=10, 
        int jahEvasion=10, 
        int jahPerception=10, 
        string jahPriority="wander", 
        int jahFieldOfViewRadius=1, 
        int jahRange=10)
         : base(jahStrength, jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY, jahFieldOfViewRadius, jahRange)
    {
        SetMana(jahMana);
    }
    public Mage(
        List<int> jahLocation, 
        int jahMana=50,
        int jahStrength=5, 
        int jahHealth=5, 
        int jahDefense=5, 
        int jahSpeed=10, 
        int jahEvasion=10, 
        int jahPerception=10, 
        string jahPriority="wander", 
        int jahFieldOfViewRadius=1, 
        int jahRange=5)
         : base(jahStrength, jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius, jahRange)
    {
        SetMana(jahMana);
    }

    public int GetMana()
    {
        return _jahMana;
    }
    public void SetMana(int jahMana)
    {
        _jahMana = jahMana;
    }

    override public void Attack(Battlefield jahBattlefield, Character jahEnemy)
    {
        if (Support.GetRandomInt(3) != 1)
        {
            base.Attack(jahBattlefield, jahEnemy);
        }
        if (Support.GetRandomInt(3) != 1)
        {
            base.Attack(jahBattlefield, jahEnemy);
        }
    }
    override public void ActivateAbility(Battlefield jahBattlefield)
    {
        if(GetMana() >= 25)
        {
            Move(new(){
                Support.GetRandomInt(jahBattlefield.GetGrid()[0].Count),
                Support.GetRandomInt(jahBattlefield.GetGrid().Count)},
                jahBattlefield);

            SetMana(GetMana()-25);
        }
    }
    override public string GetStringStats()
    {
        string jahStats = "";
        
        jahStats += $"\nAvatar: {GetAvatar()}";
        jahStats += $"\tHealth: {GetHealth()}";
        jahStats += $"\tDefense: {GetDefense()}";
        jahStats += $"\tStrength: {GetStrength()}";
        jahStats += $"\nPerception: {GetPerception()}";
        jahStats += $"\tSpeed: {GetSpeed()}";
        jahStats += $"\tEvasion: {GetEvasion()}";
        jahStats += $"\tMana: {GetMana()}";
        jahStats += $"\t\tPriority: {GetPriority()}";

        return jahStats;
    }
}