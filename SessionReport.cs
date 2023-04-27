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
            }
            else {
                Console.Clear();
                Console.WriteLine($"Reports for {customerName}:\n");
                for(int i = 0; i < Session.GetCount(); i++) {
                    if(sessions[i].GetCustomerEmail() == inputEmail) {
                        Console.WriteLine(sessions[i].ToString());
                    }
                }
            }

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