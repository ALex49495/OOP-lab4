using System;

struct Triangle
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
    public double AngleAB { get; set; }

    public Triangle(double sideA, double sideB, double sideC, double angleAB)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        AngleAB = angleAB;
    }

    public double GetPerimeter()
    {
        return SideA + SideB + SideC;
    }

    public double GetArea()
    {
        double angleRad = AngleAB * Math.PI / 180;
        return 0.5 * SideA * SideB * Math.Sin(angleRad);
    }

    public double GetHeightFromBase(double baseLength)
    {
        double area = GetArea();
        return 2 * area / baseLength;
    }

    public string GetTriangleType()
    {
        if (SideA == SideB && SideB == SideC)
            return "Рівносторонній";
        if (SideA == SideB || SideB == SideC || SideA == SideC)
            return "Рівнобедренний";
        if (IsRightTriangle())
            return "Прямокутний";
        return "Різносторонній";
    }

    private bool IsRightTriangle()
    {
        double angleRad = AngleAB * Math.PI / 180;
        return Math.Abs(Math.Sin(angleRad) - 1) < 1e-10 ||
               Math.Abs(Math.Sin(angleRad) - 0.5 * Math.Sqrt(3)) < 1e-10 ||
               Math.Abs(Math.Sin(angleRad) - 0.5) < 1e-10;
    }

    public void PrintInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Сторони: A = {SideA}, B = {SideB}, C = {SideC}");
        Console.WriteLine($"Кут між сторонами A та B: {AngleAB}°");
        Console.WriteLine($"Периметр: {GetPerimeter()}");
        Console.WriteLine($"Площа: {GetArea()}");
        Console.WriteLine($"Тип трикутника: {GetTriangleType()}");
        Console.WriteLine($"Висота з основи A: {GetHeightFromBase(SideA)}");
        Console.WriteLine($"Висота з основи B: {GetHeightFromBase(SideB)}");
        Console.WriteLine($"Висота з основи C: {GetHeightFromBase(SideC)}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Triangle triangle = new Triangle(3, 4, 5, 90);
            triangle.PrintInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Робота програми завершена.");
        }
    }
}
