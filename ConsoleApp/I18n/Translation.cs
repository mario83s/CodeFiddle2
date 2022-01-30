namespace ConsoleApp.I18n;

public class Translation
{
    public string StrDE { get; set; }
    public string StrEN { get; set; }

    public Translation(string de, string en)
    {
        StrDE = de;
        StrEN = en;
    }

    public string T7e => Translate();

    private string Translate()
    {
        return L11n.CurrentLocale == SupportedLocale.DE ? StrDE : StrEN;
    }
}