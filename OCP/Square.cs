using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public class Square : IShape
    {
        public double Side { get; set; }
        public double CalculateArea()
        {
            return Side * Side;
        }
    }
}
