namespace ConsoleApp.BL.BartenderApp.Drinks;

internal class Coke : ADrink
{
    public Coke(Func<string> inputprovider, Action<string> outputprovider)
        : base(nameof(Coke), inputprovider, outputprovider)
    {
    }

    override internal void Serve()
    {
        Outputprovider("Do you want a cold coke? (Enter 'cold' if so)");
        string input = Inputprovider();
        if (input == BartenderConstants.cold)
        {
            Outputprovider(" -> 🍸 Here you got your very cold coke");
            return;
        }
        Outputprovider(" -> 🍸 Here you got a nice warm coke");
    }
}