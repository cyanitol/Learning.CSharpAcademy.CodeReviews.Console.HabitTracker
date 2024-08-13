using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuReport : Menu {

        public MenuReport(){
            AddMenuOption(new MenuReport.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            AddMenuOption(new MenuReport.Option("Exit to Main Menu", "0"));
        }
}
}