using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuSelectHabit : Menu
{
    public MenuSelectHabit(string title = "Application Title", bool firstRun = false) : base(title)
    {
        Init(firstRun);
    }
    private void Init(bool firstRun = false)
    {
        Database db = new();
        var menuOptionCounter = 1;
        foreach (var result in db.GetLogCategories())
        {
            var item = Convert.ToString(result);
            if (item == "sqlite_sequence") continue;
            if (item != null) AddMenuOption(new Option(item.ToUpper(), menuOptionCounter.ToString()));
            menuOptionCounter++;
        }
        if (!firstRun)
            AddMenuOption(new Option("Exit to Main Menu", "0"));
        ShowMenu();
        var r = Convert.ToInt32(Prompt(checkEnabled: true));
        var options = GetMenuOptions();
        if (r != 0)
            Program.SelectedHabit = options[r - 1].Description;
    }
    public static void GetHabit()
    {
        Menu tempMenu = new();
        Database db = new();
        var menuOptionCounter = 1;
        foreach (var result in db.GetLogCategories())
        {
            var item = Convert.ToString(result);
            if (item == "sqlite_sequence") continue;
            if (item != null) tempMenu.AddMenuOption(new Option(item.ToUpper(), menuOptionCounter.ToString()));
            menuOptionCounter++;
        }
        tempMenu.ShowMenu();
        var r = Convert.ToInt32(tempMenu.Prompt(checkEnabled: true));
        var options = tempMenu.GetMenuOptions();
        Program.SelectedHabit = options[r - 1].Description;
    }
}