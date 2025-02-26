namespace OCP
{
	public class AreaCalculator
	{
		// This method violates OCP, as we have to modify it to add new shapes
		public double CalculateArea(object shape)
		{
			if (shape is Circle)
			{
				var circle = (Circle)shape;
				return Math.PI * circle.Radius * circle.Radius;
			}
			else if (shape is Rectangle)
			{
				var rectangle = (Rectangle)shape;
				return rectangle.Length * rectangle.Width;
			}
			else if (shape is Square)
			{
				var square = (Square)shape;
				return square.Side * square.Side;
			}
			else if (shape is Triangle)
			{
				var triangle = (Triangle)shape;
				return 0.5 * triangle.Base * triangle.Height;
			}
			else if (shape is Hexagon)
			{
				var hexagon = (Hexagon)shape;
				return (3 * Math.Sqrt(3) / 2) * hexagon.Side * hexagon.Side;
			}
			else if (shape is Trapezoid)
			{
				var trapezoid = (Trapezoid)shape;
				return 0.5 * (trapezoid.Base1 + trapezoid.Base2) * trapezoid.Height;
			}
			else
			{
				throw new InvalidOperationException("Shape type not supported");
			}
		}
	}

	public class Circle
	{
		public double Radius { get; set; }
	}

	public class Rectangle
	{
		public double Length { get; set; }
		public double Width { get; set; }
	}

	public class Square
	{
		public double Side { get; set; }
	}

	public class Triangle
	{
		public double Base { get; set; }
		public double Height { get; set; }
	}

	public class Hexagon
	{
		public double Side { get; set; }
	}

	public class Trapezoid
	{
		public double Base1 { get; set; }
		public double Base2 { get; set; }
		public double Height { get; set; }
	}
}
