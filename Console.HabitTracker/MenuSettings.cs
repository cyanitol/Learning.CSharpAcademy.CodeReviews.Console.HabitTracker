using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuSettings : Menu
{

    public MenuSettings(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("Modify Habit", "1"));
        AddMenuOption(new Option("Add Habit", "2"));
        AddMenuOption(new Option("Delete Habit", "3"));
        AddMenuOption(new Option("Reset Database", "4"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        DoSelection(Program.MenuSelection = Prompt(checkEnabled: true) ?? throw new InvalidOperationException());
    }

        private static void DoSelection(string s)
    {
        switch (s)
        {
            case "1":
                // ModifyHabit();
                break;
            case "2":
                _ = new MenuAddHabit();
                break;
        }
    }
}