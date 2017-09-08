namespace ClcWorld.Service.Helpers
{
    public static class SqlOperators
    {
        public static string And(this string where, string newFilter)
        {
            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else if (!string.IsNullOrEmpty(where) && !string.IsNullOrEmpty(newFilter))
            {
                where += " AND ";
            }

            return where + newFilter;
        }

        public static string Or(this string where, string newFilter)
        {
            if (string.IsNullOrEmpty(where))
            {
                where = " WHERE ";
            }
            else if (!string.IsNullOrEmpty(where) && !string.IsNullOrEmpty(newFilter))
            {
                where += " OR ";
            }

            return where + newFilter;
        }
    }
}
