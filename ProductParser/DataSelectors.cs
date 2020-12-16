namespace coursework
{
    class DataSelectors
    {
        public static string ProductSelector = @"[data-marker=""item""]";
        public static string NameSelector = @"a[data-marker=""item-title""]";
        public static string PriceSelector = @"span[data-marker=""item-price""]";
        public static string SellerSelector = @"div[data-marker=""seller-info/name""]";
        public static string VisitorsSelector = @"div.title-info-metadata-views";
        public static string DescriptionSelector = @"div[itemprop=""description""]";
    }
}
