namespace ConsoleApp.BL.BartenderApp.Drinks;

internal class Juice : ADrink
{
    public Juice(Func<string> inputprovider, Action<string> outputprovider)
        : base(nameof(Juice), inputprovider, outputprovider)
    {
    }

    override internal void Serve()
    {
        Outputprovider(" -> 🍸 Here you got joice fresh juice");
    }
}