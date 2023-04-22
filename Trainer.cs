namespace PA5
{
    public class Trainer//wont be more than 100 trainers i think
    {
        private string trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmailAddress;

        //constructors
        public Trainer() {

        }

        public Trainer(string trainerID, string trainerName, string mailingAddress, string trainerEmailAddress) {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmailAddress = trainerEmailAddress;
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



    }
}