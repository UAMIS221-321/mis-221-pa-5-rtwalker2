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
                //Console.WriteLine(listings[i].GetIsListingTaken());
            }
        }

        public void PrintAvailableListings() {
            for(int i = 0; i < Listing.GetCount(); i++) {
                if(listings[i].GetIsListingTaken() == "no") {
                    Console.WriteLine(listings[i].ToString());
                }
            }
        }

        public void PrintRevenueReport(Session[] sessions, SessionUtility sessionUtility, Listing[] listings, ListingUtility listingUtility) {
            sessionUtility.GetAllSessionsFromFile();
            listingUtility.GetAllListingsFromFile();
            int revenue = 0;
            string sessionID = "";
            Console.WriteLine("Revenue Report:\n");
            for(int i = 0; i < Session.GetCount(); i++) {
                if(sessions[i].GetSessionStatus() == "completed") {
                    sessionID = sessions[i].GetSessionID();
                    Console.WriteLine($"{sessions[i].ToString()}");
                    revenue += int.Parse(listings[listingUtility.Find(sessionID)].GetCostOfSession());
                }
            }
            Console.WriteLine($"\nTotal Revenue: ${revenue}");
        }



    }
}