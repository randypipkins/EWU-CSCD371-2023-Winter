namespace Calculate;

public class Program
{
    public Action<string?> WriteLine
    {
        get;
        init;
    } = s => Console.WriteLine(s);

    public Func<string?> ReadLine
    {
        get;
        init;
    } = () => Console.ReadLine();

    static void Main()
    {
        Program program = new();
        Calculator calculator = new();
        bool done = false;

        program.WriteLine("Please Enter a Single-Operation Calculation" +
            "Typing exit will end the program. \n");

        do
        {
            string? input = program.ReadLine();
            if(input != null && input.Equals("exit", StringComparison.Ordinal))
            {
                done = true;
            }
            else if(input != null && Calculator.TryCalculate(input, out double output))
            {
                program.WriteLine($"Answer: {output}");
                program.WriteLine("Please enter a new equation or exit: ");
            }
            else
            {
                program.WriteLine("Invalid input, try again: ");
            }
        }
        while (!done);

    }
}