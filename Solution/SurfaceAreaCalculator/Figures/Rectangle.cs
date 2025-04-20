namespace SurfaceAreaCalculator.Figures
{
    internal class Rectangle : IFigure
    {
        private int a;
        private int b;
        public void CalculateArea()
        {
            Console.WriteLine(a * b);
            Console.ReadKey();
        }

        public void GetParamaetersOfFigureFromUser()
        {
            Console.WriteLine("Please enter two side lenghts!");
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            a = Convert.ToInt32(x);
            b = Convert.ToInt32(y);
        }
    }
}
