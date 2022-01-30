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
        string drinkName = myInputprovider();
        if (drinkName == BartenderConstants.sitt)
        {
            return false;
        }
        TryServeDrink(drinkName);
        return true;
    }

    private void TryServeDrink(string drinkName)
    {
        if (!myRecipeBook.GetAvailableDrinkNames().Any(name => string.Equals(name, drinkName, StringComparison.InvariantCultureIgnoreCase)))
        {
            myOutputprovider($"Sorry, we don't provide the drink {drinkName}");
            return;
        }
        myRecipeBook.MakeDrink(drinkName);
    }
}