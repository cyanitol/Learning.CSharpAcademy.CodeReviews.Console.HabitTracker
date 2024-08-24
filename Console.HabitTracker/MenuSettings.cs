using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuSettings : Menu
{

    public MenuSettings(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("Modify Habit", "1"));
        AddMenuOption(new Option("Delete Habit", "2"));
        AddMenuOption(new Option("Reset Database with Demo Data", "3"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        Program.MenuSelection = Prompt(checkEnabled: true);
    }
}