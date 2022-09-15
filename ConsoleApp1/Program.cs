using ClassLibrary1;

Trapezoid trapezoid;


int menuItem = 0; //переменная для управления пользовательским меню 
//цикл, обеспечивающий отображение и функционирование меню
do
{
    trapezoid = new(entValue("X1"), entValue("X2"), entValue("A")); //создание экземпляра класса
}
while (trapezoid.IsExist() == false);
while (menuItem != 5)
{
    Console.Clear();
    Console.WriteLine("1. Вычисление длины сторон и периметра");
    Console.WriteLine("2. Вычисление площади");
    Console.WriteLine("3. Проверка принадлежности точки");
    Console.WriteLine("4. Выход");
    menuItem=Convert.ToInt32(Console.ReadLine());
    switch(menuItem)
    {

        case 1:
            trapezoid.SideLengths();
            break;
        case 2:
            trapezoid.CalcArea();
            break;
        case 3:
            trapezoid.PointOwnership();
            break;
        default:
            break;

    }
}

double entValue(string name)
{
    Console.WriteLine($"Введите {name}");
    return Convert.ToDouble(Console.ReadLine());
}