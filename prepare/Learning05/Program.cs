using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        Square jahShapeOne = new Square("red", 2);
        Rectangle jahShapeTwo = new Rectangle("blue", 3, 4);
        Circle jahShapeThree = new Circle("purple", 5);
        
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