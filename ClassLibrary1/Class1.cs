namespace ClassLibrary1
{
    public class Trapezoid
    {
        public double X1, X2, A, Y1, Y2;

        public Trapezoid(double X1, double X2, double A)
        {
            this.X1 = X1;
            this.X2 = X2;
            this.A = A;
        }

        /// <summary>
        /// метод для проверки возможности существования трапеции
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool IsExist()
        {
            if (X1 <= 0 || X2 <= 0 || A <= 0 || A == 1 || (X1 < 1 && X2 > 1))
            {
                Console.WriteLine("Фигура не может существовать! Попробуйте снова");
                return false;
            }
            else return true;
        }
        /// метод для вычисления периметра и сторон трапеции
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="a"></param>
        /// <param name="trapezoid"></param>
        public void SideLengths()
        {
            double topSide = 0, bottomSide = 0, leftSide = 0, RightSide = 0, perimeter;
            topSide = CalcIntegral(20, LenghtFunction);
            bottomSide = Math.Abs(X2 - X1);
            leftSide = Math.Abs(Math.Log(X1, A));
            RightSide = Math.Abs(Math.Log(X2, A));
            perimeter = topSide + bottomSide + leftSide + RightSide;
            Console.WriteLine($"Верхняя сторона = {topSide}, нижняя сторона = {bottomSide}, левая сторона = {leftSide}, правая сторона = {RightSide}");
            Console.WriteLine($"Периметр = {perimeter}");
            Console.ReadLine();

        }
        /// <summary>
        /// метод для вычисления логарифма
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        static double LogFunction(double x, double a)
        {
            return Math.Abs(Math.Log(x, a));
        }
        /// <summary>
        /// метод для вычисления площади
        /// </summary>
        /// <param name="trapezoid"></param>
        public void CalcArea()
        {
            Console.WriteLine($"Площадь = {CalcIntegral(20, LogFunction)}");
            Console.ReadLine();
        }
        /// <summary>
        /// метод для вычисления длины кривой 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        static double LenghtFunction(double x, double a)
        {
            return Math.Sqrt(1 + 1 / (x * Math.Log(a)));
        }
        /// <summary>
        /// метод для вычисления интеграла способом средних прямоугольников
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <param name="func"></param>
        /// <param name="trapezoid"></param>
        /// <returns></returns>
        double CalcIntegral( int n, Func<double, double, double> func)
        {
            double result = 0, h = (X2 - X1) / n;

            for (int i = 0; i < n; i++)
            {
                result += func(X1 + h / 2 + i * h, A);
            }

            result *= h;
            return result;
        }
        /// <summary>
        /// метод для задания точки и проверки ее на принадлежность фигуре
        /// </summary>
        /// <param name="tr"></param>
        public void PointOwnership()
        {
            Console.WriteLine("Введите x-координату точки");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите у-координату точки");
            double y = Convert.ToDouble(Console.ReadLine());
            if (X1 <= x && X2 >= x)
            {
                if (Math.Abs(Math.Log(x, A)) >= y && Math.Sign(y) == Math.Sign(Math.Log(x, A)))
                {
                    Console.WriteLine("Точка принадлежит фигуре");
                }
                else
                {
                    Console.WriteLine("Точка не принадлежит");
                }
            }
            else
            {
                Console.WriteLine("Точка не принадлежит");
            }

            Console.ReadLine();
        }
    }
}