using System.Globalization;

class Mine : FieldObject
{
    public Mine(
        int jahPositionX, 
        int jahPositionY, 
        int jahHealth = 5, 
        int jahDefense = 0, 
        int jahSpeed = 0, 
        int jahEvasion = 0, 
        int jahPerception = 0, 
        string jahPriority = "innert", 
        int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY)
    {SetStepOn(true);}
    public Mine(
        List<int> jahLocation, 
        int jahHealth = 5, 
        int jahDefense = 0, 
        int jahSpeed = 0, 
        int jahEvasion = 0, 
        int jahPerception = 0, 
        string jahPriority = "innert", 
        int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius)
    {SetStepOn(true);}

    /*
        Functions
    */
    public override void ActivateAbility(Battlefield jahBattlefield)
    {
        List<List<int>> jahCoords = Support.GetFullSquareCoordinates(1, GetLocation());
        SimulationObject jahObject;
        
        foreach(List<int> jahCoord in jahCoords)
        {
            jahObject = jahBattlefield.Inspect(jahCoord);
            jahBattlefield.ApplyHealth(jahObject, -5);
        }
    }
}