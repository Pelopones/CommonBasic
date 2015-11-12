using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBasic
{
    public class Square
    {
        /*Площадь прямоугольного треугольника*/
        public static double RectangularTriangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                return 0;
            }

            return a * b / 2.0; 
        }
    }
}
