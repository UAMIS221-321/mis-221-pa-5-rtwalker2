using System.Text;
namespace PA5
{
    public class SessionReport
    {
        Session[] sessions;

        public SessionReport(Session[] sessions) {
            this.sessions = sessions;
        }

        public void PrintAllSessions() {
            for(int i = 0; i < Session.GetCount(); i++) {
                Console.WriteLine($"{sessions[i].ToString()}");
            }
        }

        public void PrintAllSessionsToFile(string txtFile) {
            StreamWriter outFile = new StreamWriter(txtFile, true);
            outFile.WriteLine("Customer report by customer->date:\n");
            for(int i = 0; i < Session.GetCount(); i++) {
                outFile.WriteLine($"{sessions[i].ToString()}");   
            }       
            outFile.WriteLine("\n---------------------------------------------------------------\n");
            outFile.Close();     
        }

        public void PrintIndividualSessionReport() {
            string inputEmail;
            string customerName = "n/a";
            bool isEmailThere = false;
            Console.Write("Enter an email address to see associated reports: ");
            inputEmail = Console.ReadLine();

            for(int i = 0; i < Session.GetCount(); i++) {
                if(sessions[i].GetCustomerEmail() == inputEmail) {
                    isEmailThere = true;
                    customerName = sessions[i].GetCustomerName();
                    break;
                }
            }

            if(isEmailThere == false) {
                Console.WriteLine($"Sorry no information available for \"{inputEmail}\"");
                Console.ReadKey();
            }
            else {
                Console.Clear();
                StringBuilder report = new StringBuilder($"Sessions for {customerName}:\n\n");

                Console.WriteLine($"Sessions for {customerName}:\n");
                for(int i = 0; i < Session.GetCount(); i++) {
                    if(sessions[i].GetCustomerEmail() == inputEmail) {
                        report.Append(sessions[i].ToString());
                        Console.WriteLine(sessions[i].ToString());
                    }
                }
                
                while(true) {
                    Console.WriteLine("\nWould you like to save this report? (y/n)");
                    string choice = Console.ReadLine();
                    switch (choice.ToLower()) 
                    {
                        case "y":
                            SaveReport(report);
                            return;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Please enter 'y' for yes or 'n' for no");
                            Console.ReadKey();
                            break;
                    }
                    if(choice == "n") break;
                }

            }

        }

        public bool yesNo() {
                while(true) {
                    Console.WriteLine("\nWould you like to save this report? (y/n)");
                    string choice = Console.ReadLine();
                    switch (choice.ToLower()) 
                    {
                        case "y":
                            return true;
                        case "n":
                            return false;
                        default:
                            Console.WriteLine("Please enter 'y' for yes or 'n' for no");
                            Console.ReadKey();
                            break;
                    }
                }
        }

        public void SaveReport(StringBuilder report) {
            StreamWriter outFile = new StreamWriter("reports.txt", true);

            outFile.WriteLine(report);
            outFile.WriteLine("\n---------------------------------------------------------------\n");



            outFile.Close();
        }

        public void SortByCustomer_Date() {
            for(int i = 0; i < Session.GetCount() - 1; i++) {
                int min = i;
                for(int j = i+1; j < Session.GetCount(); j++) {
                    if(sessions[j].GetCustomerName().CompareTo(sessions[min].GetCustomerName()) < 0 || (sessions[j].GetCustomerName() == sessions[min].GetCustomerName() && sessions[j].GetTrainingDate().CompareTo(sessions[min].GetTrainingDate()) < 0)) {
                        min = j;
                    }
                }
                if(min != i) {
                    Swap(min, i);
                }
            }
        }

        private void Swap(int x, int y) {
            Session temp = sessions[x];
            sessions[x] = sessions[y];
            sessions[y] = temp;
        }



    }
}