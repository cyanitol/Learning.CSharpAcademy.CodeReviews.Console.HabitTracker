using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuMain : Menu
{
    public MenuMain(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("Log Habit", "1"));
        AddMenuOption(new Option("View Log", "2"));
        AddMenuOption(new Option("Report Menu", "3"));
        AddMenuOption(new Option("Add New Habit", "4"));
        AddMenuOption(new Option("Switch Habit", "5"));
        AddMenuOption(new Option("Settings", "9"));
        AddMenuOption(new Option("Exit", "0"));
    }
}