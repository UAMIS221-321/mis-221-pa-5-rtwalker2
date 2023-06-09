using System.Text;
namespace PA5
{
    public class ListingReport
    {
        Listing[] listings;

        public ListingReport(Listing[] listings) {
            this.listings = listings;
        }

        public void PrintAllListings() {
            for(int i = 0; i < Listing.GetCount(); i++) {
                Console.WriteLine(listings[i].ToString());
            }
        }

        public void PrintAvailableListings() {
            for(int i = 0; i < Listing.GetCount(); i++) {
                if(listings[i].GetIsListingTaken() == "no") {
                    Console.WriteLine(listings[i].ToString());
                }
            }
        }

        public void PrintRevenueReport(Session[] sessions, SessionUtility sessionUtility, SessionReport sessionReport, Listing[] listings, ListingUtility listingUtility) {
            StringBuilder report = new StringBuilder("Revenue Report:\n\n");
            
            sessionUtility.GetAllSessionsFromFile();
            listingUtility.GetAllListingsFromFile();
            int revenue = 0;
            string sessionID = "";
            Console.WriteLine("Revenue Report:\n");
            for(int i = 0; i < Session.GetCount(); i++) {
                if(sessions[i].GetSessionStatus() == "completed") {
                    sessionID = sessions[i].GetSessionID();
                    Console.WriteLine($"{sessions[i].ToString()}");
                    report.Append($"{sessions[i].ToString()}");
                    revenue += int.Parse(listings[listingUtility.Find(sessionID)].GetCostOfSession());
                }
            }
            Console.WriteLine($"\nTotal Revenue: ${revenue}");
            report.Append($"\nTotal Revenue: ${revenue}");

            if(sessionReport.yesNo()) {
                sessionReport.SaveReport(report);
            }
        }



    }
}