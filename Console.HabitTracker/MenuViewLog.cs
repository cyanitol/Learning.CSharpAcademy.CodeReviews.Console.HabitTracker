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
            var r = Prompt(checkEnabled: true);
            switch (r)
            {
                case "1":
                    MenuViewLog.ViewLog(Program.selectedHabit);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "0":
                    break;
            }
        }
        public static void ViewLog(string habit){
            Database db = new();
            var r = db.GetLogItems(habit);
            foreach(var i in r){
            System.Console.WriteLine(i);
            }
            System.Console.ReadLine();
        }
    }
}