namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    Calculator calculator = new();

    [TestMethod]
    public void ValidateDictionaryContents()
    {
        Func<int, int, double> Add = Calculator.Add;
        Func<int, int, double> Sub = Calculator.Subtract;
        Func<int, int, double> Div = Calculator.Divide;
        Func<int, int, double> Mult = Calculator.Multiply;

        Assert.AreEqual<Func<int, int, double>>(Add, calculator.MathematicalOperations['+']);
        Assert.AreEqual<Func<int, int, double>>(Sub, calculator.MathematicalOperations['-']);
        Assert.AreEqual<Func<int, int, double>>(Div, calculator.MathematicalOperations['/']);
        Assert.AreEqual<Func<int, int, double>>(Mult, calculator.MathematicalOperations['*']);
    }
    [TestMethod]
    public void TestIfAddIsValid()
    {
        Assert.AreEqual<double>(Calculator.Add(1, 1), 2);
    }

    [TestMethod]
    public void TestIfSubtractIsValid()
    {
        Assert.AreEqual<double>(Calculator.Subtract(10, 5), 5);
    }

    [TestMethod]
    public void TestIfDivideIsValid()
    {
        Assert.AreEqual<double>(Calculator.Divide(10, 5), 2);
    }

    [TestMethod]
    public void TestIfMultiplyIsValid()
    {
        Assert.AreEqual<double>(Calculator.Multiply(2, 1), 2);
    }

    [TestMethod]
    public void TestTryCalculateAdd()
    {
        String input = "1 + 1";
        double output;
        double expected = 2;
        bool isTrue = Calculator.TryCalculate(input, out output);
        Assert.IsTrue(isTrue);
        Assert.AreEqual<double>(expected, output);
    }

    [TestMethod]
    public void TestTryCalculateSub()
    {
        String input = "2 - 1";
        double output;
        double expected = 1;
        bool isTrue = Calculator.TryCalculate(input, out output);
        Assert.IsTrue(isTrue);
        Assert.AreEqual<double>(expected, output);
    }

    [TestMethod]
    public void TestTryCalculateDiv()
    {
        String input = "1 / 1";
        double output;
        double expected = 1;
        bool isTrue = Calculator.TryCalculate(input, out output);
        Assert.IsTrue(isTrue);
        Assert.AreEqual<double>(expected, output);
    }

    [TestMethod]
    public void TestTryCalculateMult()
    {
        String input = "1 * 1";
        double output;
        double expected = 1;
        bool isTrue = Calculator.TryCalculate(input, out output);
        Assert.IsTrue(isTrue);
        Assert.AreEqual<double>(expected, output);
    }
}