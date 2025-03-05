using OCP;

var areaCalculator = new AreaCalculator();

var circle = new Circle { Radius = 5 };
var rectangle = new Rectangle { Length = 4, Width = 6 };
var square = new Square { Side = 4 };
var triangle = new Triangle { Base = 4, Height = 6 };

Console.WriteLine($"Area of circle: {areaCalculator.CalculateArea(circle)}");
Console.WriteLine($"Area of rectangle: {areaCalculator.CalculateArea(rectangle)}");
Console.WriteLine($"Area of square: {areaCalculator.CalculateArea(square)}");
Console.WriteLine($"Area of triangle: {areaCalculator.CalculateArea(triangle)}");