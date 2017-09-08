namespace ClcWorld.Service.Queries
{
    internal static class  FranchiseeQuery
    {
        public const string GetAll = @"SELECT Id
                                          ,Name
                                          ,AddressFranchisee
                                      FROM Franchisees
                                        {0} //Where
                                        {1} //Order
                                        OFFSET @take * (@page - 1) ROWS FETCH NEXT @take ROWS ONLY;
                                        SELECT Count(*) AS Total FROM Franchisees {0};
                                        ";
        public const string GetAllWhereAddressFranchisee = @"CHARINDEX(@AddressFranchisee, AddressFranchisee)>0";
        public const string GetAllWhereName = @"CHARINDEX(@Name, Name)>0";
    }
}
