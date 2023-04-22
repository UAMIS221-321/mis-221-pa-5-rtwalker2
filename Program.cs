using System;

//MAIN---------------------
Menu_SubMenus_RouteEm(); //Has all menus and sub menus, routes them at the same time...gotta love switch statements








//END MAIN------------------



//FRAMEWORK METHODS--------------------

static void Menu_SubMenus_RouteEm() {
    while (true) {
        Console.Clear();
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Operator");
        Console.WriteLine("2. Customer");
        Console.WriteLine("3. Exit");

        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": //Choice 1
                while (true) {
                    Console.Clear();
                    Console.WriteLine("Option 1 Menu:");
                    Console.WriteLine("1. Sub-option 1");
                    Console.WriteLine("2. Sub-option 2");
                    Console.WriteLine("3. Back to Main Menu");

                    Console.Write("\nEnter your choice: ");
                    string subChoice = Console.ReadLine();

                    switch (subChoice)
                    {
                        case "1":
                            // Do something for Sub-option 1
                            Console.WriteLine("Sub-option 1 selected");
                            Console.ReadKey();
                            break;
                        case "2":
                            // Do something for Sub-option 2
                            Console.WriteLine("Sub-option 2 selected");
                            Console.ReadKey();
                            break;
                        case "3":
                            // Go back to Main Menu
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            Console.ReadKey();
                            break;
                    }

                    if (subChoice == "3")
                        break;
                }
                break;
            case "2": //choice 2
                while (true) {
                    Console.Clear();
                    Console.WriteLine("Option 2 Menu:");
                    Console.WriteLine("1. Sub-option 1");
                    Console.WriteLine("2. Sub-option 2");
                    Console.WriteLine("3. Back to Main Menu");

                    Console.Write("\nEnter your choice: ");
                    string subChoice = Console.ReadLine();

                    switch (subChoice)
                    {
                        case "1":
                            // Do something for Sub-option 1
                            Console.WriteLine("Sub-option 1 selected");
                            Console.ReadKey();
                            break;
                        case "2":
                            // Do something for Sub-option 2
                            Console.WriteLine("Sub-option 2 selected");
                            Console.ReadKey();
                            break;
                        case "3":
                            // Go back to Main Menu
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            Console.ReadKey();
                            break;
                    }

                    if (subChoice == "3")
                        break;
                }
                break;
            case "3": //choice 3, exit
                return;
            default:
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                break;
        }
    }
}