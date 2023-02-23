namespace Calculate;

public class Calculator
{
    public static double Add(int a, int b)
    {
        return a + b;
    }

    public static double Subtract(int a, int b)
    {
        return a - b;
    }

    public static double Divide(int a, int b)
    {
        return a / b;
    }

    public static double Multiply(int a, int b)
    {
        return a * b;
    }
    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations
    {
        get;
    }
    = new Dictionary<char, Func<int, int, double>>
    {
        {
            '+', Add
        },
        {
            '-', Subtract
        },
        {
            '/', Divide
        },
        {
            '*', Multiply
        }
    };

    public bool TryCalculate(string input, out double output)
    {
        output = 0;
        bool canCalculate = false;

        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        string[] inputArray = input.Split(" ");
        int i1, i2;
        char mathOp;
        Calculator calculator = new();

        if(inputArray.Length < 3)
        {
            return canCalculate;
        }

        if (int.TryParse(inputArray[0], out i1) && char.TryParse(inputArray[1], out mathOp) && int.TryParse(inputArray[2], out i2))
        {
            canCalculate= true;
            Func<int, int, double> func = calculator.MathematicalOperations[mathOp];
            output = func(i1, i2);
        }

        return canCalculate;
    }
}