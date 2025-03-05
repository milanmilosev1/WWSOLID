using OCP;

var areaCalculator = new AreaCalculator();

Shape[] shapes = new Shape[4];

Circle circle = new Circle { Radius = 10 };
Rectangle rect = new Rectangle { Heigth = 10, Width = 20};
Square square = new Square { Side = 50 };
Triangle triangle = new Triangle { Base = 5, Height = 10 };

shapes[0] = circle;
shapes[1] = rect;
shapes[2] = square;
shapes[3] = triangle;

Console.WriteLine("Circle area: " + circle.Area());
Console.WriteLine("Rectangle area: " + rect.Area());
Console.WriteLine("Square area; " + square.Area());
Console.WriteLine("Triangle area: " + triangle.Area());

Console.WriteLine("\nTotal area: " + areaCalculator.CalculateTotalArea(shapes));
