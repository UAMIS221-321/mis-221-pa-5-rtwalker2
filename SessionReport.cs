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
                Console.WriteLine(sessions[i].ToString());
            }
        }
    }
}