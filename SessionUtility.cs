using System.Globalization;
namespace PA5
{
    public class SessionUtility
    {

        private Session[] sessions;
        // private Listing[] listings1 = new Listing[500];
        // private ListingUtility listingUtility1;
        // private ListingReport listingReport1;

        public SessionUtility(Session[] sessions) {
            this.sessions = sessions;
        }

        public void GetAllSessionsFromFile() {
            //open
            StreamReader inFile = new StreamReader("transactions.txt");

            //process
            Session.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) {
                string[] temp = line.Split('#');
                sessions[Session.GetCount()] = new Session(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6]);
                Session.IncrementCount();
                line = inFile.ReadLine();
            } 

            //close
            inFile.Close();
        }

        public void AddSession(Listing[] listings1, ListingUtility listingUtility1, Trainer[] trainers1, TrainerUtility trainerUtility1) {
            Session mySession = new Session();
            string sessionID = "";
            int index = -1;

            listingUtility1.GetAllListingsFromFile();

            while(true) {
                Console.WriteLine("Enter a Session ID (or 'cancel' to cancel): ");
                sessionID = Console.ReadLine();
                if(sessionID.ToLower() == "cancel") {
                    return;
                }
                for(int i = 0; i < Listing.GetCount(); i++) {
                    if(listings1[i].GetIsListingTaken() == "yes" && (listings1[i].GetListingID() == sessionID)) {
                        // Console.Clear();
                        Console.WriteLine("Listing is already taken!");
                        break;
                    }
                    else {
                    
                        if(listings1[i].GetListingID() == sessionID) {
                            index = i;
                            break;
                        }
                        else {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid session ID!\nMust be exact same as available session ID\n\n");
                        }
                    }
                }
                if(index != -1) break;
            }
            mySession.SetSessionID(listings1[index].GetListingID());
            listings1[listingUtility1.Find(sessionID)].SetIsListingTaken("yes");

            Console.WriteLine("Enter a customer name: ");
            mySession.SetCustomerName(Console.ReadLine());

            Console.WriteLine("Enter a customer email: ");
            mySession.SetCustomerEmail(Console.ReadLine());

            // DateTime date;
            // bool validDate = false;
            // while (!validDate) {
            //     Console.WriteLine("Please enter a training date in MM/DD/YYYY format: ");
            //     string input = Console.ReadLine();

            //     if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
            //         //Console.WriteLine("Valid date: " + date.ToShortDateString());
            //         mySession.SetTrainingDate(date.ToShortDateString());
            //         validDate = true;
            //     } else {
            //         Console.WriteLine("Invalid date, please try again.");
            //     }
            // }
            mySession.SetTrainingDate(listings1[index].GetDateOfSession());

            // Console.WriteLine("Enter trainer ID: ");
            // mySession.SetTrainerID(Console.ReadLine());
            // Console.WriteLine("Enter trainer name: ");
            // mySession.SetTrainerName(Console.ReadLine());
            mySession.SetTrainerID(listings1[index].GetTrainerID());
            mySession.SetTrainerName(listings1[index].GetTrainerName());
            // string trainerID = "";
            // int index2 = -1;
            // trainerUtility1.GetAllTrainersFromFile();
            // while(true) {
            //     Console.WriteLine("Enter a Trainer ID (or 'cancel' to cancel): ");
            //     trainerID = Console.ReadLine();
            //     if(trainerID.ToLower() == "cancel") {
            //         return;
            //     }
            //     for(int i = 0; i < Trainer.GetCount(); i++) {
            //         if(trainers1[i].GetTrainerID() == trainerID) {
            //             index2 = i;
            //             break;
            //         }
            //         else {
            //             Console.Clear();
            //             Console.WriteLine("Please enter a valid trainer ID!\nMust be exact same as available trainer IDs\n\n");
            //         }
            //     }
            //     if(index2 != -1) break;
            // }
            // mySession.SetTrainerID(trainers1[index2].GetTrainerID());


            // //Console.WriteLine("Enter a trainer name: ");
            // mySession.SetTrainerName(trainers1[index2].GetTrainerName());

            mySession.SetSessionStatus("booked");
            // string input2;
            // bool validAnswer = false;
            // while (!validAnswer) {
            //     Console.Write("Enter if the session has been 'booked', 'completed', or 'canceled'");
            //     input2 = Console.ReadLine();

            //     if (input2.ToLower() == "booked" || input2.ToLower() == "completed" || input2.ToLower() == "canceled") {
            //         mySession.SetSessionStatus(input2.ToLower());
            //         validAnswer = true;
            //     } else {
            //         Console.WriteLine("Invalid input, please enter 'booked', 'completed', or 'canceled'.");
            //     }
            // }

            sessions[Session.GetCount()] = mySession;
            Session.IncrementCount();
            listingUtility1.PublicSave();
            Save();
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Session.GetCount(); i++) {
                outFile.WriteLine(sessions[i].ToFile());
            }

            outFile.Close();
        }

        public void PublicSave(int index) {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Session.GetCount(); i++) {
                outFile.WriteLine(sessions[index].ToFile());
            }

            outFile.Close();      
        }

        public void PublicSave() {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Session.GetCount(); i++) {
                outFile.WriteLine(sessions[i].ToFile());
            }

            outFile.Close();      
        }

        public int Find(string searchVal) { // searches using LISTING ID
            for(int i = 0; i < Session.GetCount(); i++) {
                if(sessions[i].GetSessionID().ToLower() == searchVal.ToLower()) {
                    return i;
                }
            }
            return -1;
        }

        public int FindTrainerID(string searchVal) {
            for(int i = 0; i < Session.GetCount(); i++) {
            if(sessions[i].GetTrainerID().ToLower() == searchVal.ToLower()) {
                return i;
            }
            }
            return -1;
        }

        public void UpdateSession(Listing[] listings1, ListingUtility listingUtility1, Trainer[] trainers1, TrainerUtility trainerUtility1) {
            Console.WriteLine("Enter the \"Session ID\" to update a sessions's info: ");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);
            

            if(foundIndex != -1) {
                Console.Clear();
                // Console.WriteLine("Enter a Session ID: ");
                // sessions[foundIndex].SetSessionID(Console.ReadLine());

                // string sessionID = "";
                // int index = -1;

                // listingUtility1.GetAllListingsFromFile();
                // while(true) {
                //     Console.WriteLine("Enter a new Session ID (or 'cancel' to cancel): ");
                //     sessionID = Console.ReadLine();
                //     if(sessionID.ToLower() == "cancel") {
                //         return;
                //     }
                //     for(int i = 0; i < Listing.GetCount(); i++) {
                //         if(listings1[i].GetListingID() == sessionID) {
                //             index = i;
                //             break;
                //         }
                //         else {
                //             Console.Clear();
                //             Console.WriteLine("Please enter a valid session ID!\nMust be exact same as available session ID\n\n");
                //         }
                //     }
                //     if(index != -1) break;
                // }
                // sessions[foundIndex].SetSessionID(listings1[index].GetListingID());

                // Console.WriteLine("Enter a customer name: ");
                // sessions[foundIndex].SetCustomerName(Console.ReadLine());

                // Console.WriteLine("Enter a customer email: ");
                // sessions[foundIndex].SetCustomerEmail(Console.ReadLine());

                // // DateTime date;
                // // bool validDate = false;
                // // while (!validDate) {
                // //     Console.WriteLine("Please enter a training date in MM/DD/YYYY format: ");
                // //     string input = Console.ReadLine();

                // //     if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
                // //         //Console.WriteLine("Valid date: " + date.ToShortDateString());
                // //         sessions[foundIndex].SetTrainingDate(date.ToShortDateString());
                // //         validDate = true;
                // //     } else {
                // //         Console.WriteLine("Invalid date, please try again.");
                // //     }
                // // }
                // sessions[foundIndex].SetTrainingDate(listings1[index].GetDateOfSession());

                // // Console.WriteLine("Enter trainer ID: ");
                // // sessions[foundIndex].SetTrainerID(Console.ReadLine());
                // // Console.WriteLine("Enter trainer name: ");
                // // sessions[foundIndex].SetTrainerName(Console.ReadLine());
                // sessions[foundIndex].SetTrainerID(listings1[index].GetTrainerID());
                // sessions[foundIndex].SetTrainerName(listings1[index].GetTrainerName());
                // // string trainerID = "";
                // // int index2 = -1;
                // // trainerUtility1.GetAllTrainersFromFile();
                // // while(true) {
                // //     Console.WriteLine("Enter a Trainer ID (or 'cancel' to cancel): ");
                // //     trainerID = Console.ReadLine();
                // //     if(trainerID.ToLower() == "cancel") {
                // //         return;
                // //     }
                // //     for(int i = 0; i < Trainer.GetCount(); i++) {
                // //         if(trainers1[i].GetTrainerID() == trainerID) {
                // //             index2 = i;
                // //             break;
                // //         }
                // //         else {
                // //             Console.Clear();
                // //             Console.WriteLine("Please enter a valid trainer ID!\nMust be exact same as available trainer IDs\n\n");
                // //         }
                // //     }
                // //     if(index2 != -1) break;
                // // }
                // // sessions[foundIndex].SetTrainerID(trainers1[index2].GetTrainerID());


                // // //Console.WriteLine("Enter a trainer name: ");
                // // sessions[foundIndex].SetTrainerName(trainers1[index2].GetTrainerName());


                string input2;
                bool validAnswer = false;
                listingUtility1.GetAllListingsFromFile();
                int listingIndex = listingUtility1.FindListingID(searchVal);

                while (!validAnswer) {
                    Console.WriteLine("Enter if the session has been 'booked', 'completed', or 'canceled'");
                    input2 = Console.ReadLine();

                    if (input2.ToLower() == "booked" || input2.ToLower() == "completed" || input2.ToLower() == "canceled") {
                        sessions[foundIndex].SetSessionStatus(input2.ToLower());
                        if(input2.ToLower() == "booked" || input2.ToLower() == "completed") {
                            listings1[listingIndex].SetIsListingTaken("yes");
                        }
                        else  {
                            listings1[listingIndex].SetIsListingTaken("no");
                        }
                        listingUtility1.PublicSave();
                        validAnswer = true;
                    } else {
                        Console.WriteLine("Invalid input, please enter 'booked', 'completed', or 'canceled'.");
                    }
                }     

                    Save();
            }//end of over arching IF statement
            else {
                Console.Clear();
                Console.WriteLine("Listing not found!");
                Console.ReadKey();
            }
        }
//---------------------
            // while(true) {
            //     Console.WriteLine("Enter a Session ID (or 'cancel' to cancel): ");
            //     sessionID = Console.ReadLine();
            //     if(sessionID.ToLower() == "cancel") {
            //         return;
            //     }
            //     for(int i = 0; i < Listing.GetCount(); i++) {
            //         if(listings1[i].GetIsListingTaken() == "yes") {
            //             Console.Clear();
            //             Console.WriteLine("Listing is already taken!");
            //             break;
            //         }
            //         else {
                    
            //             if(listings1[i].GetListingID() == sessionID) {
            //                 index = i;
            //                 break;
            //             }
            //             else {
            //                 Console.Clear();
            //                 Console.WriteLine("Please enter a valid session ID!\nMust be exact same as available session ID\n\n");
            //             }
            //         }
            //     }
            //     if(index != -1) break;
            // }
//----------------------------
        public void DeleteSession(Listing[] listings, ListingUtility listingUtility) {
            Console.WriteLine("Enter the \"Session ID\" to be deleted (enter \"cancel\" to cancel): ");
            string searchVal = Console.ReadLine();
            
            if(searchVal.ToUpper() == "CANCEL") {
                return;
            }
            else {
                int foundIndex = Find(searchVal);
                string[] lines = File.ReadAllLines("transactions.txt");

                if(foundIndex != -1) {
                    if(foundIndex >= 0 && foundIndex < lines.Length) {
                        lines[foundIndex] = null;//set line to null then below, remove null
                        lines = lines.Where(x => x != null).ToArray();//.where() as used returns all elements in sequence that isn't null... to array converts back to array.
                    }
                    File.WriteAllLines("transactions.txt", lines);
                    Console.Clear(); 
                    //---
                    listingUtility.GetAllListingsFromFile();
                    listings[listingUtility.Find(searchVal)].SetIsListingTaken("no");
                    listingUtility.PublicSave();
                    //---
                    Console.WriteLine("Listing deleted");
                    Console.ReadKey();
                }
                else {
                    Console.Clear();
                    Console.WriteLine("Listing not found!");
                    Console.ReadKey();
                }
            }
            
        } 

    



    }
}