
namespace SurfaceAreaCalculator.Figures
{
    internal class Triangle : IFigure
    {
        private int a;
        private int b;
        public void CalculateArea()
        {
            Console.WriteLine(a * b / 2);
        }

        public void GetParamaetersOfFigureFromUser()
        {
            Console.WriteLine("Please enter height!");
            string x = Console.ReadLine();
            Console.WriteLine("Please enter base!");
            string y = Console.ReadLine();
            a = Convert.ToInt32(x);
            b = Convert.ToInt32(y);
        }
    }
}
