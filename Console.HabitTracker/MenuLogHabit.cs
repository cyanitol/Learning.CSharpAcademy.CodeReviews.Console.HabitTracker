using System.Text.RegularExpressions;
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

    private static void DoSelection(string s)
    {
        switch (s)
        {
            case "1":
                LogHabit();
                break;
            case "2":
                LogHabit(now: false);
                break;
        }
    }

    public static void AddDemoData()
    {
        var rnd = new Random();
        var db = new Database();

        var datetime = new DateTime();
        for (var i = 0; i <= 100; i++)
        {
            datetime = DateTime.Now - new TimeSpan(days: 365, 0, 0, 0);
            datetime = datetime.AddDays(rnd.Next(0, 365));

            var date = new DateOnly(datetime.Year, datetime.Month, datetime.Day);
            db.AddLogItem("Demo", date, rnd.Next(0, 10));
        }
    }

    private static void LogHabit(bool now = true)
    {
        var db = new Database();
        var date = new DateOnly();

        if (now)
        {
            date = DateOnly.FromDateTime(DateTime.Now);
        }
        else
        {
            Menu tempMenu = new();

            while (true)
            {
                var re = new Regex("[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]");
                var r = tempMenu.Prompt("Please enter the date (yyyy-mm-dd):");
                var q = re.IsMatch(r);

                if (r == null)
                    continue;

                if (q)
                {
                    date = DateOnly.Parse(r);
                    break;
                }

                else
                {
                    continue;
                    System.Console.WriteLine("Error!");
                    System.Console.ReadLine();
                }

            }
        }

        db.AddLogItem(Program.SelectedHabit ?? throw new InvalidOperationException(), date, 1);
    }
}