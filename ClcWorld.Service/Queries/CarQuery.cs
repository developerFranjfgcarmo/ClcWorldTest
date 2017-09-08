﻿namespace ClcWorld.Service.Queries
{
    internal static class CarQuery
    {
        public const string GetAll = @"SELECT  Id
                                              ,Registration
                                              ,FranchiseeId
                                              ,CarBrandId
                                              ,Kilometers
                                      FROM Cars
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