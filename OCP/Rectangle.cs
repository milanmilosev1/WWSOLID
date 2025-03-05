using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public class Rectangle : IShape
    {
        public double Heigth { get; set; }
        public double Width { get; set; }
        public double CalculateArea()
        {
            return Heigth * Width;
        }
    }
}
