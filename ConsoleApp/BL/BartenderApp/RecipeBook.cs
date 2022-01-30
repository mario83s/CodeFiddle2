using ConsoleApp.BL.BartenderApp.Drinks;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.BL.BartenderApp;

internal class RecipeBook : IRecipeBook
{
    private Func<string> Inputprovider;
    private Action<string> Outputprovider;
    private readonly List<ADrink> Drinks;

    internal RecipeBook(Func<string> inputprovider, Action<string> outputprovider)
    {
        Inputprovider = inputprovider;
        Outputprovider = outputprovider;

        Drinks = new List<ADrink>()
        {
            { new Juice(inputprovider, outputprovider) },
            { new Coke(inputprovider, outputprovider ) },
            { new Beer(inputprovider, outputprovider) },
        };
    }

    IEnumerable<string> IRecipeBook.GetAvailableDrinkNames()
    {
        return from d in Drinks select d.DrinkName;
    }

    public void MakeDrink(string drinkName)
    {
        ADrink candidate = Drinks.FirstOrDefault(d => string.Equals(d.DrinkName, drinkName, StringComparison.InvariantCultureIgnoreCase));
        candidate?.Serve();
    }
}