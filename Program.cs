﻿using System;
using PA5;

//MAIN---------------------
Trainer[] trainers = new Trainer[100];
TrainerUtility utility = new TrainerUtility(trainers);
TrainerReport report = new TrainerReport(trainers);

//utility.GetAllTrainersFromFile();
Menu_SubMenus_RouteEm(trainers, utility, report); 






//END MAIN------------------

//FRAMEWORK METHODS--------------------

static void Menu_SubMenus_RouteEm(Trainer[] trainers, TrainerUtility utility, TrainerReport report) {
    while (true) {
        DisplayMainMenu(); //displays the main menu

        string choice = Console.ReadLine(); //reads in choice for menu

        switch (choice)
        {
            case "1": //Choice 1 - operator menus / methods
                OperatorPath(trainers, utility, report);
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

static void DisplayMainMenu() { //Shows the MAIN menu to the user
    Console.Clear();
    Console.WriteLine("Main Menu:");
    Console.WriteLine("1. Operator");
    Console.WriteLine("2. Customer");
    Console.WriteLine("3. Exit");
    Console.Write("\nEnter your choice: ");
}

static void DisplayOperatorMenu() { //Shows the OPERATOR menu to user
    Console.Clear();
    Console.WriteLine("Operator Menu:");
    Console.WriteLine("1. Manage Trainer Data");
    Console.WriteLine("2. Manage Listing Data");
    Console.WriteLine("3. Manage Customer Booking Data");
    Console.WriteLine("4. Run Reports");
    Console.WriteLine("5. Back to main menu");

    Console.Write("\nEnter your choice: ");
}

static void OperatorPath(Trainer[] trainers, TrainerUtility utility, TrainerReport report) { //OPERATOR MENU AND METHODS----------------
    while (true) {
        DisplayOperatorMenu(); //displays answer choices for the operator menu

        string choice = Console.ReadLine(); //reads in sub-menu choice

        switch (choice)
        {
            case "1":
                // Do something for Sub-option 1
                //Console.WriteLine("Manage Trainer Data selected");
                ManageTrainerData(trainers, utility, report);
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

        if (choice == "5")
            break;
    }
}

static void ManageTrainerData(Trainer[] trainers, TrainerUtility utility, TrainerReport report) {
    while (true) {
        Console.Clear();
        Console.WriteLine("Would you like to ADD, EDIT, or DELETE any trainer data? (Enter corresponding number)");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Edit");
        Console.WriteLine("3. Delete");
        Console.WriteLine("4. View Data");
        Console.WriteLine("5. Back to Operator Menu");

        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                // Do something for Sub-option 1
                //Console.WriteLine("Sub-option 1 selected");
                // Console.Clear();
                utility.GetAllTrainersFromFile();//maybe can comment out
                utility.AddTrainer();
                Console.ReadKey();
                break;
            case "2":
                // Do something for Sub-option 2
                //Console.WriteLine("Sub-option 2 selected");
                Console.Clear();
                utility.GetAllTrainersFromFile();
                utility.updateTrainer();
                //Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Sub-option 3 selected");
                Console.ReadKey();
                break;    
            case "4":
                //Console.WriteLine("Sub-option 4 selected");
                Console.Clear();
                Console.WriteLine("Trainer Data:\n");
                utility.GetAllTrainersFromFile();
                report.PrintAllTrainers();
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

        if (choice == "5")
            break;
    }
}