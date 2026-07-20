using System.Globalization;

class Fighter : Character
{
    public Fighter(
        int jahPositionX, 
        int jahPositionY, 
        int jahStrength=15, 
        int jahHealth=10, 
        int jahDefense=10, 
        int jahSpeed=10, 
        int jahEvasion=5, 
        int jahPerception=5, 
        string jahPriority="wander", 
        int jahFieldOfViewRadius=1, 
        int jahRange=1)
         : base(jahStrength, jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY, jahFieldOfViewRadius, jahRange){}
    public Fighter(
        List<int> jahLocation, 
        int jahStrength=15, 
        int jahHealth=10, 
        int jahDefense=10, 
        int jahSpeed=10, 
        int jahEvasion=5, 
        int jahPerception=5, 
        string jahPriority="wander", 
        int jahFieldOfViewRadius=1, 
        int jahRange=1)
         : base(jahStrength, jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius, jahRange){}

    public override void Attack(Battlefield jahBattlefield, Character jahEnemy)
    {
        base.Attack(jahBattlefield, jahEnemy);
        base.Attack(jahBattlefield, jahEnemy);
    }
}