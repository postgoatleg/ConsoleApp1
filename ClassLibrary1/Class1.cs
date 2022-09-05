﻿namespace ClassLibrary1
{
    public class Trapezoid
    {
        public double x1, x2, a, y1, y2;
        /// <summary>
        /// метод для создания трапеции
        /// </summary>
        /// <param name="trapezoid"></param>
        public static void CreateTrapezoid(Trapezoid trapezoid)
        {
            trapezoid.x1 = EnterValue("x1");
            trapezoid.x2 = EnterValue("x2");
            trapezoid.a = EnterValue("основание логарифма");
            Console.WriteLine($"Вершины равны ({trapezoid.x1}; {trapezoid.y1}), ({trapezoid.x2}; {trapezoid.y2})");
        }
        /// <summary>
        /// метод для проверки возможности существования трапеции
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool IsExist(double x1, double x2, double a)
        {
            if (x1 <= 0 || x2 <= 0 || a <= 0 || a == 1 || (x1 < 1 && x2 > 1))
            {
                Console.WriteLine("Фигура не может существовать! Попробуйте снова");
                return false;
            }
            else return true;
        }
        /// <summary>
        /// метод для получения значений трапеции от пользователя
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static double EnterValue(string name)
        {
            Console.WriteLine($"Введите {name}");
            double value = Convert.ToDouble(Console.ReadLine());
            return value;
        }
        /// <summary>
        /// метод для вычисления периметра и сторон трапеции
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="a"></param>
        /// <param name="trapezoid"></param>
        public static void SideLengths(double x1, double x2, double a, Trapezoid trapezoid)
        {
            double topSide = 0, bottomSide = 0, leftSide = 0, RightSide = 0, perimeter;
            topSide = CalcIntegral(trapezoid.x1, trapezoid.x2, 20, LenghtFunction, trapezoid);
            bottomSide = Math.Abs(x2 - x1);
            leftSide = Math.Abs(Math.Log(x1, a));
            RightSide = Math.Abs(Math.Log(x2, a));
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
        public static void CalcArea(Trapezoid trapezoid)
        {
            Console.WriteLine($"Площадь = {CalcIntegral(trapezoid.x1, trapezoid.x2, 20, LogFunction, trapezoid)}");
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
        static double CalcIntegral(double a, double b, int n, Func<double, double, double> func, Trapezoid trapezoid)
        {
            double result = 0, h = (b - a) / n;

            for (int i = 0; i < n; i++)
            {
                result += func(a + h / 2 + i * h, trapezoid.a);
            }

            result *= h;
            return result;
        }
        /// <summary>
        /// метод для задания точки и проверки ее на принадлежность фигуре
        /// </summary>
        /// <param name="tr"></param>
        public static void PointOwnership(Trapezoid tr)
        {
            Console.WriteLine("Введите x-координату точки");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите у-координату точки");
            double y = Convert.ToDouble(Console.ReadLine());
            if (tr.x1 <= x && tr.x2 >= x)
            {
                if (Math.Abs(Math.Log(x, tr.a)) >= y && Math.Sign(y) == Math.Sign(Math.Log(x, tr.a)))
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