namespace PA5
{
    public class Trainer//wont be more than 100 trainers i think
    {
        private string trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmailAddress;
        static private int count;

        //constructors
        public Trainer() {

        }

        public Trainer(string trainerID, string trainerName, string mailingAddress, string trainerEmailAddress) {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmailAddress = trainerEmailAddress;
        }

        static public void IncrementCount() {//increment count
            Trainer.count++;
        }

        //getters
        public string GetTrainerID() {
            return trainerID;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public string GetMailingAddress() {
            return mailingAddress;
        }

        public string GetTrainerEmailAddress() {
            return trainerEmailAddress;
        }

        static public int GetCount() {// get count
            return Trainer.count;
        }

        //setters
        public void SetTrainerID(string trainerID) {
            this.trainerID = trainerID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public void SetMailingAddress(string mailingAddress) {
            this.mailingAddress = mailingAddress;
        }

        public void SetTrainerEmailAddress(string trainerEmailAddress) {
            this.trainerEmailAddress = trainerEmailAddress;
        }

        static public void SetCount(int count) { //set count
            Trainer.count = count;
        }

        public override string ToString()
        {
            return $"Trainer ID: {trainerID} | Name: {trainerName} | Mailing Address: {mailingAddress} | Email Address: {trainerEmailAddress}";
        }

        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmailAddress}";
        }

    } 
}