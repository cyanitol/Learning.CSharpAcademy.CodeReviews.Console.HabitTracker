// Console Habit Tracker
// Copyright (C) 2024 JMWeeks
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public
// License along with this program. If not, see 
// <https://www.gnu.org/licenses/>.
// 
// Contact information:
// Email: license@jmweeks.com

namespace Console.HabitTracker
{
    using SimpleMenu;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var AppName = "Habit Tracker (Console)";
            Menu MenuMain = new($"{AppName}");
            Menu MenuLogHabit = new($"{AppName} :: Log Habit");
            Menu MenuViewLog = new($"{AppName} :: View Log");
            Menu MenuReports = new($"{AppName} :: Reports");
            Menu MenuNewHabit = new($"{AppName} :: New Habit");
            Menu MenuSettings = new($"{AppName} :: Settings");

            MenuMain.AddMenuOption(new Menu.Option("Log Habit", "1"));
            MenuMain.AddMenuOption(new Menu.Option("View Log", "2"));
            MenuMain.AddMenuOption(new Menu.Option("Reports", "3"));
            MenuMain.AddMenuOption(new Menu.Option("New Habit", "4"));
            MenuMain.AddMenuOption(new Menu.Option("Settings", "9"));
            MenuMain.AddMenuOption(new Menu.Option("Exit", "0"));
            
            MenuLogHabit.AddMenuOption(new Menu.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            MenuLogHabit.AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));
            
            MenuViewLog.AddMenuOption(new Menu.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            MenuViewLog.AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));
            
            MenuReports.AddMenuOption(new Menu.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            MenuReports.AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));
            
            MenuNewHabit.AddMenuOption(new Menu.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            MenuNewHabit.AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));
            
            MenuSettings.AddMenuOption(new Menu.Option("Lorem Ipsum Dolor Sit Amet", "1"));
            MenuSettings.AddMenuOption(new Menu.Option("Exit to Main Menu", "0"));

            while (true)
            {
                MenuMain.ShowMenu();
                var s = MenuMain.Prompt(checkEnabled: true);

                switch (s)
                {
                    case "1":
                        MenuLogHabit.ShowMenu();
                        MenuLogHabit.Prompt(checkEnabled: true);
                        break;
                    case "2":
                        MenuViewLog.ShowMenu();
                        MenuViewLog.Prompt(checkEnabled: true);
                        break;
                    case "3":
                        MenuReports.ShowMenu();
                        MenuReports.Prompt(checkEnabled: true);
                        break;
                    case "4":
                        MenuNewHabit.ShowMenu();
                        MenuNewHabit.Prompt(checkEnabled: true);
                        break;
                    case "9":
                        MenuSettings.ShowMenu();
                        MenuSettings.Prompt(checkEnabled: true);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}