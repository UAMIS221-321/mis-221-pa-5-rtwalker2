namespace PA5
{
    public class Listing
    {
        private string listingID;
        private Trainer trainer;
        private string dateOfSession;
        private string timeOfSession;
        private string costOfSession;
        private bool isListingTaken;
        static private int count;

        public Listing() {

        }

        public Listing(string listingID, Trainer trainer, string dateOfSession, string timeOfSession, string costOfSession, bool isListingTaken) {
            this.listingID = listingID;
            this.trainer = trainer;
            this.dateOfSession = dateOfSession;
            this.timeOfSession = timeOfSession;
            this.costOfSession = costOfSession;
            this.isListingTaken = isListingTaken;
        }

        static public void IncrementCount() {//increment count
            Listing.count++;
        }

        //getters begin
        public string GetListingID() {
            return listingID;
        }

        public Trainer GetTrainer() {
            return trainer;
        }

        public string GetDateOfSession() {
            return dateOfSession;
        }

        public string GetTimeOfSession() {
            return timeOfSession;
        }

        public string GetCostOfSession() {
            return costOfSession;
        }

        public bool GetIsListingTaken() {
            return isListingTaken;
        }

        static public int GetCount() {//get count
            return Listing.count;
        }
        //getters end

        //setters begin
        public void SetListingID(string listingID) {
            this.listingID = listingID;
        }

        public void SetTrainer(Trainer trainer) {
            this.trainer = trainer;
        }

        public void SetDateOfSession(string dateOfSession) {
            this.dateOfSession = dateOfSession;
        }

        public void SetTimeOfSession(string timeOfSession) {
            this.timeOfSession = timeOfSession;
        }

        public void SetCostOfSession(string costOfSession) {
            this.costOfSession = costOfSession;
        }

        public void SetIsListingTaken(bool isListingTaken) {
            this.isListingTaken = isListingTaken;
        }

        static public void SetCount(int count) {//set count
            Listing.count = count;
        }
        //setter end

        public override string ToString()
        {
            return $"Listing ID: {listingID} | Trainer Name: {trainer.GetTrainerName()} | Date of Session: {dateOfSession} | Time of Session: {timeOfSession} | Cost of Session: {costOfSession} | Is the listing taken: {isListingTaken}";
        }

        public string ToFile() 
        {
            return $"{listingID}#{trainer.GetTrainerName()}#{dateOfSession}#{timeOfSession}#{costOfSession}#{isListingTaken}";
        }



    }
}