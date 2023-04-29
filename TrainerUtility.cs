namespace PA5
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers) {
            this.trainers = trainers;
        }

        public void GetAllTrainersFromFile() {
            //open
            StreamReader inFile = new StreamReader("trainers.txt");

            //process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null) {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(temp[0], temp[1], temp[2], temp[3]);
                Trainer.IncrementCount();
                line = inFile.ReadLine();
            } 

            //close
            inFile.Close();
        }

        public void AddTrainer() {
            Console.WriteLine("Enter a trainer ID: ");
            Trainer myTrainer = new Trainer();
            myTrainer.SetTrainerID(Console.ReadLine());
            Console.WriteLine("Enter a name: ");
            myTrainer.SetTrainerName(Console.ReadLine());
            Console.WriteLine("Enter a mailing address: ");
            myTrainer.SetMailingAddress(Console.ReadLine());
            Console.WriteLine("Enter a email address: ");
            myTrainer.SetTrainerEmailAddress(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncrementCount();
            Save();
        }

        private void Save() {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++) {
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        public int Find(string searchVal) { // searches using TRAINER ID
            for(int i = 0; i < Trainer.GetCount(); i++) {
                if(trainers[i].GetTrainerID().ToLower() == searchVal.ToLower()) {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateListing_Session(string oldTrainerID, int foundIndex, Listing[] listings1, ListingUtility listingUtility1, Session[] sessions1, SessionUtility sessionUtility1, Trainer[] trainers1) {
            sessionUtility1.GetAllSessionsFromFile();
            listingUtility1.GetAllListingsFromFile();
            int sessionIndex = sessionUtility1.FindTrainerID(oldTrainerID);
            int listingIndex = listingUtility1.FindTrainerID(oldTrainerID);
            sessions1[sessionIndex].SetTrainerID(trainers1[foundIndex].GetTrainerID());
            sessions1[sessionIndex].SetTrainerName(trainers1[foundIndex].GetTrainerName());
            listings1[listingIndex].SetTrainerID(trainers1[foundIndex].GetTrainerID());
            listings1[listingIndex].SetTrainerName(trainers1[foundIndex].GetTrainerName());
            sessionUtility1.PublicSave(sessionIndex);
            listingUtility1.PublicSave(listingIndex);
        }

        public void UpdateListing(string oldTrainerID, int foundIndex, Listing[] listings1, ListingUtility listingUtility1, Trainer[] trainers1) {
            listingUtility1.GetAllListingsFromFile();
            int listingIndex = listingUtility1.FindTrainerID(oldTrainerID);
            listings1[listingIndex].SetTrainerID(trainers1[foundIndex].GetTrainerID());
            listings1[listingIndex].SetTrainerName(trainers1[foundIndex].GetTrainerName());
            listingUtility1.PublicSave(listingIndex);
        }

        public void UpdateTrainer(Listing[] listings1, ListingUtility listingUtility1, Session[] sessions1, SessionUtility sessionUtility1, Trainer[] trainers1, TrainerUtility trainerUtility1) {
            Console.WriteLine("Enter the \"trainer ID\" to update trainer info: ");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1) {
                Console.Clear();
                Console.WriteLine("Enter a new trainer ID: ");
                trainers[foundIndex].SetTrainerID(Console.ReadLine());
                Console.WriteLine("Enter a new trainer name: ");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                Console.WriteLine("Enter a new trainer mailing address: ");
                trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                Console.WriteLine("Enter a new trainer email address: ");
                trainers[foundIndex].SetTrainerEmailAddress(Console.ReadLine());
                
                //Save();
                try {
                    UpdateListing_Session(searchVal, foundIndex, listings1, listingUtility1, sessions1, sessionUtility1, trainers1);
                    listingUtility1.PublicSave();
                    sessionUtility1.PublicSave();               
                }
                catch (Exception e1){

                }
                finally {
                    Save();

                }

                try {
                    UpdateListing(searchVal, foundIndex, listings1, listingUtility1, trainers1);
                    listingUtility1.PublicSave();                
                }
                catch (Exception e2) {

                }
                finally {
                    Save();
                }
                
                //Save();
            }
            else {
                Console.Clear();
                Console.WriteLine("Trainer not found!");
                Console.ReadKey();
            }
        }

        public void DeleteTrainer() {
            Console.WriteLine("Enter the \"trainer ID\" to be deleted (enter \"cancel\" to cancel): ");
            string searchVal = Console.ReadLine();
            if(searchVal.ToUpper() == "CANCEL") {
                return;
            }
            else {
            int foundIndex = Find(searchVal);
            string[] lines = File.ReadAllLines("trainers.txt");

            if(foundIndex != -1) {
                if(foundIndex >= 0 && foundIndex < lines.Length) {
                    lines[foundIndex] = null;//set line to null then below, remove null
                    lines = lines.Where(x => x != null).ToArray();//.where() as used returns all elements in sequence that isn't null... to array converts back to array.
                }
                File.WriteAllLines("trainers.txt", lines);
                Console.Clear(); 
                Console.WriteLine("Trainer deleted");
                Console.ReadKey();
            }
            else {
                Console.Clear();
                Console.WriteLine("Trainer not found!");
                Console.ReadKey();
            }
            }
        }   


    }
}