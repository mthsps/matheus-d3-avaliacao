using System.Security.Cryptography;
using System.Text;

namespace matheus_d3_avaliacao.Security;

static class Encryption
{
    
    public static string Encrypt(string password)
    {
        var md5 = MD5.Create();
        var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
        var sbString = new StringBuilder();
        foreach (var t in data)
        {
            sbString.Append(t.ToString("x2"));
        }
        return sbString.ToString();
    }
    
    
}