using System.Globalization;

class FieldObject : SimulationObject
{
    public FieldObject(int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, int jahPositionX, int jahPositionY, int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY)
    {}
    public FieldObject(int jahHealth, int jahDefense, int jahSpeed, int jahEvasion, int jahPerception, string jahPriority, List<int> jahLocation, int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius)
    {}
    public FieldObject(int jahXPosition, int jahYPosition) : base(jahXPosition, jahYPosition)
    {}
    public FieldObject(List<int> jahLocation) : base(jahLocation)
    {}

/*
    Functions
*/
}