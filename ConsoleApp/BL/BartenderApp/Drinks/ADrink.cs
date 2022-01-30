namespace ConsoleApp.BL.BartenderApp.Drinks;

internal abstract class ADrink
{
    internal string DrinkName { get; private set; }
    internal Func<string> Inputprovider { get; private set; }
    internal Action<string> Outputprovider { get; private set; }

    public ADrink(string drinkname, Func<string> inputprovider, Action<string> outputprovider)
    {
        DrinkName = drinkname;
        Inputprovider = inputprovider;
        Outputprovider = outputprovider;
    }

    internal abstract void Serve();
}