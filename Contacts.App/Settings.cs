namespace Contacts.App;
public class Settings
{
    public string SettingsA { get; set; } 
    public SettingsB? SettingsB { get; set; }
    public string[] SettingsC { get; set; }
}

public class SettingsB
{
    public string B_A { get; set; }
    public int B_B { get; set; }
    public bool B_C { get; set; }
}
