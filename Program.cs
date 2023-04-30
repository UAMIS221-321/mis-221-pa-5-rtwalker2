using System;
using PA5;
using System.Text;

//MAIN---------------------
Trainer[] trainers = new Trainer[500];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
TrainerReport trainerReport = new TrainerReport(trainers);

Listing[] listings = new Listing[500];
ListingUtility listingUtility = new ListingUtility(listings);
ListingReport listingReport = new ListingReport(listings);

Session[] sessions = new Session[500];
SessionUtility sessionUtility = new SessionUtility(sessions);
SessionReport sessionReport = new SessionReport(sessions);


while (true) {
    DisplayMainMenu(); //displays the main menu

    string choice = Console.ReadLine(); //reads in choice for menu

    switch (choice)
    {
        case "1": //Choice 1 - operator menus / methods - PASSWORD IS mis221 <------<------<------<------<------|
            Console.Clear();
            Console.WriteLine("Please enter the password:");
            string passwordAnswer = Console.ReadLine();
            if(passwordAnswer == "mis221") //password
            {
            OperatorPath(trainers, trainerUtility, trainerReport, listings, listingUtility, listingReport, sessions, sessionUtility, sessionReport);
            }
            else {
                Console.Clear();
                Console.WriteLine("Incorrect!");
                Console.ReadKey();
            }
            break;
        case "2": //choice 2
            CustomerPath(trainers, trainerUtility, trainerReport, listings, listingUtility, listingReport, sessions, sessionUtility, sessionReport);
            break;
        case "3": //choice 3, exit
            return;
        default:
            Console.WriteLine("Invalid choice");
            Console.ReadKey();
            break;
    }
}
//END MAIN----------------

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
    Console.WriteLine("1. Manage Trainer Data"); //basics completed
    Console.WriteLine("2. Manage Listing Data"); //basics completed
    Console.WriteLine("3. Manage Customer Booking Data"); //basics completed
    Console.WriteLine("4. Run Reports"); //working on...
    Console.WriteLine("5. Back to Main Menu");

    Console.Write("\nEnter your choice: ");
}
//customer path shows what the customer can see and options for them to interact
static void CustomerPath(Trainer[] trainers, TrainerUtility trainerUtility, TrainerReport trainerReport, Listing[] listings, ListingUtility listingUtility, ListingReport listingReport, Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport) {
                while (true) {
                    Console.Clear();
                    Console.WriteLine("Customer Menu:");
                    Console.WriteLine("1. View Available Sessions");
                    Console.WriteLine("2. Book a Session");
                    Console.WriteLine("3. Change Booking status");
                    Console.WriteLine("4. View Your Bookings");
                    Console.WriteLine("5. Back to Main Menu");

                    Console.Write("\nEnter your choice: ");
                    string subChoice = Console.ReadLine();

                    switch (subChoice)
                    {
                        case "1":
                            Console.Clear();//view available sessions that can be booked
                            ViewSessions(sessions, sessionUtility, sessionReport, listings, listingUtility, listingReport);
                            break;
                        case "2":
                            Console.Clear();//book a session
                            CustomerBookSession(sessions, sessionUtility, sessionReport, listings, listingUtility, trainers, trainerUtility);
                            break;
                        case "3":
                            Console.Clear();//change a booking's status
                            sessionUtility.GetAllSessionsFromFile();
                            sessionUtility.UpdateSession(listings, listingUtility, trainers, trainerUtility, sessions, sessionUtility);
                            break;
                        case "4":
                            Console.Clear();//view bookings
                            sessionUtility.GetAllSessionsFromFile();
                            sessionReport.PrintIndividualSessionReportNoSave();
                            Console.ReadKey();
                            break;
                        case "5":
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

static void OperatorPath(Trainer[] trainers, TrainerUtility trainerUtility, TrainerReport trainerReport, Listing[] listings, ListingUtility listingUtility, ListingReport listingReport, Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport) { //OPERATOR MENU AND METHODS----------------
    while (true) {
        DisplayOperatorMenu(); //displays answer choices for the operator menu

        string choice = Console.ReadLine(); //reads in sub-menu choice

        switch (choice)
        {
            case "1":
                ManageTrainerData(trainers, trainerUtility, trainerReport, listings, listingUtility, sessions, sessionUtility);
                break;
            case "2":
                ManageListingData(listings, listingUtility, listingReport, trainers, trainerUtility, sessions, sessionUtility);
                break;
            case "3":
                ManageBookingData(sessions, sessionUtility, sessionReport, listings, listingUtility, listingReport, trainers, trainerUtility);
                break;
            case "4":
                ViewReports(trainers, trainerUtility, trainerReport, listings, listingUtility, listingReport, sessions, sessionUtility, sessionReport);
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

static void ManageTrainerData(Trainer[] trainers, TrainerUtility trainerUtility, TrainerReport trainerReport, Listing[] listings1, ListingUtility listingUtility1, Session[] sessions1, SessionUtility sessionUtility1) {
    while (true) {
        Console.Clear();
        Console.WriteLine("Would you like to ADD, EDIT, DELETE, or VIEW any trainer data? (Enter corresponding number)");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Edit");
        Console.WriteLine("3. Delete");
        Console.WriteLine("4. View Data");
        Console.WriteLine("5. Back to Operator Menu");

        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1"://ADD TRAINER
                Console.Clear();
                trainerUtility.GetAllTrainersFromFile();
                trainerUtility.AddTrainer();
                break;
            case "2"://EDIT TRAINER
                Console.Clear();
                trainerUtility.GetAllTrainersFromFile();
                trainerUtility.UpdateTrainer(listings1, listingUtility1, sessions1, sessionUtility1, trainers, trainerUtility);
                break;
            case "3"://DELETE TRAINER
                Console.Clear();
                trainerUtility.GetAllTrainersFromFile();
                trainerUtility.DeleteTrainer();
                break;    
            case "4"://VIEW TRAINER DATA LIST
                Console.Clear();
                Console.WriteLine("Trainer Data:\n");
                trainerUtility.GetAllTrainersFromFile();
                trainerReport.PrintAllTrainers();
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

static void ManageListingData(Listing[] listings, ListingUtility listingUtility, ListingReport listingReport, Trainer[] trainers, TrainerUtility trainerUtility, Session[] sessions, SessionUtility sessionUtility) {
    while (true) {
        Console.Clear();
        Console.WriteLine("Would you like to ADD, EDIT, DELETE, or VIEW any listing data? (Enter corresponding number)");
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
                Console.Clear();//add listing
                listingUtility.GetAllListingsFromFile();
                listingUtility.AddListing(trainers, trainerUtility);
                Console.ReadKey();
                break;
            case "2":
                Console.Clear();//edit listing
                listingUtility.GetAllListingsFromFile();
                listingUtility.UpdateListing(trainers, trainerUtility, sessions, sessionUtility, listings, listingUtility);
                break;
            case "3":
                Console.Clear();//delete listing
                listingUtility.GetAllListingsFromFile();
                listingUtility.DeleteListing();
                break;    
            case "4"://VIEW TRAINER DATA LIST
                Console.Clear();
                Console.WriteLine("Listing Data:\n");
                listingUtility.GetAllListingsFromFile();
                listingReport.PrintAllListings();
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

static void ManageBookingData(Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport, Listing[] listings, ListingUtility listingUtility, ListingReport listingReport, Trainer[] trainers, TrainerUtility trainerUtility) {
    while (true) {
        Console.Clear();
        Console.WriteLine("Would you like to view available sessions or book a session? (Enter corresponding number)");
        Console.WriteLine("1. View available training sessions");
        Console.WriteLine("2. Book a session");
        Console.WriteLine("3. Back to Operator Menu");

        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Clear(); //view available sessions
                ViewSessions(sessions, sessionUtility, sessionReport, listings, listingUtility, listingReport);
                break;
            case "2"://BOOK A SESSION
                Console.Clear();
                BookSession(sessions, sessionUtility, sessionReport, listings, listingUtility, trainers, trainerUtility);
                break;            
            case "3":
                // Go back to Main Menu
                break;
            default:
                Console.WriteLine("Invalid choice");
                Console.ReadKey();
                break;
        }

        if (choice == "3")
            break;
    }
}

static void ViewSessions(Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport, Listing[] listings, ListingUtility listingUtility, ListingReport listingReport) {
    listingUtility.GetAllListingsFromFile();
    Console.WriteLine("Available Sessions: \n");
    listingReport.PrintAvailableListings();
    Console.ReadKey();
}

//shows a customer appropriate view of sessions
static void CustomerBookSession(Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport, Listing[] listings, ListingUtility listingUtility, Trainer[] trainers, TrainerUtility trainerUtility) {
    sessionUtility.GetAllSessionsFromFile();
    sessionUtility.AddSession(listings, listingUtility, trainers, trainerUtility);
}

//book a session
static void BookSession(Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport, Listing[] listings, ListingUtility listingUtility, Trainer[] trainers, TrainerUtility trainerUtility) {
    while (true) {
        Console.Clear();
        Console.WriteLine("Would you like to ADD, EDIT, DELETE, or VIEW any session data? (Enter corresponding number)");
        Console.WriteLine("1. Book a session (ADD)");
        Console.WriteLine("2. EDIT a session's booking status");
        Console.WriteLine("3. DELETE a session");
        Console.WriteLine("4. View Data");
        Console.WriteLine("5. Back to Booking Menu");

        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1"://ADD SESSION
                Console.Clear();
                sessionUtility.GetAllSessionsFromFile();
                sessionUtility.AddSession(listings, listingUtility, trainers, trainerUtility);
                break;
            case "2"://EDIT SESSION - only does booking status, other info is sensative to change / unnecessary plus really only need to change booking status
                Console.Clear();
                sessionUtility.GetAllSessionsFromFile();
                sessionUtility.UpdateSession(listings, listingUtility, trainers, trainerUtility, sessions, sessionUtility);
                break;
            case "3"://DELETE SESSION
                Console.Clear();
                sessionUtility.GetAllSessionsFromFile();
                sessionUtility.DeleteSession(listings, listingUtility);
                break;    
            case "4"://VIEW DATA LIST
                Console.Clear();
                Console.WriteLine("Session Data:\n");
                sessionUtility.GetAllSessionsFromFile();
                sessionReport.PrintAllSessions();
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

static void ViewReports(Trainer[] trainers, TrainerUtility trainerUtility, TrainerReport trainerReport, Listing[] listings, ListingUtility listingUtility, ListingReport listingReport, Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport) {
    while (true) {
            Console.Clear();
            Console.WriteLine("Report Menu:");
            Console.WriteLine("1. Individual Customer Report");
            Console.WriteLine("2. Customer Report By Customer-Date");
            Console.WriteLine("3. Revenue Report");
            Console.WriteLine("4. Back to Operator Menu");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    sessionUtility.GetAllSessionsFromFile();
                    sessionReport.PrintIndividualSessionReport();
                    //Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    sessionUtility.GetAllSessionsFromFile();
                    sessionReport.SortByCustomer_Date();
                    sessionReport.PrintAllSessions();
                    if(sessionReport.yesNo()) {
                        sessionReport.PrintAllSessionsToFile("reports.txt");
                    }
                    //Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    listingReport.PrintRevenueReport(sessions, sessionUtility, sessionReport, listings, listingUtility);
                    //Console.ReadKey();
                    break;    
                case "4":
                    break;             
                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    break;
            }

            if (choice == "4")
                break;
        }
}