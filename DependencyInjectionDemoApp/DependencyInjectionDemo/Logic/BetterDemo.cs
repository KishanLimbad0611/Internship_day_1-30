namespace DependencyInjectionDemo.Logic;
public class BetterDemo : IDemoLogic
{
    public int Value1 { get; private set; }
    public int Value2 { get; private set; }
    public BetterDemo() 
    {
        Value1 = 25;

        Value2 = 50;
    }
}

