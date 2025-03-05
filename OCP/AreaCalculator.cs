namespace OCP
{
    public class AreaCalculator
    {
        public double CalculateTotalArea(List<IShape> shapes)
        {
            double TotalArea = 0;
            foreach (var ShapeObject in shapes)
            {
                TotalArea += ShapeObject.CalculateArea();
            }
            return TotalArea;
        }
    }
}