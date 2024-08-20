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

namespace SimpleMenu;

public class Menu(string title = "Application Title")
{
    public struct Option(string description, string selector)
    {
        public readonly string Description = description;
        public readonly string Selector = selector;
    }

    private List<Option> _options = [];

    private static readonly int ConsoleWidth = Console.WindowWidth;
    private readonly int _totalPaddingLength = (ConsoleWidth + title.Length) / 2;
    private const string MenuBorder = "|";
    private const int InsideMarginWidth = 2;
    private const int OutsideMarginWidth = 2;
    private readonly string _outsideMargin = new(' ', OutsideMarginWidth);
    private readonly string _insideMargin = new(' ', InsideMarginWidth);
    private const int SelectorDescriptionMargin = 5;

    public void AddMenuOption(Option menuOption)
    {
        _options.Add(menuOption);
    }

    public void ClearMenuOptions()
    {
        foreach (var option in _options.ToList())
        {
            _options.Remove(option);
        }
    }
    public void ShowMenu(bool clear = true, string optionDelimiter = "", List<string>? footerContent = null)
    {
        if (clear)
            Console.Clear();

        var menuTitle = new StringBuilder();

        // Calculate left padding for centering the title
        int titleLength = title.Length;
        int leftPadding = (ConsoleWidth - titleLength) / 2;

        // Top border
        menuTitle.AppendFormat($"{_outsideMargin}");
        menuTitle.AppendFormat("".PadLeft(ConsoleWidth - OutsideMarginWidth - 2, '='));  // Subtract 2 to reduce the number of '='
        menuTitle.AppendFormat("\n");

        // Title line
        menuTitle.AppendFormat($"{_outsideMargin}");
        menuTitle.AppendFormat("".PadLeft(leftPadding, ' '));
        menuTitle.AppendFormat($"{title.ToUpper()}");
        menuTitle.AppendFormat("".PadRight(ConsoleWidth - leftPadding - titleLength - OutsideMarginWidth, ' '));
        menuTitle.AppendFormat("\n");

        // Bottom border
        menuTitle.AppendFormat($"{_outsideMargin}");
        menuTitle.AppendFormat("".PadLeft(ConsoleWidth - OutsideMarginWidth - 2, '='));  // Subtract 2 to reduce the number of '='
        menuTitle.AppendFormat("\n");

        Console.Write(menuTitle);

        foreach (var option in _options)
        {
            var menuLine = new StringBuilder();
            menuLine.AppendFormat($"{_outsideMargin}");
            menuLine.AppendFormat(MenuBorder);
            menuLine.AppendFormat($"{_insideMargin}");
            menuLine.AppendFormat($"{option.Selector}{optionDelimiter}");
            menuLine.AppendFormat(new string(' ', SelectorDescriptionMargin - option.Selector.Length - optionDelimiter.Length));
            menuLine.AppendFormat($"{option.Description}");

            // Calculate right padding to align the ending '|'
            int optionLineLength = menuLine.Length;
            int rightPadding = ConsoleWidth - optionLineLength - OutsideMarginWidth - 1;

            menuLine.AppendFormat("".PadRight(rightPadding));
            menuLine.AppendFormat(MenuBorder);
            menuLine.AppendFormat($"{_outsideMargin}");
            menuLine.AppendFormat("\n");

            Console.Write(menuLine);
        }
        ShowFooter(footerContent ?? new List<string>());
    }

    private void ShowFooter(string content = "", bool centered = false)
    {
        var footer = new StringBuilder();
        int footerPaddingLength = ConsoleWidth - (OutsideMarginWidth * 2);

        // Top footer border
        footer.AppendFormat($"{_outsideMargin}");
        footer.AppendFormat("".PadLeft(footerPaddingLength, '-'));
        footer.AppendFormat($"{_outsideMargin}\n");

        // Content line, left-justified or centered based on the flag
        if (!string.IsNullOrEmpty(content))
        {
            if (centered)
            {
                int contentPadding = (footerPaddingLength - content.Length) / 2;
                footer.AppendFormat($"{_outsideMargin}");
                footer.AppendFormat("".PadLeft(contentPadding, ' '));
                footer.AppendFormat(new string(' ',InsideMarginWidth));
                footer.AppendFormat(content);
                footer.AppendFormat("".PadRight(footerPaddingLength - contentPadding - content.Length, ' '));
                footer.AppendFormat($"{_outsideMargin}\n");
            }
            else
            {
                footer.AppendFormat($"{_outsideMargin}");
                footer.AppendFormat(new string(' ',InsideMarginWidth));
                footer.AppendFormat(content);
                footer.AppendFormat("".PadRight(footerPaddingLength - content.Length, ' '));
                footer.AppendFormat($"{_outsideMargin}\n");
            }
        }

        // Bottom footer border
        footer.AppendFormat($"{_outsideMargin}");
        footer.AppendFormat("".PadRight(footerPaddingLength, '-'));
        footer.AppendFormat($"{_outsideMargin}");

        Console.WriteLine(footer.ToString());
    }

    private void ShowFooter(List<string> content, bool centered = false)
    {
        var footer = new StringBuilder();
        int footerPaddingLength = ConsoleWidth - (OutsideMarginWidth * 2);

        // Top footer border
        footer.AppendFormat($"{_outsideMargin}");
        footer.AppendFormat("".PadLeft(footerPaddingLength, '-'));
        footer.AppendFormat($"{_outsideMargin}\n");

        // Multiple content lines, left-justified or centered based on the flag
        foreach (var item in content)
        {
            if (centered)
            {
                int contentPadding = (footerPaddingLength - item.Length) / 2;
                footer.AppendFormat($"{_outsideMargin}");
                footer.AppendFormat("".PadLeft(contentPadding, ' '));
                footer.AppendFormat(new string(' ',InsideMarginWidth));
                footer.AppendFormat(item);
                footer.AppendFormat("".PadRight(footerPaddingLength - contentPadding - item.Length, ' '));
                footer.AppendFormat($"{_outsideMargin}\n");
            }
            else
            {
                footer.AppendFormat($"{_outsideMargin}");
                footer.AppendFormat(new string(' ',InsideMarginWidth));
                footer.AppendFormat(item);
                footer.AppendFormat("".PadRight(footerPaddingLength - item.Length, ' '));
                footer.AppendFormat($"{_outsideMargin}\n");
            }
        }

        // Bottom footer border
        footer.AppendFormat($"{_outsideMargin}");
        footer.AppendFormat("".PadRight(footerPaddingLength, '-'));
        footer.AppendFormat($"{_outsideMargin}");

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