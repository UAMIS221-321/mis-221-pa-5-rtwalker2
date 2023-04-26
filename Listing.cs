namespace PA5
{
    public class Listing
    {
        private string listingID;
        private string trainerName;
        private string dateOfSession;
        private string timeOfSession;
        private string costOfSession;
        private string isListingTaken;
        static private int count;

        public Listing() {

        }

        public Listing(string listingID, string trainerName, string dateOfSession, string timeOfSession, string costOfSession, string isListingTaken) {
            this.listingID = listingID;
            this.trainerName = trainerName;
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

        public string GetTrainer() {
            return trainerName;
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

        public string GetIsListingTaken() {
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

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
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

        public void SetIsListingTaken(string isListingTaken) {
            this.isListingTaken = isListingTaken;
        }

        static public void SetCount(int count) {//set count
            Listing.count = count;
        }
        //setter end

        public override string ToString()
        {
            return $"Listing ID: {listingID} | Trainer Name: {trainerName} | Date of Session: {dateOfSession} | Time of Session: {timeOfSession} | Cost of Session: {costOfSession} | Is the listing taken: {isListingTaken}";
        }

        public string ToFile() 
        {
            return $"{listingID}#{trainerName}#{dateOfSession}#{timeOfSession}#{costOfSession}#{isListingTaken}";
        }

    }
}