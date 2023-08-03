using Dapper;
using Expenses.API.Data.TypeHandlers;

namespace Expenses.API.Data
{
    public static class ServiceTypeHandlers
	{
		public static void ConfigureTypeHandlers()
		{
            // Required for mapping underscore columns _
            DefaultTypeMap.MatchNamesWithUnderscores = true; 
            // Map GUID values in MySQL
            SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
            SqlMapper.RemoveTypeMap(typeof(Guid));
            SqlMapper.RemoveTypeMap(typeof(Guid?));
        }
	}
}

