namespace coursework.Parser
{
    class DataSelectors
    {
        public static string ProductSelector = @"[data-marker=""item""]";
        public static string NameSelector = @"a[data-marker=""item-title""]";
        public static string PriceSelector = @"span[data-marker=""item-price""]";
        public static string SellerSelector = @"div[data-marker=""seller-info/name""]";
    }
}
