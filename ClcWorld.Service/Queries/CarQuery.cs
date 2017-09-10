namespace ClcWorld.Service.Queries
{
    internal static class CarQuery
    {
        public const string GetAll = @"SELECT  c.Id
                                              ,c.Registration
                                              ,c.FranchiseeId
                                              ,c.CarBrandId
                                              ,c.Kilometers
                                              ,c.Model
                                              ,cb.NameCarBrand
                                              ,f.NameFranchisee
                                      FROM CarBrands cb INNER JOIN Cars c ON cb.Id = c.CarBrandId
                                            INNER JOIN Franchisees f ON f.Id = c.FranchiseeId
                                        {0} //Where
                                        {1} //Order
                                        OFFSET @take * (@page - 1) ROWS FETCH NEXT @take ROWS ONLY;
                                        SELECT Count(*) AS Total FROM Cars {0};
                                        ";
        public const string GetAllWhereRegistration = @"CHARINDEX(@Registration, Registration)>0";
        public const string GetAllWhereFranchiseeId = @"FranchiseeId = @FranchiseeId";
        public const string GetAllWhereCarBrandId = @"CarBrandId = @CarBrandId";
        public const string GetAllWhereKilometers = @"Kilometers = @Kilometers";
    }
}
