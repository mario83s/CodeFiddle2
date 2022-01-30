using ConsoleApp.BL.BartenderApp.Drinks;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.BL.BartenderApp;

internal class RecipeBook : IRecipeBook
{
    private readonly List<ADrink> Drinks;

    internal RecipeBook(Func<string> inputprovider, Action<string> outputprovider)
    {
        Drinks = new List<ADrink>()
        {
            { new Juice(inputprovider, outputprovider) },
            { new Coke(inputprovider, outputprovider ) },
            { new Beer(inputprovider, outputprovider) },
        };
    }

    IEnumerable<string> IRecipeBook.GetAvailableDrinkNames()
    {
        return from drink in Drinks select drink.DrinkName;
    }

    public void MakeDrink(string wantedDrinkName)
    {
        ADrink drinCandidate = Drinks.FirstOrDefault(drink => string.Equals(drink.DrinkName, wantedDrinkName, StringComparison.InvariantCultureIgnoreCase));
        drinCandidate?.Serve();
    }
}