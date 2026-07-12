using System.Globalization;

class Battlefield
{
    private List<List<SimulationObject>> _jahGrid;

    public Battlefield(int jahGridWidth, int jahGridHeight, List<SimulationObject> jahSimulationObjectList)
    {
        SetGridEmpty(jahGridWidth, jahGridHeight);
        SetGridPieces(jahSimulationObjectList);
    }
    public Battlefield(int jahGridWidth, int jahGridHeight)
    {
        SetGridEmpty(jahGridWidth, jahGridHeight);
    }

/*
    Getters / Setters
*/
    public List<List<SimulationObject>> GetGrid()
    {
        return _jahGrid;
    }
    public void SetGrid(List<List<SimulationObject>> jahGrid)
    {
        _jahGrid = jahGrid;
    }
    public void SetGridEmpty(int jahGridWidth, int jahGridHeight)
    {
        List<List<SimulationObject>> jahGrid = new();
        for (int y = 0; y < jahGridHeight; y++)
        {
            List<SimulationObject> jahRow = new();
            for (int x = 0; x < jahGridWidth; x++)
            {
                jahRow.Add(new SimulationObject(jahGridWidth, jahGridHeight));
            }
            jahGrid.Add(jahRow);
        }
        SetGrid(jahGrid);
    }
    public void SetGridEmpty()
    {
        int y = 0;
        foreach (List<SimulationObject> jahList in GetGrid())
        {
            int x = 0;
            foreach (SimulationObject jahSimulationObject in jahList)
            {
                SetGridPiece
                (
                    jahSimulationObject.GetPositionX(), 
                    jahSimulationObject.GetPositionY(), 
                    new SimulationObject(x, y)
                );
                x += 1;
            }
            y += 1;
        }
    }
    public void SetGridPieces(List<SimulationObject> jahSimulationObjectList)
    {
        foreach(SimulationObject jahSimulationObject in jahSimulationObjectList)
        {
            SetGridPiece
            (
                jahSimulationObject.GetPositionX(), 
                jahSimulationObject.GetPositionY(), 
                jahSimulationObject
            );
        }
    }
    public void SetGridPiece(int jahX, int jahY, SimulationObject jahSimulationObject)
    {
        GetGrid()[jahY][jahX] = jahSimulationObject;
    }
    public void SetGridPiece(SimulationObject jahSimulationObject)
    {
        GetGrid()
            [jahSimulationObject.GetPositionY()]
            [jahSimulationObject.GetPositionX()] 
            = jahSimulationObject;
    }
    public SimulationObject GetGridPiece(int jahX, int jahY)
    {
        return GetGrid()[jahY][jahX];
    }

/*
    Functions
*/
    public void AssessActivate(List<int> jahCoordinates)
    {
        if (GetGrid()[jahCoordinates[1]][jahCoordinates[0]] is FieldObject)
        {
            FieldObject jahFieldObject = (FieldObject)GetGrid()[jahCoordinates[1]][jahCoordinates[0]];
            Activate(jahFieldObject);
        }
    }
    public void Activate(FieldObject jahFieldObject)
    {
        jahFieldObject.ActivateAbility(this);
    }
    public SimulationObject Inspect(List<int> jahCoordinates)
    {
        try
        {
            return GetGrid()[jahCoordinates[1]][jahCoordinates[0]];
        } 
        catch
        {
            return null;
        }
    }
}