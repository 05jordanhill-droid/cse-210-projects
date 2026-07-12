using System.Dynamic;
using System.Globalization;

class Character : SimulationObject
{
    private int _jahStrength;

    public Character(int jahStrength, int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, int jahPositionX, int jahPositionY, int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY, jahFieldOfViewRadius)
    {
        SetStrength(jahStrength);
    }
    public Character(int jahStrength, int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, List<int> jahLocation, int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius)
    {
        SetStrength(jahStrength);
    }
    public Character(int jahXPosition, int jahYPosition) : base(jahXPosition, jahYPosition)
    {
        SetStrength(0);
        SetPerception(0);
    }
    public Character(List<int> jahLocation) : base(jahLocation)
    {
        SetStrength(0);
        SetPerception(0);
    }

/*
    Getters / Setters
*/
    public int GetStrength()
    {
        return _jahStrength;
    }
    public void SetStrength(int jahStrength)
    {
        _jahStrength = jahStrength;
    }

/*
    Functions
*/
    public void Attack()
    {
        
    }
    public void Defend()
    {
        
    }
    public override void Assess(Battlefield jahBattlefield)
    {
        CheckPriorityActivate(jahBattlefield);
        CheckPriorityWander(jahBattlefield);
        //More Options...
    }
    public void AssessAttack()
    {
        
    }
    public void Flee(List<Character> jahFleeFromList)
    {
        
    }
}