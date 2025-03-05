namespace OCP
{
    public class AreaCalculator
    {
        // This method violates OCP, as we have to modify it to add new shapes
        public double CalculateTotalArea(Shape[] shapes)
        {
            double TotalArea = 0;
            foreach(var ShapeObject in shapes)
            {
                TotalArea += ShapeObject.Area();
            }
            return TotalArea;
        }
    }

    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Heigth { get; set; }
        public double Width { get; set; }
        public override double Area()
        {
            return Heigth * Width;
        }
    }

    public class Square : Shape
    {
        public double Side { get; set; }
        public override double Area()
        {
            return Side * Side;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return 0.5 * Base * Height;
        }
    }
}