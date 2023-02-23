namespace Calculate.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestWriteLine()
    {
        StringWriter sw = new();

        Console.SetOut(sw);
        Program program = new();
        program.WriteLine("test");
        string expected = sw.ToString().Trim();

        Assert.AreEqual<string>("test", expected);
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