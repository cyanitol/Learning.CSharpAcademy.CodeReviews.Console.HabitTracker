using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuViewLog : Menu {

        public MenuViewLog(){
            AddMenuOption(new Menu.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));
        }
}
}