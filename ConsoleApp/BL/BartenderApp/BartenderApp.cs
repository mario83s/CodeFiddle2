namespace ConsoleApp.BL.BartenderApp;

internal class BartenderApp : IApp
{
    IRecipeBook recipeBook;
    Bartender bartender;

    public bool InitApp()
    {
        recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
        bartender = new Bartender(Console.ReadLine, Console.WriteLine, recipeBook);
        return true;
    }

    public void RunApp()
    {
        bool newDrink = true;
        while (newDrink)
        {
            newDrink = bartender.AskForDrink();
        }
    }

    public void ExitApp()
    {
        StandardAppExitRoutine.ExitApp("The bar is now closing ...");
    }
}