namespace CanHazFunny
{
    public class Program
    {
        static void Main(string[] args)
        {
            Jester jester = new(new JokeOutput(), new JokeService());

            jester.TellJoke();
        }
    }
}
