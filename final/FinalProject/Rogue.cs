using System.Globalization;

class Rogue : Character
{
    public Rogue(
        int jahPositionX, 
        int jahPositionY, 
        int jahStrength=10, 
        int jahHealth=10, 
        int jahDefense=5, 
        int jahSpeed=15, 
        int jahEvasion=15, 
        int jahPerception=15, 
        string jahPriority="wander", 
        int jahFieldOfViewRadius=2, 
        int jahRange=2)
         : base(jahStrength, jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY, jahFieldOfViewRadius, jahRange){}
    public Rogue(
        List<int> jahLocation, 
        int jahStrength=10, 
        int jahHealth=10, 
        int jahDefense=5, 
        int jahSpeed=15, 
        int jahEvasion=15, 
        int jahPerception=15, 
        string jahPriority="wander", 
        int jahFieldOfViewRadius=5, 
        int jahRange=2)
         : base(jahStrength, jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius, jahRange){}


    /*
        Functions
    */
    override public void Dodge(Character jahAttacker, int jahBuff=0, int jahChance=5)
    {
        base.Dodge(jahAttacker, (GetEvasion()/3)+jahBuff, 2+jahChance);
    }
}