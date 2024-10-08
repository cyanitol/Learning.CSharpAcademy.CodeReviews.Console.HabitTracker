using SimpleMenu;

namespace Console.HabitTracker;

internal class MenuAddHabit : Menu
{

    public MenuAddHabit(string title = "Application Title") : base(title)
    {
        Menu tempMenu = new();
        var habit = tempMenu.Prompt("Enter New Habit Name:");
        var db = new Database();
        if (habit != null) db.CreateLogCategory(habit);
        _ = new MenuSelectHabit();
    }

    public static void AddDemoHabit(){
        var db = new Database();
        db.CreateLogCategory("Demo");
    }
}