using System.Data.Common;
using SimpleMenu;

namespace Console.HabitTracker
{
    internal class MenuLogHabit : Menu
    {

        public MenuLogHabit(string title = "Application name") : base(title)
        {
            AddMenuOption(new MenuLogHabit.Option("Log Now", "1"));
            AddMenuOption(new MenuLogHabit.Option("Log Previous", "2"));
            AddMenuOption(new MenuLogHabit.Option("Exit to Main Menu", "0"));
            ShowMenu();
            DoSelection(Prompt(checkEnabled: true));
        }

        private void DoSelection(string s){
            switch (s){
                case "1":
                LogHabit();
                break;
                case "2":
                LogHabit(now: false);
                break;
            }
        }

        private void LogHabit(bool now = true){
            var db = new Database();
            var date = new DateOnly();

            if (now){
                date = DateOnly.FromDateTime(DateTime.Now);
            }
            else{
                Menu tempMenu = new();
                try
                {
                    var r = tempMenu.Prompt("Please enter the date (yyyy-mm-dd)");
                    date = DateOnly.Parse(r);
                }
                catch (System.Exception)
                {
                    var r = tempMenu.Prompt("Please enter the date (yyyy-mm-dd)");
                    date = DateOnly.Parse(r);
                    throw;
                }
                
            }
                
            db.AddLogItem(Program.selectedHabit, date, 1);
        }
    }
}