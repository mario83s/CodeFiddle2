using System.Collections.Generic;

namespace ConsoleApp.BL.BartenderApp;

internal interface IRecipeBook
{
    List<string> GetAvailableDrinkNames();
    void MakeDrink(string drinkName);
}