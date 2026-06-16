using System.Globalization;

public class Circle : Shape
{
    private double _jahRadius;

    public override double GetArea()
    {
        return Math.PI * _jahRadius * _jahRadius;
    }

    public void SetRadius(double jahRadius)
    {
        _jahRadius = jahRadius;
    }
}