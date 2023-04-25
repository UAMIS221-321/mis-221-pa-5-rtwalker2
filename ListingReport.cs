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
    }
}