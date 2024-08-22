using System.Text;
using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuViewLog : Menu
{
    public MenuViewLog(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("View Log", "1"));
        AddMenuOption(new Option("Search Log", "2"));
        AddMenuOption(new Option("Export Log", "3"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        var r = Prompt(checkEnabled: true);
        switch (r)
        {
            case "1":
                ViewLog(Program.SelectedHabit ?? throw new InvalidOperationException());
                break;
            case "2":
                break;
            case "3":
                break;
            case "0":
                break;
        }
    }

    private static void ViewLog(string habit)
    {
        Database db = new();
        var r = db.GetLogItems(habit);
        var footer = new List<string>();
        StringBuilder footerLine = new();
        footer.Add("Log Line #\t\t Date\t\t Quantity\n");
        foreach (HabitLogLine i in r)
        {
            footerLine.Clear();
            footerLine.AppendFormat($"\t{i.Id}\t\t{i.Date}\t\t{i.Quantity}");
            footer.Add(footerLine.ToString());
        }

        Menu tempMenu = new(title: $" HABIT TRACKER :: Log Data for {Program.SelectedHabit} Habit");
        tempMenu.AddMenuOption(new Option("Delete log line", "1"));
        tempMenu.AddMenuOption(new Option("Return to Main Menu", "0"));
        tempMenu.ShowMenu(footerContent: footer);

        var response = tempMenu.Prompt();
        switch (response)
        {
            case "1":
                tempMenu.Prompt("Enter Line # to Delete (0 to exit):");
                break;
            case "0":
                break;
        }
    }
}