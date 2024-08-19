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

using SimpleMenu;

namespace Console.HabitTracker
{
    public struct HabitLogLine
    {
        public string id { get; set; }
        public string date { get; set; }
        public string quantity { get; set; }
    }

    public class Program
    {
        internal static readonly string AppName = "Habit Tracker";
        internal static string? selectedHabit;
        internal static string? menuSelection;

        private static void Main(string[] args)
        {
            System.Console.SetWindowSize(100,400);

            var SelectHabitMenu = new MenuSelectHabit($"{Program.AppName} :: Select Habit", firstRun: true);
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
                        var AddHabitMenu = new MenuAddHabit($"{Program.AppName} :: Add Habit");
                        break;
                    case "5":
                        switchHabit();
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

        private static void switchHabit()
        {
            var SelectHabitMenu = new MenuSelectHabit($"{Program.AppName} :: Select Habit");
        }
    }
}