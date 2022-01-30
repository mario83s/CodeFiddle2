using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.BL.BartenderApp;

public class RecipeBook : IRecipeBook
{
    private Func<string> myInputprovider;
    private Action<string> myOutputprovider;
    private readonly Dictionary<string, Action> myRecipes;

    public RecipeBook(Func<string> inputprovider, Action<string> outputprovider)
    {
        myInputprovider = inputprovider;
        myOutputprovider = outputprovider;

        myRecipes = new Dictionary<string, Action>
        {
            { BartenderConstants.beer, ServeBeer },
            { BartenderConstants.juice, ServeJuice },
            { BartenderConstants.coke, ServeCoke },
        };
    }

    public List<string> GetAvailableDrinkNames()
    {
        return new List<string>(myRecipes.Keys);
    }

    public void MakeDrink(string drinkName)
    {
        myRecipes[drinkName].Invoke();
    }

    private void ServeBeer()
    {
        myOutputprovider("Please tell me your age:");
        string input = myInputprovider();
        int age;
        if (!int.TryParse(input, out age))
        {
            myOutputprovider("Sorry, that is no valid age");
            return;
        }
        if (!IsOverOrEqualLegalLimit(age))
        {
            myOutputprovider("Sorry, you have to be at least 18 years old to get a beer.");
            return;
        }
        myOutputprovider(" -> 🍺 Enjoy your cold beer");
    }

    private bool IsOverOrEqualLegalLimit(int age)
    {
        return age >= BartenderConstants.legalAge;
    }

    private void ServeJuice()
    {
        myOutputprovider(" -> 🍸 Here you got joice fresh juice");
    }

    private void ServeCoke()
    {
        myOutputprovider("Do you want a cold coke? (Enter 'cold' if so)");
        string input = myInputprovider();
        if (input == BartenderConstants.cold)
        {
            myOutputprovider(" -> 🍸 Here you got your very cold coke");
            return;
        }
        myOutputprovider(" -> 🍸 Here you got a nice warm coke");
    }
}