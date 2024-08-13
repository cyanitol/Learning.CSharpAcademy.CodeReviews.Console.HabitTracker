using SimpleMenu;

namespace Console.HabitTracker{
    internal class MenuNewHabit : Menu {

        public MenuNewHabit(){
            AddMenuOption(new MenuNewHabit.Option("Create New Habit", "1"));
            AddMenuOption(new MenuNewHabit.Option("Create New Habits", "2"));
            AddMenuOption(new MenuNewHabit.Option("Exit to Main Menu", "0"));
        }
}
}