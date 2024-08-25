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
                break;
            case "2":
                _ = new MenuAddHabit();
                break;
            case "3":
                DeleteHabit();
                var db = new Database();
                if (db.GetLogCategories().Count == 0)
                    MenuAddHabit.AddDemoHabit();
                _ = new MenuSelectHabit($"{Program.AppName} :: Select Habit", firstRun:true);
                break;
            case "4":
                DeleteHabit(allHabits: true);
                MenuAddHabit.AddDemoHabit();
                _ = new MenuSelectHabit($"{Program.AppName} :: Select Habit", firstRun:true);
                break;
        }
    }

    private static void DeleteHabit(bool allHabits = false)
    {      
        if (allHabits)
        {
            var db = new Database();
            foreach (var habit in db.GetLogCategories())
            {
                if (habit.ToString() == "sqlite_sequence")
                    continue;
                else
                    db.DeleteLogCategory(habit.ToString());
            }
        }
        else
        {
            var db = new Database();
            _ = new MenuSelectHabit($"{Program.AppName} :: Delete Habit", firstRun: true);
            db.DeleteLogCategory(Program.SelectedHabit);
        }
    }
}