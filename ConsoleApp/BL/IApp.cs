namespace ConsoleApp.BL;

internal interface IApp
{
    void Run()
    {
        try
        {
            if (InitApp())
            {
                RunApp();
            }
        }
        catch (Exception ex)
        {
            ConsoleTextHelper.Error(ex.Message);
        }
        finally
        {
            try
            {
                ExitApp();
            }
            catch (Exception ex)
            {
                ConsoleTextHelper.Error(ex.Message);
            }
        }
    }

    bool InitApp();
    void RunApp();
    void ExitApp();
}