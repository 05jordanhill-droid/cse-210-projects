using System.Globalization;

class Boulder : FieldObject
{
    public Boulder(
        int jahPositionX, 
        int jahPositionY, 
        int jahHealth = 5, 
        int jahDefense = 0, 
        int jahSpeed = 0, 
        int jahEvasion = 0, 
        int jahPerception = 0, 
        string jahPriority = "innert", 
        int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahPositionX, jahPositionY)
    {
        SetStepOn(false);
    }
    public Boulder(
        List<int> jahLocation, 
        int jahHealth = 5, 
        int jahDefense = 0, 
        int jahSpeed = 0, 
        int jahEvasion = 0, 
        int jahPerception = 0, 
        string jahPriority = "innert", 
        int jahFieldOfViewRadius=1) : base(jahHealth, jahDefense, jahSpeed, jahEvasion, jahPerception, jahPriority, jahLocation, jahFieldOfViewRadius)
    {
        SetStepOn(false);
    }
}