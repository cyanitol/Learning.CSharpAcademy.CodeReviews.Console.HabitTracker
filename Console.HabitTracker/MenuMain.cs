using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuMain : Menu {

        public MenuMain(){
            AddMenuOption(new Option("Log Habit", "1"));
            AddMenuOption(new Option("View Log", "2"));
            AddMenuOption(new Option("Reports", "3"));
            AddMenuOption(new Option("New Habit", "4"));
            AddMenuOption(new Option("Settings", "9"));
            AddMenuOption(new Option("Exit", "0"));
            ShowMenu();
        }
}
}