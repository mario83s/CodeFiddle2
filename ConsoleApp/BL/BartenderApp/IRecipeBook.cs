using System.Collections.Generic;

namespace ConsoleApp.BL.BartenderApp;

internal interface IRecipeBook
{
    IEnumerable<string> GetAvailableDrinkNames();
    void MakeDrink(string drinkName);
}