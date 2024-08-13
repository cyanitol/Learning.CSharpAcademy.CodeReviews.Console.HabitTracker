using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuNewHabit : Menu {

        public MenuNewHabit(){
            AddMenuOption(new MenuNewHabit.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            AddMenuOption(new MenuNewHabit.Option("Exit to Main Menu", "0"));
        }
}
}