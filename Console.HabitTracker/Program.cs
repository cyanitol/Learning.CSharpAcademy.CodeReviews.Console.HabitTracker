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
    internal class Program
    {
        internal static readonly string AppName = "Habit Tracker (Console)";
        internal static MenuMain MainMenu = new MenuMain();

        private static void Main(string[] args)
        {
            while (true)
            {
                MainMenu.ShowMenu();
                var s = MainMenu.Prompt(checkEnabled: true);

                switch (s)
                {
                    case "1":
                        var logHabitMenu = new MenuLogHabit();
                        logHabitMenu.ShowMenu();
                        DoOperation(logHabitMenu.Prompt(checkEnabled:true));
                        break;
                    case "2":
                        var viewLogMenu = new MenuViewLog();
                        viewLogMenu.ShowMenu();
                        DoOperation(viewLogMenu.Prompt(checkEnabled:true));
                        break;
                    case "3":
                        var reportMenu = new MenuReport();
                        reportMenu.ShowMenu();
                        DoOperation(reportMenu.Prompt(checkEnabled:true));
                        break;
                    case "4":
                        var habit = MainMenu.Prompt("Enter New Habit Name:");
                        var db = new Database();
                        if (habit != null) db.CreateLogCategory(habit);
                        if (habit == null) continue;
                        break;
                    case "9":
                        var settingsMenu = new MenuSettings();
                        settingsMenu.ShowMenu();
                        DoOperation(settingsMenu.Prompt(checkEnabled:true));
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }

                void DoOperation(string x)
                {
                    System.Console.Clear();
                    System.Console.WriteLine($"Operation {x} Performed");
                    System.Console.ReadLine();
                }
            }
        }

    }
}