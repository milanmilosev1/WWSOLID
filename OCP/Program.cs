using OCP;

AreaCalculator areaCalculator = new AreaCalculator();
List<IShape>? shapes = new List<IShape>();

Circle circle = new() { Radius = 10 };
Rectangle rect = new() { Heigth = 10, Width = 20};
Square square = new() { Side = 50 };
Triangle triangle = new() { Base = 5, Height = 10 };

shapes.Add(circle);
shapes.Add(triangle);
shapes.Add(square);
shapes.Add(rect);

Console.WriteLine("Circle area: " + circle.CalculateArea());
Console.WriteLine("Rectangle area: " + rect.CalculateArea());
Console.WriteLine("Square area; " + square.CalculateArea());
Console.WriteLine("Triangle area: " + triangle.CalculateArea());

Console.WriteLine("\nTotal area: " + areaCalculator.CalculateTotalArea(shapes));
