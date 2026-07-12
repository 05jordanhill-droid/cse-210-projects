using System.Globalization;
using Microsoft.VisualBasic;

class Simulation
{
    private Battlefield _jahBattlefield;
    private List<SimulationObject> _jahSimulationObjectList;

    public Simulation(int jahGridWidth, int jahGridHeight, List<SimulationObject> jahSimulationObjectList)
    {
        SetBattlefield(new Battlefield(jahGridWidth, jahGridHeight, jahSimulationObjectList));
        SetSimulationObjectList(jahSimulationObjectList);
    }
    public Simulation(int jahGridWidth, int jahGridHeight)
    {
        SetBattlefield(new Battlefield(jahGridWidth, jahGridHeight));
        SetSimulationObjectList(new());
    }
/*
    Getters / Setters
*/
    public Battlefield GetBattlefield()
    {
        return _jahBattlefield;
    }
    public void SetBattlefield(Battlefield jahBattlefield)
    {
        _jahBattlefield = jahBattlefield;
    }

    public List<SimulationObject> GetSimulationObjectList()
    {
        return _jahSimulationObjectList;
    }
    public void SetSimulationObjectList(List<SimulationObject> jahSimulationObjectList)
    {
        _jahSimulationObjectList = jahSimulationObjectList;
    }
    public void AddSimulationObject(SimulationObject jahSimulationObject)
    {
        try
        {
            GetSimulationObjectList().Add(jahSimulationObject);
        } catch
        {
            _jahSimulationObjectList = new();
            GetSimulationObjectList().Add(jahSimulationObject);
        }
        GetBattlefield().SetGridPiece(jahSimulationObject);
    }
/*
    Functions
*/
    public void Pause()
    {
        
    }
    public void SpeedUp()
    {
        
    }
    public void Resume()
    {
        while (true)
        {
            Support.Clear();
            TerminalDisplay.DisplayGrid<SimulationObject>(GetBattlefield().GetGrid(), var => var.GetAvatar());
            Support.GetEmptyInput();
            RunRound();
        }
    }
    private void RunRound()
    {
        SetSimulationObjectList(GetTurnOrder());

        foreach(SimulationObject jahSimulationObject in GetSimulationObjectList())
        {
            jahSimulationObject.TakeTurn(GetBattlefield());
        }
    }
    private List<SimulationObject> GetTurnOrder()
    {
        return Support.ReorderList<SimulationObject>(GetSimulationObjectList(), var => var.GetSpeed());
    }
}