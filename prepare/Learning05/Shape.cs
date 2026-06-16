using System.Globalization;

public abstract class Shape
{
    private string _jahColor;

    public string GetColor()
    {
        return _jahColor;
    }
    public void SetColor(string jahColor)
    {
        _jahColor = jahColor;
    }

    public abstract double GetArea();
}