using matheus_d3_avaliacao.Model;

namespace matheus_d3_avaliacao.Interface;

public interface IUser
{
    
    public void CreateUser(User user);
    User GetUser(string username, string password);
    
}