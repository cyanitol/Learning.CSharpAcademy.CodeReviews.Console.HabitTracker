using SimpleMenu;
using Microsoft.Data.Sqlite;

namespace Console.HabitTracker
{
    internal class MenuSelectHabit : Menu
    {
        public MenuSelectHabit(string title = "Application Title", bool firstRun = false) : base(title)
        {
            Init(firstRun);
        }
        private void Init(bool firstRun=false){
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
            Program.selectedHabit = _options[r-1].Description;
        }
        public static void GetHabit(){
            Menu tempMenu = new();
            Database db = new();
            int menuOptionCounter = 1;
            foreach (object result in db.GetLogCategories())
            {
                var item = Convert.ToString(result);
                if (item != "sqlite_sequence"){
                tempMenu.AddMenuOption(new Option(item.ToUpper(), menuOptionCounter.ToString()));
                menuOptionCounter++;
                }
            }
            tempMenu.ShowMenu();
            var r = Convert.ToInt32(tempMenu.Prompt(checkEnabled:true));
            var _options = tempMenu.GetMenuOptions();
            Program.selectedHabit = _options[r-1].Description;
        }
    }
}