using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuSettings : Menu
{

    public MenuSettings(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("Modify Habit", "1"));
        AddMenuOption(new Option("Clear Database", "2"));
        AddMenuOption(new Option("Add Demo Data to Database", "3"));
        AddMenuOption(new Option("Backup Database", "4"));
        AddMenuOption(new Option("Export Database", "5"));
        AddMenuOption(new Option("Database Config", "6"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        Program.MenuSelection = Prompt(checkEnabled: true);
    }
}