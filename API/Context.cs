using DataModels;

namespace API
{
    internal static class Context
    {
        public static DataManager Data = DataManager.Get(DataProvidersList.SqlServer); 
    }
}
