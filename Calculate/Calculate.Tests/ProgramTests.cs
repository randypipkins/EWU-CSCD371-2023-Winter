namespace Calculate.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestWriteLine()
    {
        StringWriter expected = new();

        Console.SetOut(expected);
        Program program = new();
        program.WriteLine("test");

        Assert.AreEqual("test", expected.ToString().Trim());
    }

    [TestMethod]
    public void TestReadLine()
    {
        StringReader expected = new("test");

        Console.SetIn(expected);
        Program program = new();
        String? actual = program.ReadLine();

        Assert.IsNotNull(actual);
        Assert.AreEqual<string>("test", actual);
    }
}