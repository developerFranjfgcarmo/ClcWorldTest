namespace ClcWorld.Service.Queries
{
    internal static class MasterTablesQuery
    {
        public  const string GetCarBrand = @"Select Id, Name FROM CarBrands";
        public const string GetFranchisees = @"Select Id, Name FROM Franchisees";
    }
}
