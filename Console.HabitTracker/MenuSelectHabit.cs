using SimpleMenu;

namespace Console.HabitTracker
{
    internal class MenuSelectHabit : Menu
    {
        public MenuSelectHabit(string title = "Application Title", bool firstRun = false) : base(title)
        {
            Database db = new();
            int menuOptionCounter = 1;
            foreach (object result in db.GetLogCategories())
            {
                var item = Convert.ToString(result);
                if (item != "sqlite_sequence"){
                AddMenuOption(new Option(item.ToUpper(), menuOptionCounter.ToString()));
                menuOptionCounter++;
                }
            }
            if (!firstRun)
                AddMenuOption(new MenuSettings.Option("Exit to Main Menu", "0"));
            ShowMenu();
            var r = Convert.ToInt32(Prompt(checkEnabled:true));
            var _options = GetMenuOptions();
            Program.selectedHabit = _options[r].Description;
        }
    }
}