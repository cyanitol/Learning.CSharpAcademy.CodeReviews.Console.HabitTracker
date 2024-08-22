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

namespace Console.HabitTracker;

public struct HabitLogLine
{
    public string Id { get; init; }
    public string Date { get; init; }
    public string Quantity { get; init; }
}

public static class Program
{
    private const string AppName = "Habit Tracker";
    internal static string? SelectedHabit;
    internal static string? MenuSelection;

    private static void Main(string[] args)
    {
        System.Console.SetWindowSize(80, 400);

        {
            Database db = new();
            var y = db.GetLogCategories().Count;
            if (db.GetLogCategories().Count == 0)
            MenuAddHabit.AddDemoHabit();
        }

        _ = new MenuSelectHabit($"{AppName} :: Select Habit", firstRun: true);
        while (true)
        {
            var mainMenu = new MenuMain($"{AppName}");
            mainMenu.ShowMenu(footerContent: [$"Selected Habit: {SelectedHabit}"]);
            MenuSelection = mainMenu.Prompt(checkEnabled: true);

            switch (MenuSelection)
            {
                case "1":
                    _ = new MenuLogHabit($"{AppName} :: Log Habit");
                    break;
                case "2":
                    _ = new MenuViewLog($"{AppName} :: View Log");
                    break;
                case "3":
                    _ = new MenuReport($"{AppName} :: Reports");
                    break;
                case "4":
                    _ = new MenuAddHabit($"{AppName} :: Add Habit");
                    break;
                case "5":
                    SwitchHabit();
                    break;
                case "9":
                    _ = new MenuSettings($"{AppName} :: Settings");
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private static void SwitchHabit()
    {
        _ = new MenuSelectHabit($"{AppName} :: Select Habit");
    }
}