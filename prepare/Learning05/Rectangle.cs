using System.Globalization;

public class Rectangle : Shape
{
    private double _jahLength;
    private double _jahWidth;

    public override double GetArea()
    {
        return _jahLength * _jahWidth;
    }

    public void SetLength(double jahLength)
    {
        _jahLength = jahLength;
    }
    public void SetWidth(double jahWidth)
    {
        _jahWidth = jahWidth;
    }
}