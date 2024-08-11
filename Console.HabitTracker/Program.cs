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

Menu mainMenu = new("Habit Tracker (Console)");

mainMenu.AddMenuOption(new Menu.Option("Test Menu","1"));
mainMenu.AddMenuOption(new Menu.Option("Test Menu 2","2"));
mainMenu.AddMenuOption(new Menu.Option("Test Menu 3","3"));
mainMenu.AddMenuOption(new Menu.Option("Lorem ipsum","3"));
mainMenu.AddMenuOption(new Menu.Option("Exit","0"));

while (true)
{
    mainMenu.ShowMenu();
    var s = mainMenu.Prompt(checkEnabled:true);

    switch (s)
    {
        case "0":
            Environment.Exit(0);
            break;
    }
}