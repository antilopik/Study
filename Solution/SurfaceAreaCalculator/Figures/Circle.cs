namespace SurfaceAreaCalculator.Figures
{
    internal class Circle : IFigure
    {
        private double a;
        public void CalculateArea()
        {
            Console.WriteLine(a * a * Math.PI);
            Console.ReadKey();
        }

        public void GetParamaetersOfFigureFromUser()
        {
            Console.WriteLine("Please enter the radius!");
            string x = Console.ReadLine();
            this.a = Convert.ToDouble(x);
        }
    }
}
