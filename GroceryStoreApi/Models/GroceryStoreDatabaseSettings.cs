namespace GroceryStoreApi.Models
{
    public class GroceryStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string GroceryCollectionName { get; set; } = null!;

    }
}
