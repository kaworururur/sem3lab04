
//using System;

//public class MyMatrix
//{
//    private double[,] _matrix;

//    public int Rows { get; }
//    public int Columns { get; }

//    // Конструктор для создания матрицы с заданным количеством строк и столбцов
//    public MyMatrix(int rows, int columns, double minValue, double maxValue)
//    {
//        Rows = rows;
//        Columns = columns;
//        _matrix = new double[Rows, Columns];
//        FillMatrixWithRandomValues(minValue, maxValue);
//    }

//    // Заполнение матрицы случайными значениями
//    private void FillMatrixWithRandomValues(double minValue, double maxValue)
//    {
//        Random rnd = new Random();
//        for (int i = 0; i < Rows; i++)
//        {
//            for (int j = 0; j < Columns; j++)
//            {
//                _matrix[i, j] = rnd.NextDouble() * (maxValue - minValue) + minValue;
//            }
//        }
//    }

//    // Индексатор для доступа к элементам матрицы
//    public double this[int row, int col]
//    {
//        get
//        {
//            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
//            {
//                throw new IndexOutOfRangeException("Индекс вне диапазона.");
//            }
//            return _matrix[row, col];
//        }
//        set
//        {
//            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
//            {
//                throw new IndexOutOfRangeException("Индекс вне диапазона.");
//            }
//            _matrix[row, col] = value;
//        }
//    }

//    // Переопределение оператора сложения матриц
//    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
//    {
//        if (a.Rows != b.Rows || a.Columns != b.Columns)
//            throw new InvalidOperationException("Размеры матриц должны совпадать для сложения.");

//        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
//        for (int i = 0; i < a.Rows; i++)
//        {
//            for (int j = 0; j < a.Columns; j++)
//            {
//                result[i, j] = a[i, j] + b[i, j];
//            }
//        }
//        return result;
//    }

//    // Переопределение оператора вычитания матриц
//    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
//    {
//        if (a.Rows != b.Rows || a.Columns != b.Columns)
//            throw new InvalidOperationException("Размеры матриц должны совпадать для вычитания.");

//        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
//        for (int i = 0; i < a.Rows; i++)
//        {
//            for (int j = 0; j < a.Columns; j++)
//            {
//                result[i, j] = a[i, j] - b[i, j];
//            }
//        }
//        return result;
//    }

//    // Переопределение оператора умножения матриц
//    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
//    {
//        if (a.Columns != b.Rows)
//            throw new InvalidOperationException("Количество столбцов первой матрицы должно равняться количеству строк второй матрицы для умножения.");

//        MyMatrix result = new MyMatrix(a.Rows, b.Columns, 0, 0);
//        for (int i = 0; i < a.Rows; i++)
//        {
//            for (int j = 0; j < b.Columns; j++)
//            {
//                for (int k = 0; k < a.Columns; k++)
//                {
//                    result[i, j] += a[i, k] * b[k, j];
//                }
//            }
//        }
//        return result;
//    }

//    // Переопределение оператора умножения матрицы на скаляр
//    public static MyMatrix operator *(MyMatrix a, double scalar)
//    {
//        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
//        for (int i = 0; i < a.Rows; i++)
//        {
//            for (int j = 0; j < a.Columns; j++)
//            {
//                result[i, j] = a[i, j] * scalar;
//            }
//        }
//        return result;
//    }

//    // Переопределение оператора деления матрицы на скаляр
//    public static MyMatrix operator /(MyMatrix a, double scalar)
//    {
//        if (scalar == 0)
//            throw new DivideByZeroException("Деление на ноль недопустимо.");

//        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
//        for (int i = 0; i < a.Rows; i++)
//        {
//            for (int j = 0; j < a.Columns; j++)
//            {
//                result[i, j] = a[i, j] / scalar;
//            }
//        }
//        return result;
//    }

//    // Метод для вывода матрицы в строку
//    public override string ToString()
//    {
//        string result = "";
//        for (int i = 0; i < Rows; i++)
//        {
//            for (int j = 0; j < Columns; j++)
//            {
//                result += $"{_matrix[i, j]:F2} ";
//            }
//            result += Environment.NewLine;
//        }
//        return result;
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.Write("Введите количество строк в матрице: ");
//        int rows = int.Parse(Console.ReadLine());

//        Console.Write("Введите количество столбцов в матрице: ");
//        int columns = int.Parse(Console.ReadLine());

//        Console.Write("Введите минимальное значение для случайных чисел: ");
//        double minValue = double.Parse(Console.ReadLine());

//        Console.Write("Введите максимальное значение для случайных чисел: ");
//        double maxValue = double.Parse(Console.ReadLine());

//        MyMatrix matrix1 = new MyMatrix(rows, columns, minValue, maxValue);
//        MyMatrix matrix2 = new MyMatrix(rows, columns, minValue, maxValue);

//        Console.WriteLine("Матрица 1:");
//        Console.WriteLine(matrix1);

//        Console.WriteLine("Матрица 2:");
//        Console.WriteLine(matrix2);

//        // Сложение матриц
//        MyMatrix sum = matrix1 + matrix2;
//        Console.WriteLine("Сумма матриц:");
//        Console.WriteLine(sum);

//        // Вычитание матриц
//        MyMatrix difference = matrix1 - matrix2;
//        Console.WriteLine("Разность матриц:");
//        Console.WriteLine(difference);

//        // Умножение матриц
//        // Сначала создаем новую матрицу для умножения, чтобы 1-я матрица имела другие размеры
//        MyMatrix matrix3 = new MyMatrix(columns, rows, minValue, maxValue);
//        Console.WriteLine("Матрица 3 (для умножения):");
//        Console.WriteLine(matrix3);

//        MyMatrix product = matrix1 * matrix3;
//        Console.WriteLine("Произведение матриц:");
//        Console.WriteLine(product);

//        // Умножение и деление матрицы на скаляр
//        double scalar = 2.0;
//        MyMatrix scaledUp = matrix1 * scalar;
//        Console.WriteLine($"Матрица 1, умноженная на {scalar}:");
//        Console.WriteLine(scaledUp);

//        scalar = 2.0;
//        MyMatrix scaledDown = matrix1 / scalar;
//        Console.WriteLine($"Матрица 1, делённая на {scalar}:");
//        Console.WriteLine(scaledDown);
//    }
//}


//using System;
//using System.Collections.Generic;

//public class Car
//{
//    public string Name { get; set; }
//    public int ProductionYear { get; set; } // Год выпуска
//    public int MaxSpeed { get; set; } // Максимальная скорость в км/ч

//    public Car(string name, int productionYear, int maxSpeed)
//    {
//        Name = name;
//        ProductionYear = productionYear;
//        MaxSpeed = maxSpeed;
//    }

//    public override string ToString()
//    {
//        return $"{Name} (Год: {ProductionYear}, Макс. скорость: {MaxSpeed} км/ч)";
//    }
//}

//public class CarComparer : IComparer<Car>
//{
//    public enum SortCriteria
//    {
//        Name,
//        ProductionYear,
//        MaxSpeed
//    }

//    private SortCriteria _sortCriteria;

//    public CarComparer(SortCriteria sortCriteria)
//    {
//        _sortCriteria = sortCriteria;
//    }

//    public int Compare(Car x, Car y)
//    {
//        if (x == null || y == null)
//            return 0;

//        switch (_sortCriteria)
//        {
//            case SortCriteria.Name:
//                return string.Compare(x.Name, y.Name);
//            case SortCriteria.ProductionYear:
//                return x.ProductionYear.CompareTo(y.ProductionYear);
//            case SortCriteria.MaxSpeed:
//                return x.MaxSpeed.CompareTo(y.MaxSpeed);
//            default:
//                return 0;
//        }
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Car[] cars = new Car[]
//        {
//            new Car("Toyota Camry", 2020, 240),
//            new Car("Honda Accord", 2018, 220),
//            new Car("Ford Mustang", 2019, 300),
//            new Car("Audi A4", 2021, 250),
//            new Car("BMW 3 Series", 2020, 260)
//        };

//        Console.WriteLine("Исходный массив машин:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }

//        // Сортировка по названию
//        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.Name));
//        Console.WriteLine("\nСортировка по названию:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }

//        // Сортировка по году выпуска
//        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.ProductionYear));
//        Console.WriteLine("\nСортировка по году выпуска:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }

//        // Сортировка по максимальной скорости
//        Array.Sort(cars, new CarComparer(CarComparer.SortCriteria.MaxSpeed));
//        Console.WriteLine("\nСортировка по максимальной скорости:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;

public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; } // Год выпуска
    public int MaxSpeed { get; set; } // Максимальная скорость в км/ч

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return $"{Name} (Год: {ProductionYear}, Макс. скорость: {MaxSpeed} км/ч)";
    }
}

public class CarCatalog : IEnumerable<Car>
{
    private List<Car> _cars = new List<Car>();

    public void AddCar(Car car)
    {
        _cars.Add(car);
    }

    // Итератор для прямого прохода
    public IEnumerator<Car> GetEnumerator()
    {
        foreach (var car in _cars)
        {
            yield return car;
        }
    }

    // Итератор для обратного прохода
    public IEnumerable<Car> Reverse()
    {
        for (int i = _cars.Count - 1; i >= 0; i--)
        {
            yield return _cars[i];
        }
    }

    // Итератор с фильтром по году выпуска
    public IEnumerable<Car> FilterByProductionYear(int year)
    {
        foreach (var car in _cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    // Итератор с фильтром по максимальной скорости
    public IEnumerable<Car> FilterByMaxSpeed(int maxSpeed)
    {
        foreach (var car in _cars)
        {
            if (car.MaxSpeed == maxSpeed)
            {
                yield return car;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CarCatalog catalog = new CarCatalog();
        catalog.AddCar(new Car("Toyota Camry", 2020, 240));
        catalog.AddCar(new Car("Honda Accord", 2018, 220));
        catalog.AddCar(new Car("Ford Mustang", 2019, 300));
        catalog.AddCar(new Car("Audi A4", 2021, 250));
        catalog.AddCar(new Car("BMW 3 Series", 2020, 260));

        // Прямой проход по элементам массива
        Console.WriteLine("Прямой проход по элементам:");
        foreach (var car in catalog)
        {
            Console.WriteLine(car);
        }

        // Обратный проход по элементам массива
        Console.WriteLine("\nОбратный проход по элементам:");
        foreach (var car in catalog.Reverse())
        {
            Console.WriteLine(car);
        }

        // Проход по элементам массива с фильтром по году выпуска
        int filterYear = 2020;
        Console.WriteLine($"\nПроход по элементам с фильтром по году выпуска {filterYear}:");
        foreach (var car in catalog.FilterByProductionYear(filterYear))
        {
            Console.WriteLine(car);
        }

        // Проход по элементам массива с фильтром по максимальной скорости
        int filterSpeed = 220;
        Console.WriteLine($"\nПроход по элементам с фильтром по максимальной скорости {filterSpeed}:");
        foreach (var car in catalog.FilterByMaxSpeed(filterSpeed))
        {
            Console.WriteLine(car);
        }
    }
}