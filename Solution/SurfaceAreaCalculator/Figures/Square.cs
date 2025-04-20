using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfaceAreaCalculator.Figures
{
    internal class Square : IFigure
    {
        private int a; 

        public void CalculateArea()
        {
            Console.WriteLine(a * a);
            Console.ReadKey();
        }

        public void GetParamaetersOfFigureFromUser()
        {
            Console.WriteLine("Please enter one side lenght!");
            string x = Console.ReadLine();
            a = Convert.ToInt32(x);
        }
    }
}
