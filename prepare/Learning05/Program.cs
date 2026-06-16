using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        Square jahShapeOne = new Square();
        jahShapeOne.SetColor("red");
        jahShapeOne.SetSide(2);

        Rectangle jahShapeTwo = new Rectangle();
        jahShapeTwo.SetColor("blue");
        jahShapeTwo.SetLength(3);
        jahShapeTwo.SetWidth(4);

        Circle jahShapeThree = new Circle();
        jahShapeThree.SetColor("red");
        jahShapeThree.SetRadius(2);
        

        List<Shape> jahShapes = new List<Shape>();
        jahShapes.Add(jahShapeOne);
        jahShapes.Add(jahShapeTwo);
        jahShapes.Add(jahShapeThree);

        foreach (Shape jahShape in jahShapes){
            Support.Display($"{jahShape.GetColor()}");
            Support.Display($"{jahShape.GetArea()}");
        }
    }
}