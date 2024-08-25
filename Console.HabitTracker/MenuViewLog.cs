using System.Text;
using System.Text.RegularExpressions;
using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuViewLog : Menu
{
    public MenuViewLog(string title = "Application Title") : base(title)
    {
        AddMenuOption(new Option("View Log (Paginate)", "1"));
        AddMenuOption(new Option("View Log (Single Page)", "2"));
        AddMenuOption(new Option("Export Log (CSV)", "3"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        var r = Prompt(checkEnabled: true);
        switch (r)
        {
            case "1":
                ViewLog(Program.SelectedHabit ?? throw new InvalidOperationException());
                break;
            case "2":
                ViewLog(Program.SelectedHabit ?? throw new InvalidOperationException());
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
        var habitLogItems = db.GetLogItems(habit);
        var footer = new List<string>();
        StringBuilder footerLine = new();
        footer.Add("Log Line #\t\t Date\t\t Quantity\n");
        foreach (HabitLogLine i in habitLogItems)
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
                while (true){
                    var input = tempMenu.Prompt("Enter Line # to Delete (0 to exit):");
                    var re = new Regex("""\d+""");
                    bool inputInlist = false;

                    foreach (HabitLogLine habitLotItem in habitLogItems){
                        if (habitLotItem.Id == input){
                            inputInlist = true;
                            break;
                        }
                    }

                    if (re.IsMatch(input) && inputInlist){
                        db.DeleteLogItem(Program.SelectedHabit, Convert.ToInt32(input));
                        break;
                    }
                    else if (input == "0"){
                        break;
                    }
                    else {
                        continue;
                    }
                }
                break;
            case "0":
                break;
        }
    }
}