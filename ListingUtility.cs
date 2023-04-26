using System.Globalization;
namespace PA5
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings) {
            this.listings = listings;
        }

        public void GetAllListingsFromFile() {
            //open
            StreamReader inFile = new StreamReader("listings.txt");

            //process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]);
                Listing.IncrementCount();
                line = inFile.ReadLine();
            } 

            //close
            inFile.Close();
        }

        public void AddListing() {

            Console.WriteLine("Enter a Listing ID: ");
            Listing myListing = new Listing();
            myListing.SetListingID(Console.ReadLine());

            Console.WriteLine("Enter a trainer name: ");
            myListing.SetTrainerName(Console.ReadLine());

            DateTime date;
            bool validDate = false;
            while (!validDate) {
                Console.WriteLine("Please enter a date in MM/DD/YYYY format: ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
                    //Console.WriteLine("Valid date: " + date.ToShortDateString());
                    myListing.SetDateOfSession(date.ToShortDateString());
                    validDate = true;
                } else {
                    Console.WriteLine("Invalid date, please try again.");
                }
            }
            // Console.WriteLine("Enter the date of the session: ");
            // myListing.SetDateOfSession(Console.ReadLine());

            DateTime time;
            bool validTime = false;

            while (!validTime) {
                Console.WriteLine("Please enter a time for the session in HH:mm format (24hr clock, 1-24 for HH and 0-59 for mm): ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out time)) {
                    //Console.WriteLine("Valid time: " + time.ToString("hh:mm tt"));
                    myListing.SetTimeOfSession(time.ToString("hh:mm tt"));
                    validTime = true;
                } else {
                    Console.WriteLine("Invalid time, Use HH:MM format (13:15 = 1:15 PM, 04:40 = 4:40am).");
                }
            }

            // Console.WriteLine("Enter the time of the session: ");
            // myListing.SetTimeOfSession(Console.ReadLine());

            int num;
            bool validNum = false;

            while (!validNum) {
                Console.Write("Enter the cost of the session ($): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out num) && num > 0) {
                    myListing.SetCostOfSession(num.ToString());
                    validNum = true;
                } else {
                    Console.WriteLine("Invalid input, please enter a whole number greater than 0.");
                }
            }

            // Console.WriteLine("Enter the cost of the session: ");
            // myListing.SetCostOfSession(Console.ReadLine());

            string input2;
            bool validAnswer = false;
            while (!validAnswer) {
                Console.Write("Enter if the listing has been taken 'yes' or 'no': ");
                input2 = Console.ReadLine();

                if (input2.ToLower() == "yes" || input2.ToLower() == "no") {
                    myListing.SetIsListingTaken(input2.ToLower());
                    validAnswer = true;
                } else {
                    Console.WriteLine("Invalid input, please enter 'yes' or 'no'.");
                }
            }

            // Console.WriteLine("Enter if the listing has been taken or not (yes/no)");
            // myListing.SetIsListingTaken(Console.ReadLine());

            listings[Listing.GetCount()] = myListing;
            Listing.IncrementCount();
            Save();
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++) {
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }

        public int Find(string searchVal) { // searches using LISTING ID
            for(int i = 0; i < Listing.GetCount(); i++) {
                if(listings[i].GetListingID().ToLower() == searchVal.ToLower()) {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateListing() {
            Console.WriteLine("Enter the \"listing ID\" to update a listing's info: ");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1) {
                Console.Clear();
                Console.WriteLine("Enter a new listing ID: ");
                listings[foundIndex].SetListingID(Console.ReadLine());
                Console.WriteLine("Enter a new trainer name: ");
                listings[foundIndex].SetTrainerName(Console.ReadLine());

            DateTime date;
            bool validDate = false;
            while (!validDate) {
                Console.WriteLine("Please enter a date in MM/DD/YYYY format: ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
                    //Console.WriteLine("Valid date: " + date.ToShortDateString());
                    listings[foundIndex].SetDateOfSession(date.ToShortDateString());
                    validDate = true;
                } else {
                    Console.WriteLine("Invalid date, please try again.");
                }
            }

            DateTime time;
            bool validTime = false;

            while (!validTime) {
                Console.WriteLine("Please enter a time for the session in HH:mm format (24hr clock, 1-24 for HH and 0-59 for mm): ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out time)) {
                    //Console.WriteLine("Valid time: " + time.ToString("hh:mm tt"));
                    listings[foundIndex].SetTimeOfSession(time.ToString("hh:mm tt"));
                    validTime = true;
                } else {
                    Console.WriteLine("Invalid time, Use HH:MM format (13:15 = 1:15 PM, 04:40 = 4:40am).");
                }
            }

            int num;
            bool validNum = false;

            while (!validNum) {
                Console.Write("Enter the cost of the session ($): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out num) && num > 0) {
                    listings[foundIndex].SetCostOfSession(num.ToString());
                    validNum = true;
                } else {
                    Console.WriteLine("Invalid input, please enter a whole number greater than 0.");
                }
            }

            string input2;
            bool validAnswer = false;
            while (!validAnswer) {
                Console.Write("Enter if the listing has been taken 'yes' or 'no': ");
                input2 = Console.ReadLine();

                if (input2.ToLower() == "yes" || input2.ToLower() == "no") {
                    listings[foundIndex].SetIsListingTaken(input2.ToLower());
                    validAnswer = true;
                } else {
                    Console.WriteLine("Invalid input, please enter 'yes' or 'no'.");
                }
            }

                // Console.WriteLine("Enter the date of the session: ");
                // listings[foundIndex].SetDateOfSession(Console.ReadLine());
                // Console.WriteLine("Enter the time of the session: ");
                // listings[foundIndex].SetTimeOfSession(Console.ReadLine());
                // Console.WriteLine("Enter the cost of the session: ");
                // listings[foundIndex].SetCostOfSession(Console.ReadLine());
                // Console.WriteLine("Enter if the listing has been taken or not (yes/no)");
                // listings[foundIndex].SetIsListingTaken(Console.ReadLine());


                Save();
            }
            else {
                Console.Clear();
                Console.WriteLine("Listing not found!");
                Console.ReadKey();
            }
        }

        public void DeleteListing() {
            Console.WriteLine("Enter the \"Listing ID\" to be deleted (enter \"cancel\" to cancel): ");
            string searchVal = Console.ReadLine();
            if(searchVal.ToUpper() == "CANCEL") {
                return;
            }
            else {
            int foundIndex = Find(searchVal);
            string[] lines = File.ReadAllLines("listings.txt");

            if(foundIndex != -1) {
                if(foundIndex >= 0 && foundIndex < lines.Length) {
                    lines[foundIndex] = null;//set line to null then below, remove null
                    lines = lines.Where(x => x != null).ToArray();//.where() as used returns all elements in sequence that isn't null... to array converts back to array.
                }
                File.WriteAllLines("listings.txt", lines);
                Console.Clear(); 
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