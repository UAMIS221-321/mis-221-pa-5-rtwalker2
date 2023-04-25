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

        public void UpdateTrainer() {
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

                Save();
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