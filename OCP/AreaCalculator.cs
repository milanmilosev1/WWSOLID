namespace OCP
{
    public class AreaCalculator
    {
        // This method violates OCP, as we have to modify it to add new shapes
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