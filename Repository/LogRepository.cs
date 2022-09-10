using System.Text;
using matheus_d3_avaliacao.Interface;
using matheus_d3_avaliacao.Model;

namespace matheus_d3_avaliacao.Repository;

public class LogRepository : ILog
{
    private const string path = "database/log.txt";
    
    public LogRepository()
    {
        CreateFolderFile(path);
    }

    private static string PrepareLineSignIn(User user)
    {
        return
            $"O usuário {user.Nome} acessou o sistema às {DateTimeOffset.Now.ToString("HH:mm")} do dia {DateTimeOffset.Now.ToString("d")}";
    }
    
    private static string PrepareLineLogout(User user)
    {
        return
            $"O usuário {user.Nome} deslogou do sistema às {DateTimeOffset.Now.ToString("HH:mm")} do dia {DateTimeOffset.Now.ToString("d")}.";
    }
    

    public static void CreateFolderFile(string path)
    {
        string folder = path.Split("/")[0];

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    public void RegisterAccess(User user, string login)
    {
        StreamWriter file = new StreamWriter(path, true);
        string line = login == "in" ? PrepareLineSignIn(user) : PrepareLineLogout(user);
        file.WriteLine(line);
        file.Close();
    }
}