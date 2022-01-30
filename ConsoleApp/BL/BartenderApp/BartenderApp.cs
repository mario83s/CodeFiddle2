namespace ConsoleApp.BL.BartenderApp;

internal class BartenderApp : IApp
{
    private IRecipeBook recipeBook;
    private Bartender bartender;

    bool IApp.InitApp()
    {
        recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
        bartender = new Bartender(Console.ReadLine, Console.WriteLine, recipeBook);
        return true;
    }

    void IApp.RunApp()
    {
        bool newDrink = true;
        while (newDrink)
        {
            newDrink = bartender.AskForDrink();
        }
    }

    void IApp.ExitApp()
    {
        StandardAppExitRoutine.ExitApp("The bar is now closing ...");
    }
}