using SimpleMenu;

namespace Console.HabitTracker
{
    internal class MenuReport : Menu
    {

        public MenuReport(string title = "Application Title") : base(title)
        {
            AddMenuOption(new MenuReport.Option("Most/Least Consistent", "1"));
            AddMenuOption(new MenuReport.Option(description: "Streak Breaker Day", selector: "2"));
            AddMenuOption(new MenuReport.Option(description: "Longest/Shortest Streak", selector: "3"));
            AddMenuOption(new MenuReport.Option(description: "Totals", selector: "4"));
            AddMenuOption(new MenuReport.Option("Exit to Main Menu", "0"));
            ShowMenu();
            Program.menuSelection = Prompt(checkEnabled: true);
        }
    }
}