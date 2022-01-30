using System.Linq;

namespace ConsoleApp.BL.BartenderApp;

internal class Bartender
{
    private Func<string> myInputprovider;
    private Action<string> myOutputprovider;
    private readonly IRecipeBook myRecipeBook;

    internal Bartender(Func<string> inputprovider, Action<string> outputprovider, IRecipeBook recipeBook)
    {
        myInputprovider = inputprovider;
        myOutputprovider = outputprovider;
        myRecipeBook = recipeBook;
    }

    internal bool AskForDrink()
    {
        var availableDrinknames = string.Join(", ", myRecipeBook.GetAvailableDrinkNames());
        myOutputprovider($"What drink do you want? We serve: {availableDrinknames} or say 'sitt'");
        string wantedDrinkName = myInputprovider();
        if (wantedDrinkName == BartenderConstants.sitt)
        {
            return false;
        }
        TryServeDrink(wantedDrinkName);
        return true;
    }

    private void TryServeDrink(string wantedDrinkName)
    {
        if (!myRecipeBook.GetAvailableDrinkNames().Any(name => string.Equals(name, wantedDrinkName, StringComparison.InvariantCultureIgnoreCase)))
        {
            myOutputprovider($"Sorry, we don't provide the drink {wantedDrinkName}");
            return;
        }
        myRecipeBook.MakeDrink(wantedDrinkName);
    }
}