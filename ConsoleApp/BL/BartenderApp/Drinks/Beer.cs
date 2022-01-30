namespace ConsoleApp.BL.BartenderApp.Drinks;

internal class Beer : ADrink
{
    public Beer(Func<string> inputprovider, Action<string> outputprovider)
        : base(nameof(Beer), inputprovider, outputprovider)
    {
    }

    override internal void Serve()
    {
        if (!CheckForValidAge())
        {
            return;
        }
        Outputprovider(" ->  |_|  Enjoy your cold beer");
    }

    private bool CheckForValidAge()
    {
        Outputprovider("Please tell me your age:");
        string ageString = Inputprovider();
        int age;
        if (!int.TryParse(ageString, out age))
        {
            Outputprovider("Sorry, that is no valid age");
            return false;
        }
        if (!IsOverOrEqualLegalLimit(age))
        {
            Outputprovider("Sorry, you have to be at least 18 years old to get a beer.");
            return false;
        }
        return true;
    }

    private bool IsOverOrEqualLegalLimit(int age)
    {
        return age >= BartenderConstants.legalAgeForABeer;
    }
}