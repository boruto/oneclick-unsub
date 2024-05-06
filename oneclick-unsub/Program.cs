using System;
using System.Security.Cryptography;
using System.Text;

namespace unsub;

class Program
{
    public static string Hash(string stringToHash, string key)
    {
        if (stringToHash == null)
            throw new ArgumentNullException(nameof(stringToHash));
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] textBytes = Encoding.UTF8.GetBytes(stringToHash.ToString());

        var hashedBytes = new HMACSHA256(keyBytes).ComputeHash(textBytes);
        var hashedText = Convert.ToHexString(hashedBytes);

        return hashedText;
    }

    static void Main(string[] args)
    {
        string playerId = "123456";
        string key = "SomeSharedSecret";

        Console.WriteLine($"playerId:{playerId}");
        Console.WriteLine($"key:{key}");
        Console.WriteLine($"verification:{Hash(playerId, key)}");
        Console.WriteLine($"endpoint parameters:\tplayerId={playerId}&verification={Hash(playerId, key)}");
    }
}
