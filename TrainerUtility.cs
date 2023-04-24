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


    }
}