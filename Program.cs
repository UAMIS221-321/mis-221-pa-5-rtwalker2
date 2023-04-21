using System;

//MAIN---------------------
OperatorCustomerMenu_Route();


//END MAIN------------------



//FRAMEWORK METHODS--------------------

static void OperatorCustomerMenu_Route() {
    Console.Clear();
    Console.WriteLine("Hello! Please select whether you are an operator or a customer below:\n\nType the corresponding number to choose:\n\n1. Operator\n2. Customer\n3. Exit");
    int userChoice = 0;

    while(userChoice != 3) {
        try {
            userChoice = int.Parse(Console.ReadLine());
            if(userChoice < 1 || userChoice > 3) {
                throw new Exception("Please enter a valid menu choice!");
            }
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            userChoice = 0;
        }
        finally {
            if(userChoice == 1) {
                Console.WriteLine("This is the operator experience");
            }
            else if(userChoice == 2) {
                Console.WriteLine("This is the customer experience");
            }
        }
    }
}

// static int GetUserChoice() {
    
//     string userChoice = Console.ReadLine();
//     if (IsValidChoice(userChoice)) {
//         return int.Parse(userChoice);
//     }
//     else return 0;
// }