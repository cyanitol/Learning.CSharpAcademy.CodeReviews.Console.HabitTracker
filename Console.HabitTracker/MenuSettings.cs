using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuSettings : Menu{

        public MenuSettings(){
            AddMenuOption(new MenuSettings.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            AddMenuOption(new MenuSettings.Option("Exit to Main Menu", "0"));
        }

    }
}