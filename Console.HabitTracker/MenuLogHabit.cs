using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuLogHabit : Menu
{

    public MenuLogHabit(string title = "Application name") : base(title)
    {
        AddMenuOption(new Option("Log Now", "1"));
        AddMenuOption(new Option("Log Previous", "2"));
        AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        DoSelection(Prompt(checkEnabled: true) ?? throw new InvalidOperationException());
    }

    private static void DoSelection(string s){
        switch (s){
            case "1":
                LogHabit();
                break;
            case "2":
                LogHabit(now: false);
                break;
        }
    }

    private static void LogHabit(bool now = true){
        var db = new Database();
        var date = new DateOnly();

        if (now){
            date = DateOnly.FromDateTime(DateTime.Now);
        }
        else{
            Menu tempMenu = new();

            while (true)
            {
                var r = tempMenu.Prompt("Please enter the 3date (yyyy-mm-dd)");
                if (r == null) continue;
                try
                {
                    date = DateOnly.Parse(r);
                    break;
                }
                catch (FormatException e)
                {
                    continue;
                }
            }
        }
                
        db.AddLogItem(Program.SelectedHabit ?? throw new InvalidOperationException(), date, 1);
    }
}