using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuViewLog : Menu {

        public MenuViewLog(string title = "Application Title") : base(title)
        {
            AddMenuOption(new Menu.Option("View Log", "1"));
            AddMenuOption(new Menu.Option("Search Log", "2"));
            AddMenuOption(new Menu.Option("Export Log", "3"));
            AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));
            ShowMenu();
            Prompt(checkEnabled: true);
        }
    }
}