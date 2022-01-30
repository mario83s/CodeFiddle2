namespace ConsoleApp.BL.BartenderApp.Drinks;

internal class Beer : ADrink
{
    public Beer(Func<string> inputprovider, Action<string> outputprovider)
        : base(nameof(Beer), inputprovider, outputprovider)
    {
    }

    override internal void Serve()
    {
        Outputprovider("Please tell me your age:");
        string input = Inputprovider();
        int age;
        if (!int.TryParse(input, out age))
        {
            Outputprovider("Sorry, that is no valid age");
            return;
        }
        if (!IsOverOrEqualLegalLimit(age))
        {
            Outputprovider("Sorry, you have to be at least 18 years old to get a beer.");
            return;
        }
        Outputprovider(" -> 🍺 Enjoy your cold beer");
    }

    private bool IsOverOrEqualLegalLimit(int age)
    {
        return age >= BartenderConstants.legalAge;
    }
}