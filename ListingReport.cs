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
                Console.WriteLine(listings[i].GetIsListingTaken());
            }
        }

        public void PrintAvailableListings() {
            for(int i = 0; i < Listing.GetCount(); i++) {
                if(listings[i].GetIsListingTaken() == "no") {
                    Console.WriteLine(listings[i].ToString());
                }
            }
        }
    }
}