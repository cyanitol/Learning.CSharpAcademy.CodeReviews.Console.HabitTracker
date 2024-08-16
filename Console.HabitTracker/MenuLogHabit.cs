using SimpleMenu;

namespace Console.HabitTracker
{
    internal class MenuLogHabit : Menu
    {

        public MenuLogHabit(string title = "Application name") : base(title)
        {
            AddMenuOption(new MenuLogHabit.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            AddMenuOption(new MenuLogHabit.Option("Exit to Main Menu", "0"));
            ShowMenu();
            Program.menuSelection = Prompt(checkEnabled: true);
        }
    }
}