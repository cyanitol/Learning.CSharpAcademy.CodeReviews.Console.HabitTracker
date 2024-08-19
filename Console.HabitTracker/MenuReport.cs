using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuReport : Menu
{

    public MenuReport(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("Most/Least Consistent", "1"));
        AddMenuOption(new Option(description: "Streak Breaker Day", selector: "2"));
        AddMenuOption(new Option(description: "Longest/Shortest Streak", selector: "3"));
        AddMenuOption(new Option(description: "Totals", selector: "4"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        Program.MenuSelection = Prompt(checkEnabled: true);
    }
}