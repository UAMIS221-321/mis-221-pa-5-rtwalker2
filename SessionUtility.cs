using System.Globalization;
namespace PA5
{
    public class SessionUtility
    {

        private Session[] sessions;

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

        public void AddSession() {

            Console.WriteLine("Enter a Session ID: ");
            Session mySession = new Session();
            mySession.SetSessionID(Console.ReadLine());

            Console.WriteLine("Enter a customer name: ");
            mySession.SetCustomerName(Console.ReadLine());

            Console.WriteLine("Enter a customer email: ");
            mySession.SetCustomerEmail(Console.ReadLine());

            DateTime date;
            bool validDate = false;
            while (!validDate) {
                Console.WriteLine("Please enter a training date in MM/DD/YYYY format: ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
                    //Console.WriteLine("Valid date: " + date.ToShortDateString());
                    mySession.SetTrainingDate(date.ToShortDateString());
                    validDate = true;
                } else {
                    Console.WriteLine("Invalid date, please try again.");
                }
            }

            Console.WriteLine("Enter trainer ID: ");
            mySession.SetTrainerID(Console.ReadLine());

            Console.WriteLine("Enter trainer name: ");
            mySession.SetTrainerName(Console.ReadLine());

            string input2;
            bool validAnswer = false;
            while (!validAnswer) {
                Console.Write("Enter if the session has been 'booked', 'completed', or 'canceled'");
                input2 = Console.ReadLine();

                if (input2.ToLower() == "booked" || input2.ToLower() == "completed" || input2.ToLower() == "canceled") {
                    mySession.SetSessionStatus(input2.ToLower());
                    validAnswer = true;
                } else {
                    Console.WriteLine("Invalid input, please enter 'booked', 'completed', or 'canceled'.");
                }
            }

            sessions[Session.GetCount()] = mySession;
            Session.IncrementCount();
            Save();
        }

        private void Save() {
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

        public void UpdateSession() {
            Console.WriteLine("Enter the \"listing ID\" to update a listing's info: ");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1) {
                Console.Clear();
                Console.WriteLine("Enter a Session ID: ");
                sessions[foundIndex].SetSessionID(Console.ReadLine());

                Console.WriteLine("Enter a customer name: ");
                sessions[foundIndex].SetCustomerName(Console.ReadLine());

                Console.WriteLine("Enter a customer email: ");
                sessions[foundIndex].SetCustomerEmail(Console.ReadLine());

                DateTime date;
                bool validDate = false;
                while (!validDate) {
                    Console.WriteLine("Please enter a training date in MM/DD/YYYY format: ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) {
                        //Console.WriteLine("Valid date: " + date.ToShortDateString());
                        sessions[foundIndex].SetTrainingDate(date.ToShortDateString());
                        validDate = true;
                    } else {
                        Console.WriteLine("Invalid date, please try again.");
                    }
                }

                Console.WriteLine("Enter trainer ID: ");
                sessions[foundIndex].SetTrainerID(Console.ReadLine());

                Console.WriteLine("Enter trainer name: ");
                sessions[foundIndex].SetTrainerName(Console.ReadLine());

                string input2;
                bool validAnswer = false;
                while (!validAnswer) {
                    Console.WriteLine("Enter if the session has been 'booked', 'completed', or 'canceled'");
                    input2 = Console.ReadLine();

                    if (input2.ToLower() == "booked" || input2.ToLower() == "completed" || input2.ToLower() == "canceled") {
                        sessions[foundIndex].SetSessionStatus(input2.ToLower());
                        validAnswer = true;
                    } else {
                        Console.WriteLine("Invalid input, please enter 'booked', 'completed', or 'canceled'.");
                    }
                }     


                    Save();
            }
            else {
                Console.Clear();
                Console.WriteLine("Listing not found!");
                Console.ReadKey();
            }
        }

        public void DeleteSession() {
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