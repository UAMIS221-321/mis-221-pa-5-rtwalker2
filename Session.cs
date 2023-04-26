namespace PA5
{
    public class Session
    {
        private string sessionID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private string trainerID;
        private string trainerName;
        private string sessionStatus = "booked";
        static private int count;

        public Session() {

        }

        public Session(string sessionID, string customerName, string customerEmail, string trainingDate, string trainerID, string trainerName, string sessionStatus) {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.sessionStatus = sessionStatus;
        }

        static public void IncrementCount() {//increment count
            Session.count++;
        }

        //getters begin
        public string GetSessionID() {
            return sessionID;
        }

        public string GetCustomerName() {
            return customerName;
        }

        public string GetCustomerEmail() {
            return customerEmail;
        }

        public string GetTrainingDate() {
            return trainingDate;
        }

        public string GetTrainerID() {
            return trainerID;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public string GetSessionStatus() {
            return sessionStatus;
        }

        static public int GetCount() {//get count
            return Session.count;
        }
        //getters end

        //setters begin
        public void SetSessionID(string sessionID) {
            this.sessionID = sessionID;
        }

        public void SetCustomerName(string customerName) {
            this.customerName = customerName;
        }

        public void SetCustomerEmail(string customerEmail) {
            this.customerEmail = customerEmail;
        }

        public void SetTrainingDate(string trainingDate) {
            this.trainingDate = trainingDate;
        }

        public void SetTrainerID(string trainerID) {
            this.trainerID = trainerID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public void SetSessionStatus(string sessionStatus) {
            this.sessionStatus = sessionStatus;
        }

        static public void SetCount(int count) {//set count
            Session.count = count;
        }
        //setters end

        public override string ToString()
        {
            return $"Session ID: {sessionID} | Customer Name: {customerName} | Customer Email: {customerEmail} | Training Date: {trainingDate} | Trainer ID: {trainerID} | Trainer Name: {trainerName} | Session Status: {sessionStatus}";
        }

        public string ToFile()
        {
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{sessionStatus}";
        }



    }
}