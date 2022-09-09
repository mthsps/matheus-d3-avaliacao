using matheus_d3_avaliacao.Model;

namespace matheus_d3_avaliacao.Interface;

public interface IUser
{
    List<User> GetUsers();
    User GetUser(string username, string password);
}