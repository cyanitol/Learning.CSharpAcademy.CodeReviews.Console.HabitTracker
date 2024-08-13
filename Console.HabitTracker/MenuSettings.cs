using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuSettings : Menu{

        public MenuSettings(){
            AddMenuOption(new MenuSettings.Option("Modify Habit", "1"));
            AddMenuOption(new MenuSettings.Option("Clear Database", "2"));
            AddMenuOption(new MenuSettings.Option("Add Demo Data to Database", "3"));
            AddMenuOption(new MenuSettings.Option("Backup Database", "4"));
            AddMenuOption(new MenuSettings.Option("Export Database", "5"));
            AddMenuOption(new MenuSettings.Option("Database Config", "6"));
            AddMenuOption(new MenuSettings.Option("Exit to Main Menu", "0"));
        }

    }
}