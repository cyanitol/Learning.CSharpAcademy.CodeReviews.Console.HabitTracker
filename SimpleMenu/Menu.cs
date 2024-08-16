// Simple Menu Library
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

using System.Text;

namespace SimpleMenu
{
    public class Menu(string title = "Application Title")
    {
        public struct Option(string description, string selector)
        {
            public readonly string Description = description;
            public readonly string Selector = selector;
        }

        private List<Option> _options = [];

        private static readonly int ConsoleWidth = Console.WindowWidth;
        private readonly int _totalPaddingLength = (ConsoleWidth / 2) + (title.Length / 2);
        private const string MenuBorder = "|";
        private const int InsideMarginWidth = 2;
        private const int OutsideMarginWidth = 2;
        private readonly string _outsideMargin = new string(' ', OutsideMarginWidth);
        private readonly string _insideMargin = new string(' ', InsideMarginWidth);
        private readonly int _selectorDescriptionMargin = 5;

        public void AddMenuOption(Option menuOption)
        {
            _options.Add(menuOption);
        }

        public void ClearMenuOptions()
        {
            foreach (Option option in _options){
                _options.Remove(option);
            }
        }

        public void ShowMenu(bool clear = true, string optionDelimiter = "",
        List<string>? footerContent = null)
        {
            if (clear)
                Console.Clear();

            var menuTitle = new StringBuilder();
            menuTitle.AppendFormat($"{_outsideMargin}");
            menuTitle.AppendFormat($"".PadLeft(_totalPaddingLength - OutsideMarginWidth, '='));
            menuTitle.AppendFormat($"\n");
            menuTitle.AppendFormat($"{_outsideMargin}");
            menuTitle.AppendFormat($"{title}".PadLeft(ConsoleWidth - menuTitle.Length).ToUpper());
            menuTitle.AppendFormat($"\n");
            menuTitle.AppendFormat($"{_outsideMargin}");
            menuTitle.AppendFormat($"".PadLeft(_totalPaddingLength - OutsideMarginWidth, '='));
            menuTitle.AppendFormat($"\n");
            Console.Write(menuTitle);

            foreach (var option in _options)
            {
                var menuLine = new StringBuilder();
                menuLine.AppendFormat($"{_outsideMargin}");
                menuLine.AppendFormat(MenuBorder);
                menuLine.AppendFormat($"{_insideMargin}");
                menuLine.AppendFormat($"{option.Selector}{optionDelimiter}");
                menuLine.AppendFormat(new string(' ', _selectorDescriptionMargin -
                    option.Selector.Length - optionDelimiter.Length));
                menuLine.AppendFormat($"{option.Description}");
                menuLine.AppendFormat($"".PadLeft(_totalPaddingLength - menuLine.Length - 1));
                menuLine.AppendFormat(MenuBorder);
                menuLine.AppendFormat($"{_outsideMargin}");
                menuLine.AppendFormat("\n");
                Console.Write(menuLine);

            }
            ShowFooter(footerContent ?? []);
        }

        private void ShowFooter(string content = "")
        {
            var footer = new StringBuilder();
            footer.AppendFormat($"{_outsideMargin}");
            footer.AppendFormat($"".PadLeft(_totalPaddingLength - OutsideMarginWidth, '-'));
            footer.AppendFormat($"{_outsideMargin}");
            footer.AppendFormat($"\n");
            footer.AppendFormat($"{_outsideMargin}{_insideMargin}{content}{_outsideMargin}\n");
            footer.AppendFormat($"{_outsideMargin}");
            footer.AppendFormat("".PadRight(_totalPaddingLength - OutsideMarginWidth, '-'));
            Console.WriteLine(footer.ToString());
        }

        private void ShowFooter(List<string> content)
        {
            var footer = new StringBuilder();
            footer.AppendFormat($"{_outsideMargin}");
            footer.AppendFormat($"".PadLeft(_totalPaddingLength - OutsideMarginWidth, '-'));
            footer.AppendFormat($"{_outsideMargin}");
            footer.AppendFormat($"\n");
            foreach (string item in content)
            {
                footer.AppendFormat($"{_outsideMargin}{_insideMargin}{item}{_outsideMargin}\n");
            }
            footer.AppendFormat($"{_outsideMargin}");
            footer.AppendFormat("".PadRight(_totalPaddingLength - OutsideMarginWidth, '-'));
            Console.WriteLine(footer.ToString());
        }

        public string? Prompt(string promptText = "Enter Selection:", bool checkEnabled = false)
        {
            string? input = null;
            var prompt = new StringBuilder();
            prompt.AppendFormat($"{_outsideMargin}{_insideMargin}");
            prompt.AppendFormat(promptText);

            if (checkEnabled)
            {
                while (!CheckInput(input ??= "no input"))
                {
                    Console.Write($"{prompt}".ToUpper());
                    input = Console.ReadLine();
                }
            }
            else
            {
                Console.Write($"{prompt}".ToUpper());
                input = Console.ReadLine();
            }

            return input?.ToLower();
        }

        public List<Option> GetMenuOptions()
        {
            return _options;
        }
        private bool CheckInput(string? input)
        {
            return input != null && _options.Any(option => option.Selector == input);
        }
    }
}