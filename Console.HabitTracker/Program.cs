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