
using ClassLibrary1;

Trapezoid trapezoid = new(); //создание экземпляра класса
int menuItem = 0; //переменная для управления пользовательским меню 
//цикл, обеспечивающий отображение и функционирование меню
while (menuItem != 5)
{
    Console.Clear();
    Console.WriteLine("1. Задать параметры криволинейной трапеции");
    Console.WriteLine("2. Вычисление длины сторон и периметра");
    Console.WriteLine("3. Вычисление площади");
    Console.WriteLine("4. Проверка принадлежности точки");
    Console.WriteLine("5. Выход");
    menuItem=Convert.ToInt32(Console.ReadLine());
    switch(menuItem)
    {
        case 1:
            {
                do
                {
                    Trapezoid.CreateTrapezoid(trapezoid);
                }
                while (Trapezoid.IsExist(trapezoid.x1, trapezoid.x2, trapezoid.a) == false);
            }
            break;
        case 2:
            Trapezoid.SideLengths(trapezoid.x1, trapezoid.x2, trapezoid.a, trapezoid);
            break;
        case 3:
            Trapezoid.CalcArea(trapezoid);
            break;
        case 4:
            Trapezoid.PointOwnership(trapezoid);
            break;
        default:
            break;

    }
}