using System;
using PA5;

//MAIN---------------------
Menu_SubMenus_RouteEm(); //Has all menus and sub menus, routes them at the same time...gotta love switch statements








//END MAIN------------------

//FRAMEWORK METHODS--------------------

static void Menu_SubMenus_RouteEm() {
    while (true) {
        DisplayMainMenu(); //displays the main menu

        string choice = Console.ReadLine(); //reads in choice for menu

        switch (choice)
        {
            case "1": //Choice 1 - operator menus / methods
                OperatorPath();
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

static void DisplayMainMenu() { //Shows the main menu to the user
    Console.Clear();
    Console.WriteLine("Main Menu:");
    Console.WriteLine("1. Operator");
    Console.WriteLine("2. Customer");
    Console.WriteLine("3. Exit");
    Console.Write("\nEnter your choice: ");
}

static void DisplayOperatorMenu() { //Shows the operator menu to user
    Console.Clear();
    Console.WriteLine("Operator Menu:");
    Console.WriteLine("1. Manage Trainer Data");
    Console.WriteLine("2. Manage Listing Data");
    Console.WriteLine("3. Manage Customer Booking Data");
    Console.WriteLine("4. Run Reports");
    Console.WriteLine("5. Back to main menu");

    Console.Write("\nEnter your choice: ");
}

static void OperatorPath() { //OPERATOR MENU AND METHODS----------------
    while (true) {
        DisplayOperatorMenu(); //displays answer choices for the operator menu

        string subChoice = Console.ReadLine(); //reads in sub-menu choice

        switch (subChoice)
        {
            case "1":
                // Do something for Sub-option 1
                Console.WriteLine("Manage Trainer Data selected");
                Console.ReadKey();
                break;
            case "2":
                // Do something for Sub-option 2
                Console.WriteLine("Manage Listing Data selected");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Manage custome booking data selected");
                Console.ReadKey();
                break;
            case "4":
                Console.WriteLine("run reports selected");
                Console.ReadKey();
                break;
            case "5":
                // Go back to Main Menu
                break;
            default:
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                break;
        }

        if (subChoice == "5")
            break;
    }
}