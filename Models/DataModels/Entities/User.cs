using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataModels.Entities;

public class User : EntityBase
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public static string ToHashString(string pass)
    {
        if (string.IsNullOrWhiteSpace(pass)) return "";
        using SHA256 hash = SHA256.Create();
        return string
            .Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass))
            .Select(x => x.ToString()));
    }
}
