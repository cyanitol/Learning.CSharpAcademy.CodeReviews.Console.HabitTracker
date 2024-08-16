﻿// Console Habit Tracker
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

using SimpleMenu;

namespace Console.HabitTracker
{
    internal class Program
    {
        internal static readonly string AppName = "Habit Tracker";
        internal static string? selectedHabit;
        internal static string? menuSelection;

        private static void Main(string[] args)
        {
            var initialMenu = new MenuSelectHabit($"{Program.AppName} :: Select Habit",firstRun: true);
            while (true)
            {
                var MainMenu = new MenuMain($"{AppName}");
                MainMenu.ShowMenu(footerContent: [$"Selected Habit: {Program.selectedHabit}"]);
                menuSelection = MainMenu.Prompt(checkEnabled: true);

                switch (menuSelection)
                {
                    case "1":
                        var logHabitMenu = new MenuLogHabit($"{Program.AppName} :: Log Habit");
                        break;
                    case "2":
                        var viewLogMenu = new MenuViewLog($"{Program.AppName} :: View Log");
                        break;
                    case "3":
                        var reportMenu = new MenuReport($"{Program.AppName} :: Reports");
                        break;
                    case "4":
                        var habit = MainMenu.Prompt("Enter New Habit Name:");
                        var db = new Database();
                        if (habit != null) db.CreateLogCategory(habit);
                        if (habit == null) continue;
                        break;
                    case "8":
                        var _ = new MenuSelectHabit($"{Program.AppName} :: Select Habit");
                        break;
                    case "9":
                        var settingsMenu = new MenuSettings($"{Program.AppName} :: Settings");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

    }
}