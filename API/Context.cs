using DataModels;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Identity.Client;
namespace API;

public static class Context
{
    private static DataManager _context;

    public static DataManager Get()
    {
        if (_context == null) _context = DataManager.Get(DataProvidersList.SqlServer);
        return _context;
    }
    
}
